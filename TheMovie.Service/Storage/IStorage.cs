using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace TheMovie.Service.Storage
{
    public interface IStorage<TItem>
    {
        Task Set(string key, TItem item, MemoryDistributedCacheOptions entryOptions = default);

        Task<TItem> Get(string key, MemoryDistributedCacheOptions entryOptions = default);

        Task<TItem> GetorSet(string key, TItem item, MemoryDistributedCacheOptions entryOptions = default);
    }
}
