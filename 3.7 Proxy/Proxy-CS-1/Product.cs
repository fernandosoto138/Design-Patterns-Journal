namespace Proxy_CS_1
{
    public class Product : IProduct
    {
        public string Name { get; private set;}
        public double Price { get; private set;}
        public Product(string Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
    }
}
    



