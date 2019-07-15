using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRundown
{
    class Game
    {
        public async Task<string> DailyInfoFetch()
        {
            OnlineWeather todaysWeather = new OnlineWeather();
            await todaysWeather.fetchWeatherOnline("Milwaukee");
            OnlineNews todaysSportsNews = new OnlineNews();
            await todaysSportsNews.FetchSportsNewsOnline();
            int interestingNewsInt = todaysSportsNews.NewsSelection();
            await todaysSportsNews.FetchSportsSpecificStory(interestingNewsInt);

            return "Complete";
        }

    }
}
