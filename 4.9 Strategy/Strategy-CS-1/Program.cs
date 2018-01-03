using System.Collections.Generic;
namespace Strategy_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string person = "John Doe";
            List<string> payments = new List<string>();
            payments.Add("Salary : + 3.000");
            payments.Add("Extra hours : + 500");
            payments.Add("Income Tax : - 500");
            payments.Add("Total : 3.000");
            PayCheck.GeneratePaycheck(new MarkdownGenerator(), person, payments);
            PayCheck.GeneratePaycheck(new HtmlGenerator(), person, payments);
        }
    }
}
