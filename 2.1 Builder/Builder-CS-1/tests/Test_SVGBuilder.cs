using Xunit;
using System.IO;
namespace Builder_CS_1
{
    public class Test_SVGBuilder
    {
        SVGBuilder svgBuilder = new SVGBuilder(100,100);

        [Fact]
        public void Construct_Test()
        {
            var svg = svgBuilder.Construct();
            //This allows you to do one Read operation.
            Assert.Equal("<svg height=\"100\" width=\"100\">\n</svg>\n",svg.IndentedToString(0));
        }

        [Fact]
        public void AddElement_Test()
        {
            svgBuilder.AddElement(new SVGElement("line")).AddElement(new SVGElement("circle"));
            string val = "<svg height=\"100\" width=\"100\">\n";
            val += " <line>\n";
            val += " </line>\n";
            val += " <circle>\n";
            val += " </circle>\n";
            val +="</svg>\n";
            var svg = svgBuilder.Construct();
            Assert.Equal(svg.IndentedToString(0),val);
        }

         [Fact]
        public void Clear_Test()
        {
            svgBuilder.AddElement(new SVGElement("line")).AddElement(new SVGElement("circle"));
            string val = "<svg height=\"100\" width=\"100\">\n";
            val +="</svg>\n";
            svgBuilder.Clear();
            var svg = svgBuilder.Construct();
            Assert.Equal(svg.IndentedToString(0),val);
        }


    }
}