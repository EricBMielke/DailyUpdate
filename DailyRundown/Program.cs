using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRundown
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Game news = new Game();
            await news.DailyInfoFetch();
           
        }
    }
}
