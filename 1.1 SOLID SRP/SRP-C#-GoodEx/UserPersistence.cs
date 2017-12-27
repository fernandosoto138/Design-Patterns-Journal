using System;
using System.IO;
using System.Collections.Generic;

/*
    This code fixes SRP but fails in other principles. 
    One step at time. 
 */

namespace SRP_CSharp_GoodEx
{
    class UserPersistence
    {
        public static void SaveIntoAFile(User usr, string filename)
        {
            using( StreamWriter file = new StreamWriter(filename,true))
            {
                file.WriteLine(usr.ToString());
            }
        }

        public static List<User> LoadFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            List<User> usrs = new List<User>();
            foreach(var str in lines)
            {
                string[] values = str.Split(',');
                usrs.Add(new User(values[0],Int32.Parse(values[1])));
            }
            return usrs;
        }
    }
}
