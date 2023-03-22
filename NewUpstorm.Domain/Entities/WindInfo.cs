using Newtonsoft.Json;

namespace NewUpstorm.Domain.Entities
{
    public class WindInfo
    {
        public long Id { get; set; }

        [JsonProperty("speed")]
        public float Speed { get; set; }
    }
}
