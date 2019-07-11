using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRundown
{
    class WeatherStatus
    {
        public double RealTimeTempConvert(string foundTemp)
        {
            double foundTempDouble = Double.Parse(foundTemp);
            double updatedTemp = Math.Round(((foundTempDouble - 273) * 1.8) + 32);
            return updatedTemp;
        }
    }
}
