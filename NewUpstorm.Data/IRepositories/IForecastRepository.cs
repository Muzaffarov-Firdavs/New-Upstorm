using Newtonsoft.Json.Linq;
using NewUpstorm.Domain.Entities;

namespace NewUpstorm.Data.IRepositories
{
    public interface IForecastRepository
    {
        ValueTask<RootObject> SelectCurrentForecastAsync(string city);
        ValueTask<JToken> SelectWeeklyForecastAsync(string city, string county_code);
    }
}
