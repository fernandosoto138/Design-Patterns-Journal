using System.Linq;
namespace Observer_CS_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StockReader sr = new StockReader();
            DisplayStockPrice display = new DisplayStockPrice();
            MovingAverage sma20 = new MovingAverage(20);
            sr.Attach(display);
            sr.Attach(sma20);
            sr.StartRead("stock.csv");
        }
    }
}
