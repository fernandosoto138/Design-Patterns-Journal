using System;
using System.Collections.Generic;
using System.Linq;
namespace Composite_CS_1
{
    static class Statistics
    {
        public static (double, double) MeandAndStd(IEnumerable<double> values)
        {
            double mean = values.Average();
            double sum = values.Sum( val => (val - mean)*(val - mean));
            double std = Math.Sqrt(sum/values.Count());
            return (mean,std);
        }
    }

    
}
