using System.Text;
using System.Collections;
namespace Strategy_CS_1
{
    class MarkdownGenerator : IDocStrategy
    {
        
        public StringBuilder sb { get; private set; } = new StringBuilder();
        public IDocStrategy AddText(string text)
        {
            sb.AppendLine(text);
            return this; 
        }
        public IDocStrategy AddList(IEnumerable items)
        {
            sb.AppendLine("");
            foreach(var item in items)
                sb.AppendLine($"- {item}");
            sb.AppendLine("");
            return this;
        }
        public string GenerateDoc() => sb.ToString();
    }
}
