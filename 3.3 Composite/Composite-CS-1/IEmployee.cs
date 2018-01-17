namespace Composite_CS_1
{
    interface IEmployee
    {
        string Name { get; set; }
        double Punctuality { get; set; }
        double Asistance { get; set; }
        double QualityOfWork { get; set; }
        void PrintPerformance();
    }

    
}
