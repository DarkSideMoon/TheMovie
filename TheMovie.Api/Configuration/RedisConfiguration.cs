using Newtonsoft.Json;

namespace TheMovie.Api.Configuration
{
    public class RedisConfiguration
    {
        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }
    }
}
