using Newtonsoft.Json;

namespace TheMovie.Api.Configuration
{
    public class OpenTelemetryConfiguration
    {
        [JsonProperty("exporter")]
        public string Exporter { get; set; }

        [JsonProperty("jaeger")]
        public JaegerConfiguration Jaeger { get; set; }

        [JsonProperty("zipkin")]
        public ZipkinConfiguration Zipkin { get; set; }
    }
}
