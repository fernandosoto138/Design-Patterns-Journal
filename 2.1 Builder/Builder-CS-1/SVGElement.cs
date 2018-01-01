using System.Collections.Generic;

namespace Builder_CS_1
{
    class SVGElement : ISVGElement
    {
        public string TagName { get; private set; }
        public string Properties { get; private set; } = "";
        public List<ISVGElement> Elements { get;  set; } = new List<ISVGElement>();

        public string Text { get; set;} = ""; 
        public SVGElement(string TagName)
        {
            this.TagName = TagName;
        }
        public SVGElement(string TagName, string Text)
        {
            this.TagName = TagName;
            this.Text = Text;
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
            string spaceplus = space + " ";
            string val = "";
            if(Text == "")
                val += $"{space}<{TagName}{Properties}>\n";
            else 
                val += $"{space}<{TagName}{Properties}>\n{spaceplus}{Text}";
            foreach(ISVGElement elem in Elements)
                val += elem.IndentedToString(indent+1);
            val += $"{space}</{TagName}>\n";
            return val;
        }

        public override string ToString() => this.IndentedToString(0);
         
    }
}
