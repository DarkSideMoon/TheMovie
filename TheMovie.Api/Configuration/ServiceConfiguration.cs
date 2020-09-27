using Newtonsoft.Json;

namespace TheMovie.Api.Configuration
{
    public class ServiceConfiguration
    {
        [JsonProperty("movie")]
        public MovieConfiguration Movie { get; set; }

        [JsonProperty("openTelemetry")]
        public OpenTelemetryConfiguration OpenTelemetry { get; set; }

        [JsonProperty("redis")]
        public RedisConfiguration Redis { get; set; }
    }
}
