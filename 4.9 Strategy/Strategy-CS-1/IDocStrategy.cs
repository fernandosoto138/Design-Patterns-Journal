using System.Text;
using System.Collections;
namespace Strategy_CS_1
{
    interface IDocStrategy
    {
        StringBuilder sb { get; }
        IDocStrategy AddText(string text);
        IDocStrategy AddList(IEnumerable items);
        string GenerateDoc();
    }
}
