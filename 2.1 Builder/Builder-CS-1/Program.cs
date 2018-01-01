using System;
using System.IO;
namespace Builder_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "Test.svg";
            var svgBuilder = new SVGBuilder(400,400);
            var svgRectangle = new SVGElement("rect");
            svgRectangle.AddProperty("x","20")
                        .AddProperty("y","20")
                        .AddProperty("width","250")
                        .AddProperty("height","250")
                        .AddProperty("style","fill:blue");
            var svgAnimation = new SVGElement("animate");
            svgAnimation.AddProperty("attributeType","CSS")
                        .AddProperty("attributeName","opacity")
                        .AddProperty("from","1")
                        .AddProperty("to","0")
                        .AddProperty("dur","2s")
                        .AddProperty("repeatCount","indefinite");
            svgBuilder.AddElement(svgRectangle.AddElement(svgAnimation));
            var fullSvg = svgBuilder.Construct();
            File.WriteAllText(filename,fullSvg.ToString());
        }
    }

}
