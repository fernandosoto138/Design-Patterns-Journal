using System;
using System.IO;
using System.Threading;
namespace Observer_CS_2
{
    class StockReader : Subject
    {
        public double Close;
        public double Open;
        public double High;
        public double Low;
        public void StartRead(string filename)
        {
            using(var reader = new StreamReader(filename))
            {
                string line = reader.ReadLine();
                string[] values;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    values = line.Split(',');
                    //The set state:
                    Open =double.Parse(values[2]);
                    High = double.Parse(values[3]);
                    Low = double.Parse(values[4]);
                    Close = double.Parse(values[5]);
                    Console.Clear();
                    Notify();
                    Thread.Sleep(10);
                }
            }
        }
    }
}
