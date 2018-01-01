using Xunit;

namespace Builder_CS_1
{
    public class Test_SVGElement
    {
        SVGElement svgTag = new SVGElement("svg");

        [Fact]
        public void SimpleTag()
        {
            Assert.Equal("<svg>\n</svg>\n",svgTag.IndentedToString(0));
        }
        [Fact]
        public void SimpleTagWithText()
        {
            SVGElement svgTag = new SVGElement("svg");
            svgTag.Text = "SAMPLETEXT";
            Assert.Equal("<svg>\nSAMPLETEXT</svg>\n",svgTag.IndentedToString(0));
        }

        [Fact]
        public void TagWithTwoProperties()
        {
            svgTag.AddProperty("height","100").AddProperty("width","100");
            Assert.Equal("<svg height=\"100\" width=\"100\">\n</svg>\n",svgTag.IndentedToString(0));
        }

        [Fact]
        public void SimpleTagWithTwoChildElements()
        {
            svgTag.AddElement(new SVGElement("line")).AddElement(new SVGElement("circle"));
            string val = "<svg>\n";
            val += " <line>\n";
            val += " </line>\n";
            val += " <circle>\n";
            val += " </circle>\n";
            val +="</svg>\n";
            Assert.Equal(val, svgTag.IndentedToString(0));
        }
        [Fact]
        public void SimpleTagWithAChildWithAChild()
        {
            svgTag.AddElement(new SVGElement("line").AddElement(new SVGElement("circle")));
            string val = "<svg>\n";
            val += " <line>\n";
            val += "  <circle>\n";
            val += "  </circle>\n";
            val += " </line>\n";
            val +="</svg>\n";
            Assert.Equal(val, svgTag.IndentedToString(0));
        }
        

    }
}