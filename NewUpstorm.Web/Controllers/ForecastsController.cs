using Microsoft.AspNetCore.Mvc;
using NewUpstorm.Service.Interfaces;

namespace NewUpstorm.Web.Controllers
{
    public class ForecastsController : BaseController
    {
        private readonly IForecastService forecastService;
        public ForecastsController(IForecastService forecastService)
        {
            this.forecastService = forecastService;
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentAsync(string city)
            => Ok(new
            {
                Code = 200,
                Message = "Success",
                Data = await this.forecastService.GetCurrentForecastAsync(city)
            });

        [HttpGet("weekly")]
        public async Task<IActionResult> GetWeeklyAsync([FromQuery] string city, string countryCode)
        => 
            Ok(new
        {
            Code = 200,
            Message = "Success",
            Data = await this.forecastService.GetWeeklyForecstsAsync(city, countryCode)
        });
    }
}
