using System.Collections.Generic;

namespace Builder_CS_1
{
    class SVGElement : ISVGElement
    {
        public string TagName { get; private set; }
        public string Properties { get; private set; } = "";
        public List<ISVGElement> Elements { get; private set; } = new List<ISVGElement>();

        public SVGElement(string TagName)
        {
            this.TagName = TagName;
        }

        public SVGElement()
        {
        }

        public ISVGElement AddProperty(string key, string value)
        {
            Properties += $" {key}=\"{value}\"";
            return this;
        }

        public ISVGElement AddElement(ISVGElement Element)
        {
            Elements.Add(Element);
            return this;
        }

        public string IndentedToString(int indent)
        {
            string space = new string(' ', indent);
            string val = "";
            val += $"{space}<{TagName}{Properties}>\n";
            foreach(ISVGElement elem in Elements)
                val += elem.IndentedToString(indent+1);
            val += $"{space}</{TagName}>\n";
            return val;
        }
        
    }
}
