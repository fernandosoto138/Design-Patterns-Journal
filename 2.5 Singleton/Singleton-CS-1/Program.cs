using System;

namespace Singleton_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperLogSingleton.Instance.AddLine("Hello, I'm a SuperLog");
            SuperLogSingleton.Instance.AddLine("I'm unique in this world");
            SuperLogSingleton.Instance.AddLine("That's why everyone hates me");
            Console.WriteLine(SuperLogSingleton.Instance.Output);
            LazySuperLogSingleton.Instance.AddLine("Respond Please!!!");
            Console.WriteLine(LazySuperLogSingleton.Instance.Output);
        }
    }
}
