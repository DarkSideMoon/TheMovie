using Newtonsoft.Json;

namespace TheMovie.Api.Configuration
{
    public class ZipkinConfiguration
    {
        [JsonProperty("ServiceName")]
        public string ServiceName { get; set; }

        [JsonProperty("Endpoint")]
        public string Endpoint { get; set; }
    }
}
