using System;

namespace Proxy_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Db.LoadData();
            ProductProxy ppx = new ProductProxy("Notebook");
            Console.WriteLine(ppx.Price);
        }
    }
}
    



