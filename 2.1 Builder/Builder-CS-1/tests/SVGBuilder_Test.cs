using Xunit;
using System.IO;
namespace Builder_CS_1
{
    public class SVGBuilder_Test
    {
        SVGBuilder svgBuilder = new SVGBuilder(100,100);
        string filename = "test.svg";

        [Fact]
        public void Save_Test()
        {
            svgBuilder.Save(filename);
            using (StreamReader sr = new StreamReader(filename)) 
            {
                //This allows you to do one Read operation.
                Assert.Equal("<svg height=\"100\" width=\"100\">\n</svg>\n",sr.ReadToEnd());
            }
            
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
            svgBuilder.Save(filename);
            using (StreamReader sr = new StreamReader(filename)) 
            {
                //This allows you to do one Read operation.
                Assert.Equal(sr.ReadToEnd(),val);
            }
        }

         [Fact]
        public void Clear_Test()
        {
            svgBuilder.AddElement(new SVGElement("line")).AddElement(new SVGElement("circle"));
            string val = "<svg height=\"100\" width=\"100\">\n";
            val +="</svg>\n";
            svgBuilder.Clear();
            svgBuilder.Save(filename);
            using (StreamReader sr = new StreamReader(filename)) 
            {
                //This allows you to do one Read operation.
                Assert.Equal(sr.ReadToEnd(),val);
            }
        }


    }
}