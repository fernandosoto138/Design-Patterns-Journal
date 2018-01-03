using System.Text;
using System.Collections;
namespace Strategy_CS_1
{
    class HtmlGenerator : IDocStrategy
    {
        public StringBuilder sb { get; private set; } = new StringBuilder();
        public IDocStrategy AddText(string text)
        {
            sb.AppendLine($"<p>{text}</p>");
            return this; 
        }
        public IDocStrategy AddList(IEnumerable items)
        {
            sb.AppendLine("<ul>");
            foreach(var item in items)
                sb.AppendLine($"  <li>{item}</li>");
            sb.AppendLine("</ul>");
            return this;
        }
        public string GenerateDoc() => sb.ToString();
    }
}
