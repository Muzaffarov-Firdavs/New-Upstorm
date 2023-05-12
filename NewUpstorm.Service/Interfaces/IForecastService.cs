using Newtonsoft.Json.Linq;
using NewUpstorm.Domain.Entities;

namespace NewUpstorm.Service.Interfaces
{
    public interface IForecastService
    {
        ValueTask<RootObject> GetCurrentForecastAsync(string city);
        ValueTask<JToken> GetWeeklyForecstsAsync(string city, string countryCode);
    }
}
