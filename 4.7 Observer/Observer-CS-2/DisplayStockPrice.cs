using System;
namespace Observer_CS_2
{
    class DisplayStockPrice : Observer
    {
        public override void Update(Subject subject)
        {
            StockReader sr = subject as StockReader;
            Console.WriteLine("Open  Price:" + sr.Open.ToString());
            Console.WriteLine("High  Price:" + sr.High.ToString());
            Console.WriteLine("Low   Price:" + sr.Low.ToString());
            Console.WriteLine("Close Price:" + sr.Close.ToString());
        }
    }
}
