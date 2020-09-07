using Newtonsoft.Json;

namespace TheMovie.Api.Configuration
{
    public class MovieConfiguration
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }
    }
}
