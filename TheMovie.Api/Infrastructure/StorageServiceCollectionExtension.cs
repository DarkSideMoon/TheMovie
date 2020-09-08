using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using TheMovie.Model.Base;
using TheMovie.Service.Storage;

namespace TheMovie.Api.Infrastructure
{
    public static class StorageServiceCollectionExtension
    {
        public static IServiceCollection AddinMemoryStorage(this IServiceCollection services)
        {
            // Add redis cache
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379"; // TODO: From config
            });

            services.AddSingleton<IStorage<Movie>>(x => new RedisStorage<Movie>(x.GetRequiredService<IDistributedCache>()));
            return services;
        }
    }
}
