/*
    This code fixes SRP but fails in other principles. 
    One step at time. 
 */

namespace SRP_CSharp_GoodEx
{
    class Validations
    {

        public static bool Name(string name)
        {
            if(name == "")
                return false;
            //More Validations...
            return true;
        }

        public static bool Age(int age)
        {
            if(age <= 0)
             return false;
            //More Validations...
            return true;
        }
    }
}
