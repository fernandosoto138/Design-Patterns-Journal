using System;
using System.Collections.Generic;

namespace OCP_CS_BadEx1
{
    public enum Maturation{Poor, Good}
    class Program
    {
        
        static void Main(string[] args)
        {
            List<IProduct> products = new List<IProduct>();
            products.Add(new Apple(Maturation.Good, 1));
            products.Add(new Apple(Maturation.Good, 1));
            products.Add(new Apple(Maturation.Good, 1));
            products.Add(new Apple(Maturation.Poor, 2));    
            products.Add(new Carrot(Maturation.Good, 10));
            System.Console.WriteLine($"Total: {PriceCalculator.CalcPrice(products)}");
        }
    }
}
