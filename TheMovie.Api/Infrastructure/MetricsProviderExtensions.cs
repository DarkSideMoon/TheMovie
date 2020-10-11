using App.Metrics;
using Microsoft.Extensions.DependencyInjection;

namespace TheMovie.Api.Infrastructure
{
    public static class MetricsProviderExtensions
    {
        public static void AddMetricsService(this IServiceCollection services)
        {
            var metrics = AppMetrics
                .CreateDefaultBuilder()
                .Build();

            services.AddMetrics(metrics)
                .AddMetricsTrackingMiddleware()
                .AddMetricsReportingHostedService()
                .AddMetricsEndpoints();
        }
    }
}
