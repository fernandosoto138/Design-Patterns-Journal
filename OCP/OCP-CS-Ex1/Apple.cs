namespace OCP_CS_BadEx1
{
    class Apple : IProduct
    {
        
        public Maturation Ripe { get; private set; }
        public double Weight{get; private set;}
        public double PricePerKg {get; private set;}
        public Apple(Maturation maturation, double Weight)
        {
            this.Weight = Weight;
            this.Ripe = maturation;
            this.PricePerKg = 10;
        }
        public Apple(Maturation maturation, double Weight, double PricePerKg)
        {
            this.Weight = Weight;
            this.Ripe = maturation;
            this.PricePerKg = PricePerKg;
        }
        public double Price  {
            get{
                if(Ripe == Maturation.Poor)
                    return PricePerKg*Weight*0.5;
                else
                    return PricePerKg*Weight;
            }
        }
        private string _Name = "Great Apple";
        public string Name { get =>  _Name; set => _Name = value; }
    }
}
