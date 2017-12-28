using System;

namespace LSP_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static bool ConnectToDatabase(IDB database, string user, string password)
        {
            
            if(database is DbInAzure)
            {
                return database.Connect($"usr={user},pwd={password}");
            }
            else if(database is DbInAWS)
            {
                return database.Connect($"user={user}&pwd={password}");
            }
            return false; 
        }
    }
}
