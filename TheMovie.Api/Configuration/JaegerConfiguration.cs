using Newtonsoft.Json;

namespace TheMovie.Api.Configuration
{
    public class JaegerConfiguration
    {
        [JsonProperty("ServiceName")]
        public string ServiceName { get; set; }
        
        [JsonProperty("Host")]
        public string Host { get; set; }

        [JsonProperty("Port")]
        public int Port { get; set; }
    }
}
