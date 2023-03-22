using Newtonsoft.Json;

namespace NewUpstorm.Domain.Entities
{
    public class RootObject
    {
        public long Id { get; set; }

        [JsonProperty("main")]
        public MainInfo MainInfo { get; set; }

        [JsonProperty("weather")]
        public WeatherInfo[] WeatherInfo { get; set; }

        [JsonProperty("sys")]
        public SunTime SunTime { get; set; }

        [JsonProperty("wind")]
        public WindInfo WindInfo { get; set; }

    }
}
