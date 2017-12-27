namespace OCP_CS_BadEx1
{
    class Carrot : IProduct
    {
        
        public Maturation Ripe { get; private set; }
        public double Weight{get; private set;}
        public double PricePerKg {get; private set;}
        private string _Name = "Orange Carrot";
        public string Name { get =>  _Name; set => _Name = value; }

        public Carrot(Maturation maturation, double Weight)
        {
            this.Weight = Weight;
            this.Ripe = maturation;
            this.PricePerKg = 6;
        }
        public Carrot(Maturation maturation, double Weight, double PricePerKg)
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

    }
}
