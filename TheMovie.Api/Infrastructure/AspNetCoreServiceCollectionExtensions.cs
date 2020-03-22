using Microsoft.Extensions.DependencyInjection;
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
    }
}
