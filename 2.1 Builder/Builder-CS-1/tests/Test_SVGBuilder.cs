using Xunit;
using System.IO;
namespace Builder_CS_1
{
    public class Test_SVGBuilder
    {
        SVGBuilder svgBuilder = new SVGBuilder(100,100);
        string baseSVGTag = "<svg height=\"100\" width=\"100\" xmlns=\"http://www.w3.org/2000/svg\">\n";
        [Fact]
        public void Construct_Test()
        {
            var svg = svgBuilder.BuildAll();
            //This allows you to do one Read operation.
            Assert.Equal(baseSVGTag+"</svg>\n",svg.IndentedToString(0));
        }

        [Fact]
        public void AddElement_Test()
        {
            svgBuilder.AddElement(new SVGElement("line")).AddElement(new SVGElement("circle"));
            string val = baseSVGTag;
            val += " <line>\n";
            val += " </line>\n";
            val += " <circle>\n";
            val += " </circle>\n";
            val +="</svg>\n";
            var svg = svgBuilder.BuildAll();
            Assert.Equal(svg.IndentedToString(0),val);
        }

         [Fact]
        public void Clear_Test()
        {
            svgBuilder.AddElement(new SVGElement("line")).AddElement(new SVGElement("circle"));
            string val = baseSVGTag;
            val +="</svg>\n";
            svgBuilder.Clear();
            var svg = svgBuilder.BuildAll();
            Assert.Equal(svg.IndentedToString(0),val);
        }


    }
}