using System;
using System.Collections.Generic;
namespace Adapter_CS_1
{
    class EmployeeDatabase  
    {
        public static void UploadPersonnel(List<Person> personnel)
        {
            foreach(var ps in personnel)
            {
                Console.WriteLine($"INSERT INTO HR.EMPLOYEES (firstname, lastname) VALUES ('{ps.Firstname}','{ps.Lastname}');");
            }
        }
    }
    
}

