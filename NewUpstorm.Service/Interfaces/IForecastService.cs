using Newtonsoft.Json.Linq;
using NewUpstorm.Domain.Entities;
using NewUpstorm.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUpstorm.Service.Interfaces
{
    public interface IForecastService
    {
        ValueTask<Response<RootObject>> GetCurrentForecastAsync(string city);
        ValueTask<Response<JToken>> GetWeeklyForecstsAsync(string city, string countryCode);
    }
}
