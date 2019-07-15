using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DailyRundown
{
    public class Multimedia
    {
        public string url { get; set; }
        public string format { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public string caption { get; set; }
        public string copyright { get; set; }
    }

    public class Result
    {
        public string section { get; set; }
        public string subsection { get; set; }
        public string title { get; set; }
        public string @abstract { get; set; }
        public string url { get; set; }
        public string byline { get; set; }
        public string item_type { get; set; }
        public DateTime updated_date { get; set; }
        public DateTime created_date { get; set; }
        public DateTime published_date { get; set; }
        public string material_type_facet { get; set; }
        public string kicker { get; set; }
        public List<string> des_facet { get; set; }
        public List<object> org_facet { get; set; }
        public List<object> per_facet { get; set; }
        public List<object> geo_facet { get; set; }
        public List<Multimedia> multimedia { get; set; }
        public string short_url { get; set; }
    }

    public class RootObject2
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public string section { get; set; }
        public DateTime last_updated { get; set; }
        public int num_results { get; set; }
        public List<Result> results { get; set; }
    }
    public class OnlineNews
    {

        private const string URL = "https://api.nytimes.com/svc/topstories/v2/sports.json";

        public async Task<string> FetchSportsNewsOnline()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            // List data response.
            HttpResponseMessage response = client.GetAsync("?api-key=43wDT9yQnT0ilG6lvpGqQA37lzjQ70vG").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                dynamic parsedBody = JsonConvert.DeserializeObject(responseBody);
                for (int i = 0; i < 10; i++)
                {
                    string realTimeNews = parsedBody.results[i].title;
                    Console.WriteLine(realTimeNews);
                }
                Console.ReadLine();
                return "foo";
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                string realTimeSportsNews = "so";
                return realTimeSportsNews;
            }
        }

        public int NewsSelection()
        {
            Console.WriteLine("Do any of these news stories interest you? If so, which one?");
            string newsDecision=Console.ReadLine();
            int newsDecisionInt = Convert.ToInt32(newsDecision);
            return newsDecisionInt;
        }
        public async Task<string> FetchSportsSpecificStory(int interestingNewsStory)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("?api-key=43wDT9yQnT0ilG6lvpGqQA37lzjQ70vG").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            string responseBody = await response.Content.ReadAsStringAsync();
            var parsedBody = JsonConvert.DeserializeObject<JObject>(responseBody);
            var realTimeNews = parsedBody["results"][interestingNewsStory - 1]["abstract"];
            Console.WriteLine(realTimeNews);
            Console.ReadLine();
            return "Complete";
                
        }
    }
}

