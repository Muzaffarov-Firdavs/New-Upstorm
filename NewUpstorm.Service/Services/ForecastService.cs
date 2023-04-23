using Newtonsoft.Json.Linq;
using NewUpstorm.Data.IRepositories;
using NewUpstorm.Data.Repositories;
using NewUpstorm.Domain.Entities;
using NewUpstorm.Service.Helpers;
using NewUpstorm.Service.Interfaces;

namespace NewUpstorm.Service.Services
{
    public class ForecastService : IForecastService
    {
        private readonly IForecastRepository forecastService = new ForecastRepository();

        public async ValueTask<Response<RootObject>> GetCurrentForecastAsync(string city)
        {
            RootObject weather = await forecastService.SelectCurrentForecastAsync(city);
            if (weather is null)
                return new Response<RootObject>
                {
                    StatusCode = 404,
                    Message = "Not found"
                };

            return new Response<RootObject>
            {
                StatusCode = 200,
                Message = "Success",
                Value = weather
            };
        }

        public async ValueTask<Response<JToken>> GetWeeklyForecstsAsync(string city, string countryCode)
        {
            JToken forecasts = await forecastService.SelectWeeklyForecastAsync(city, countryCode);
            if (forecasts.Any())
                return new Response<JToken>
                {
                    StatusCode = 404,
                    Message = "Not found",
                };

            return new Response<JToken>
            {
                StatusCode = 200,
                Message = "Success",
                Value = forecasts
            };
        }
    }
}
