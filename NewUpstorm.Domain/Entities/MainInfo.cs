using Newtonsoft.Json;

namespace NewUpstorm.Domain.Entities;

public class MainInfo
{
    public long Id { get; set; }
    [JsonProperty("temp")]
    public float NowTemperature { get; set; }

    [JsonProperty("temp_min")]
    public float NightTemperature { get; set; }

    [JsonProperty("temp_max")]
    public float DayTemperature { get; set; }

    [JsonProperty("pressure")]
    public float Pressure { get; set; }

    [JsonProperty("humidity")]
    public float Humidity { get; set; }
}
