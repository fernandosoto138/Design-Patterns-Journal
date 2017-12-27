using System;
using System.Collections.Generic;
/*
    This code fixes SRP but fails in other principles. 
    One step at time. 
 */

namespace SRP_CSharp_GoodEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            User usr = new User("Adam"+rnd.Next().ToString(), rnd.Next(1,60));
            UserPersistence.SaveIntoAFile(usr, "Users.txt");
            List<User> usrs = UserPersistence.LoadFile("Users.txt");
            foreach (var item in usrs)
            {
                System.Console.WriteLine(item.ToString());
            }
        }
    }
}
