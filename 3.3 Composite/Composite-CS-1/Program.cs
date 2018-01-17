namespace Composite_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var IT1 = new Employee(){Name="JohnDoe",Punctuality=10d,Asistance=10d,QualityOfWork=10d};
            var IT2 = new Employee(){Name="Foobar",Punctuality=9d,Asistance=10d,QualityOfWork=10d};
            var IT3 = new Employee(){Name="Max Power",Punctuality=10d,Asistance=10d,QualityOfWork=0d};
            var Adm1 = new Employee(){Name="John Carter",Punctuality=2d,Asistance=10d,QualityOfWork=5d};
            var Adm2 = new Employee(){Name="Batman",Punctuality=7d,Asistance=10d,QualityOfWork=6d};
            var SupAdm = new Supervisor(){Name="Mecha-Trump",Punctuality=7d,Asistance=10d,QualityOfWork=6d, Department ="Administration"};
            var SupIT = new Supervisor(){Name="Angry Giraffe",Punctuality=7d,Asistance=10d,QualityOfWork=6d, Department ="IT"};
            SupIT.Employees.Add(IT1);
            SupIT.Employees.Add(IT2);
            SupIT.Employees.Add(IT3);
            SupAdm.Employees.Add(Adm1);
            SupAdm.Employees.Add(Adm2);
            SupAdm.Employees.Add(SupIT);
            SupAdm.PrintPerformance();
        }
    }

    
}
