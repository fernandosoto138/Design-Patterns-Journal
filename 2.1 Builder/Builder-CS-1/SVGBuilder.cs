using System;

namespace Builder_CS_1
{
    class SVGBuilder : ISVGBuilder
    {
        public ISVGElement root {get; private set;} = new SVGElement("svg");
        
        public SVGBuilder(int height, int width)
        {
            root.AddProperty("height",height.ToString())
                .AddProperty("width",width.ToString())
                //If root tag does not have this namespace the browser will not know
                //how to read it. 
                .AddProperty("xmlns","http://www.w3.org/2000/svg");
        }

        public ISVGBuilder AddElement(ISVGElement elem)
        {
            root.AddElement(elem);
            return this;
        }
        public ISVGElement Construct() => root;

        public void Clear() => root.Elements = new System.Collections.Generic.List<ISVGElement>();

    }

}
