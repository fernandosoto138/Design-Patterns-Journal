namespace Adapter_CS_1
{
    class Person : IPerson
    {
        public string Firstname { get;  set;}
        public string Lastname { get ; set;}

        public override string ToString() => $"{Firstname} {Lastname}";
        
    }
    
}

