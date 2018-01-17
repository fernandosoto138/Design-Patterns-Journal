using System;
using System.Collections.Generic;
namespace Composite_CS_1
{
    class Supervisor : IEmployee
    {
        public string Name { get; set; }
        public double Punctuality { get; set; }
        public double Asistance { get; set; }
        public double QualityOfWork { get; set; }
        public string Department { get; set; }
        public List<IEmployee> Employees { get; set; } = new List<IEmployee>();
        public void PrintPerformance()
        {
            var (mean,std) =Statistics.MeandAndStd(new double[]{Punctuality,Asistance,QualityOfWork});
            Console.WriteLine("------Department "+Department);
            Console.WriteLine($"The Supervisor {Name} has an average performance of {mean.ToString("0.00")} with an {std.ToString("0.00")} deviation");
            foreach(var Employee in Employees)
            {
                Employee.PrintPerformance();
            }
        }
    }

    
}
