using Newtonsoft.Json;

namespace NewUpstorm.Domain.Entities
{
    public class SunTime
    {
        public long Id { get; set; }

        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty("sunset")]
        public int Sunset { get; set; }
    }
}
