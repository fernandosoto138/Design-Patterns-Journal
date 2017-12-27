using System.Collections.Generic;

namespace OCP_CS_BadEx1
{
    class PriceCalculator 
    {
        public static double CalcPrice(List<IProduct> ProductList)
        {
            double price = 0;
            foreach(var product in ProductList)
            {
                price += product.Price;
                System.Console.WriteLine($"Product:{product.Name} \t Value:{product.Price} \t Subtotal:{price}");
            }
            return price;
        }
    }
}
