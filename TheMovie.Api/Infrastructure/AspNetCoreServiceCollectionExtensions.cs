using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TheMovie.Api.HealthChecks;
using TheMovie.Service.Service.Client;

namespace TheMovie.Api.Infrastructure
{
    public static class AspNetCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpClientService(this IServiceCollection services)
        {
            services.AddHttpClient<IMovieClient, MovieClient>();
            return services;
        }

        public static IServiceCollection AddHealthChecksService(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck("base", () => HealthCheckResult.Healthy("Ok"))
                .AddCheck<RedisHealthCheck>("redisHealth", tags: new[] { "redis" });

            return services;
        }
    }
}
