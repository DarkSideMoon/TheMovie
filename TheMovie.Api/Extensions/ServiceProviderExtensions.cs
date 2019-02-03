using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheMovie.Model.Infrastructure;
using TheMovie.Model.Interfaces;
using TheMovie.Model.TMDb;

namespace TheMovie.Api.Extensions
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
        public static void AddMovieClientService(this IServiceCollection services, IConfiguration Configuration)
        {
            // Get configuration form json file
            var movieSettings = Configuration.GetSection("MovieSettings").Get<MovieSettings>();

            services.AddTransient<IClient>(x => new Client(movieSettings));
        }
    }
}
