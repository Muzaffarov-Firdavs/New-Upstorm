using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NewUpstorm.Data.IRepositories;
using NewUpstorm.Data.Repositories;
using NewUpstorm.Domain.Entities;
using System.IO;

namespace NewUpstorm.Presentation;

internal class Program
{
    static async Task Main(string[] args)
    {

        //IForecastRepository repo = new ForecastRepository();

        //var fore = await repo.SelectCurrentForecastAsync("London");

        //string path = "https://pro.openweathermap.org/data/2.5/forecast/hourly?q=Tashkent&appid=c45d8b9a884e5ff945eb105a164c78e7";

        //HttpClient client = new HttpClient();
        //var response = (await client.GetAsync(path));
        //string content = await response.Content.ReadAsStringAsync();

        //var data = JsonConvert.DeserializeObject<IEnumerable<RootObject>>(content);


        // Replace YOUR_API_KEY with your actual API key
        string apiKey = "YOUR_API_KEY";
        string url = $"https://api.openweathermap.org/data/2.5/forecast?q=Tashkent,uz&appid=c45d8b9a884e5ff945eb105a164c78e7";

        using (var httpClient = new HttpClient())
        {
            var response = httpClient.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            // Parse the response JSON
            var data = JObject.Parse(content);

            // Extract the list of weather forecasts
            var forecasts = data["list"];

            //IEnumerable<RootObject> res = JsonConvert.DeserializeObject<IEnumerable<RootObject>>(forecasts);

            // Loop through the forecasts and display the data
            foreach (var forecast in forecasts)
            {
                var date = forecast["dt_txt"];
                var temp = forecast["main"]["temp"];
                var humidity = forecast["main"]["humidity"];
                var description = forecast["weather"][0]["description"];

                Console.WriteLine($"Date: {date}\nTemperature: {temp}\nHumidity: {humidity}\nDescription: {description}\n");
            }
        }
        


    }
}