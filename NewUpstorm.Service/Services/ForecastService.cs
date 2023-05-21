using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NewUpstorm.Data.IRepositories;
using NewUpstorm.Data.Repositories;
using NewUpstorm.Domain.Entities;
using NewUpstorm.Service.Configurations;
using NewUpstorm.Service.Exceptions;
using NewUpstorm.Service.Interfaces;

namespace NewUpstorm.Service.Services
{
    public class ForecastService : IForecastService
    {
        string path = AppAPISetting.PATH;
        string weeklyPath = AppAPISetting.WEEKLY_PATH;

        public async ValueTask<RootObject> GetCurrentForecastAsync(string city)
        {
            path = path.Replace("Tashkent", city);

            HttpClient client = new HttpClient();
            var response = (await client.GetAsync(path));
            string content = await response.Content.ReadAsStringAsync();
            RootObject weather = JsonConvert.DeserializeObject<RootObject>(content);

            if (weather is null)
                throw new CustomException(401, "API configuration error");

            return weather;
        }

        public async Task<List<RootObject>> GetWeeklyForecstsAsync(string city, string countryCode)
        {
            string path = weeklyPath.Replace("Tashkent", city).Replace("uz", countryCode);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(path);
                var content = await response.Content.ReadAsStringAsync();

                var data = JObject.Parse(content);
                var forecasts = data["list"];

                if (forecasts == null || !forecasts.Any())
                    throw new CustomException(401, "API configuration error");

                var results = forecasts.ToObject<List<RootObject>>();
                return results;
            }
        }
    }
}
