using System;
using System.Linq;
namespace Observer_CS_2
{
    class MovingAverage : Observer
    {
        public int Periods { get; set; }
        double[] values ;
        int count = 0;
        bool filled = false; 
        public MovingAverage(int Periods)
        {
            this.Periods = Periods;
            values = new double[Periods];
        } 
        public override void Update(Subject subject)
        {
            StockReader sr = subject as StockReader;
            if(count == Periods)
                count = 0;
            if(filled)
            {
                values[count] = sr.Close;
                Console.WriteLine($"Moving Average({Periods}) :{values.Average()}");
            }
            else
            {
                if(count == Periods - 1)
                    filled = true;
                values[count] = sr.Close;
            }
            count++;
        }
    }
}
