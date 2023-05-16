using Newtonsoft.Json.Linq;
using NewUpstorm.Domain.Entities;

namespace NewUpstorm.Service.Interfaces
{
    public interface IForecastService
    {
        ValueTask<RootObject> GetCurrentForecastAsync(string city);
        Task<List<RootObject>> GetWeeklyForecstsAsync(string city, string countryCode);
    }
}
