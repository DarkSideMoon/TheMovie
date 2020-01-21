using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TheMovie.Api.Mapping;
using TheMovie.Model.Interfaces;
using TheMovie.Model.TMDb;
using TheMovie.Service.Service.Client;
using TheMovie.Service.Service.Find;
using TheMovie.Service.Service.Random;
using TheMovie.Service.Service.Search;
using TheMovie.Service.Service.Settings;

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
            services.AddTransient<IFind, Client>();

            services.AddTransient<IMovieClient, MovieClient>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IRandomService, RandomService>();
            services.AddTransient<IFindService, FindService>();
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
