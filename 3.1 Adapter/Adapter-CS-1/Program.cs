using System;
using System.Collections.Generic;
namespace Adapter_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var EmpAdapter = new EmployeeAdapter();
            EmployeeDatabase.UploadPersonnel(EmpAdapter.GetEmployeeList());
        }
    }

    
}

