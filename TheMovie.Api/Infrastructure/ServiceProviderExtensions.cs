using Microsoft.Extensions.DependencyInjection;
using TheMovie.Model.Interfaces;
using TheMovie.Model.TMDb;

namespace TheMovie.Api.Infrastructure
{
    /// <summary>
    /// Provie extensions for DI
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Add movie client service through DI
        /// </summary>
        /// <param name="services"></param>
        public static void AddMovieClientService(this IServiceCollection services)
        {
            services.AddTransient<IClient, Client>();
        }
    }
}
