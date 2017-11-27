using System;
using System.IO;
using System.Collections.Generic;

/*
    This code not only violates SRP... 
    But, keep things easy, we will improve this code in the next principles. 
 */

namespace SRP_CSharp_BadEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            User usr = new User("Adam"+rnd.Next().ToString(), rnd.Next(1,60));
            usr.SaveIntoAFile("Users.txt");
            List<User> usrs = User.LoadFile("Users.txt");
            foreach (var item in usrs)
            {
                System.Console.WriteLine(item.ToString());
            }
        }
    }

    class User
    {
        public int Age { get; private set; }
        public string Name {get; private set; }

        public User(string name, int age)
        {
            if(!ValidateAge(age) || !ValidateName(name))
                throw new ArgumentException("Check Args");
            this.Age = age;
            this.Name = name;
        }

        private bool ValidateName(string name)
        {
            if(name == "")
                return false;
            //More Validations...
            return true;
        }

        private bool ValidateAge(int age)
        {
            if(age <= 0)
             return false;
            //More Validations...
            return true;
        }

        public void SaveIntoAFile(string filename)
        {
            using( StreamWriter file = new StreamWriter(filename,true))
            {
                file.WriteLine(this.ToString());
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

        public override string ToString() => $"{Name}, {Age}";
    }
}
