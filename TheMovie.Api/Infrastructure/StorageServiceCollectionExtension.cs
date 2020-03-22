using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using TheMovie.Model.Base;
using TheMovie.Service.Storage;

namespace TheMovie.Api.Infrastructure
{
    public static class StorageServiceCollectionExtension
    {
        public static IServiceCollection AddinMemoryStorage(this IServiceCollection services)
        {
            // Add in memory cache
            services.AddMemoryCache();

            var memoryCache = services.BuildServiceProvider().GetRequiredService<IMemoryCache>();

            services.AddSingleton<IStorage<Movie>>(x => new InMemoryStorage<Movie>(memoryCache));
            return services;
        }
    }
}
