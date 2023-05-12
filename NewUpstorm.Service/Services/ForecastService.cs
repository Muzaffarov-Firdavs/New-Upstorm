using Newtonsoft.Json.Linq;
using NewUpstorm.Data.IRepositories;
using NewUpstorm.Data.Repositories;
using NewUpstorm.Domain.Entities;
using NewUpstorm.Service.Interfaces;

namespace NewUpstorm.Service.Services
{
    public class ForecastService : IForecastService
    {
        private readonly IForecastRepository forecastService = new ForecastRepository();

        public async ValueTask<RootObject> GetCurrentForecastAsync(string city)
        {
            RootObject weather = await forecastService.SelectCurrentForecastAsync(city);
            if (weather is null)
                return new RootObject();

            return new RootObject();
        }

        public async ValueTask<JToken> GetWeeklyForecstsAsync(string city, string countryCode)
        {
            JToken forecasts = await forecastService.SelectWeeklyForecastAsync(city, countryCode);
            if (forecasts.Any())
                return null;

            return forecasts;
        }
    }
}
