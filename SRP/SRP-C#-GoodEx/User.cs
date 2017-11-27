using System;

/*
    This code fixes SRP but fails in other principles. 
    One step at time. 
 */

namespace SRP_CSharp_GoodEx
{
    class User
    {
        public int Age { get; private set; }
        public string Name {get; private set; }

        public User(string name, int age)
        {
            if(!Validations.Age(age) || !Validations.Name(name))
                throw new ArgumentException("Check Args");
            this.Age = age;
            this.Name = name;
        }


        public override string ToString() => $"{Name}, {Age}";
    }
}
