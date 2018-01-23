using System.Collections.Generic;

namespace Proxy_CS_1
{
    public class Db
    {
        private static Dictionary<string,double> Products = new Dictionary<string,double>();
        public static void LoadData()
        {
            Products.Add("Milk",1.0D);
            Products.Add("Eggs",2.0D);
            Products.Add("Apples",0.5D);
            Products.Add("Paint",10D);
            Products.Add("Notebook", 350.5D);
        }
        public static Product GetProduct(string Name) => new Product(Name,Products[Name]);
    }
}
    



