using System;
using System.Text;
using System.Xml.Serialization;

namespace Prototype_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new StringBuilder();
            s1.AppendLine("Hello");
            s1.AppendLine("I'm a very complicated object");
            var s2 = s1.DeepCopy();
            s2.AppendLine("I'm the clone of s1");
            Console.WriteLine(s1);
            Console.WriteLine(s2);

            //Huge class needs to be public.
            HugeClass huge1 = new HugeClass();
            huge1.Text += " and beautiful";
            var huge2 = huge1.DeepCopyXml();
            Console.WriteLine(huge2);
            
        }

    }
}
