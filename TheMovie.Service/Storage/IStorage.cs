using Microsoft.Extensions.Caching.Memory;

namespace TheMovie.Service.Storage
{
    public interface IStorage<TItem>
    {
        void Set(string key, TItem item, MemoryCacheEntryOptions entryOptions = default);

        TItem Get(string key, MemoryCacheEntryOptions entryOptions = default);

        TItem GetorSet(string key, TItem item, MemoryCacheEntryOptions entryOptions = default);
    }
}
