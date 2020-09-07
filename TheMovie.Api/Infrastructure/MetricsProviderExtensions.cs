using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using System;
using TheMovie.Api.Configuration;

namespace TheMovie.Api.Infrastructure
{
    public static class MetricsProviderExtensions
    {
        /// <summary>
        /// Add open telemetry dependecies
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddOpenTelemetryService(this IServiceCollection services, ServiceConfiguration configuration)
        {
            // Switch between Zipkin/Jaeger by setting UseExporter in appsettings.json. By default using console
            switch (configuration.OpenTelemetry.Exporter)
            {
                case "jaeger":
                    services.AddOpenTelemetry((builder) => builder
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .UseJaegerExporter(o =>
                        {
                            o.ServiceName = configuration.OpenTelemetry.Jaeger.ServiceName;
                            o.AgentHost = configuration.OpenTelemetry.Jaeger.Host;
                            o.AgentPort = configuration.OpenTelemetry.Jaeger.Port;
                        }));
                    break;
                case "zipkin":
                    services.AddOpenTelemetry((builder) => builder
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .UseZipkinExporter(o =>
                        {
                            o.ServiceName = configuration.OpenTelemetry.Zipkin.ServiceName;
                            o.Endpoint = new Uri(configuration.OpenTelemetry.Zipkin.Endpoint);
                        }));
                    break;
                default:
                    services.AddOpenTelemetry((builder) => builder
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .UseConsoleExporter());
                    break;
            }
        }
    }
}
