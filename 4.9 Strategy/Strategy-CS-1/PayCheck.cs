using System;
using System.Collections;
namespace Strategy_CS_1
{
    class PayCheck
    {
        public static void GeneratePaycheck (IDocStrategy OutputFormat, string name, IEnumerable Payments)
        {
            string separator = "--------i-am-a-rustic-separator-bar--------";
            OutputFormat.AddText($"Name : {name}");
            OutputFormat.AddText(separator);
            OutputFormat.AddList(Payments);
            OutputFormat.AddText(separator);
            Console.WriteLine(OutputFormat.GenerateDoc());  
        }
    }
}
