namespace Proxy_CS_1
{
    class ProductProxy : IProduct
    {
        public string Name { get; private set;}
        public ProductProxy(string Name) => this.Name = Name;
        public double Price { get => Db.GetProduct(Name).Price; }
    }
}
    



