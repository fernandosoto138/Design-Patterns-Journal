using System;

namespace Builder_CS_1
{
    class SVGBuilder : ISVGBuilder
    {
        public ISVGElement root {get; private set;} = new SVGElement("svg");
        
        public SVGBuilder(int height, int width)
        {
            root.AddProperty("height",height.ToString())
                .AddProperty("width",width.ToString());
        }

        public ISVGBuilder AddElement(ISVGElement elem)
        {
            root.AddElement(elem);
            return this;
        } 
        public void Save(string filename)
        {
            try
            {
                System.IO.File.WriteAllText (filename, root.IndentedToString(0));
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
        }

        public void Clear() => root.Elements = new System.Collections.Generic.List<ISVGElement>();

    }

}
