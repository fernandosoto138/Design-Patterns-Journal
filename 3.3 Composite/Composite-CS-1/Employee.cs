using System;
namespace Composite_CS_1
{
    class Employee : IEmployee
    {
        public string Name { get; set; }
        public double Punctuality { get; set; }
        public double Asistance { get; set; }
        public double QualityOfWork { get; set; }
        public void PrintPerformance()
        {
            var (mean, std) = Statistics.MeandAndStd(new double[]{Punctuality, Asistance,QualityOfWork});
            Console.WriteLine($"The employee {Name} has an average performance of {mean.ToString("0.00")} with an {std.ToString("0.00")} deviation");
        }
    }

    
}
