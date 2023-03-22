using Newtonsoft.Json;

namespace NewUpstorm.Domain;

public class WeatherInfo
{
    public long Id { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
}
