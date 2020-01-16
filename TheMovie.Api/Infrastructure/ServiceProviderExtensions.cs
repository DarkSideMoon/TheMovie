using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TheMovie.Api.Mapping;
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

        /// <summary>
        /// Add automaper service
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutomapperService(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(x => 
            {
                x.AddProfile(new RequestProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
