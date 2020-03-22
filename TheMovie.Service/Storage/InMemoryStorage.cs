using Microsoft.Extensions.Caching.Memory;
using System;

namespace TheMovie.Service.Storage
{
    public class InMemoryStorage<TItem> : IStorage<TItem>
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryStorage(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public TItem GetorSet(string key, TItem item, MemoryCacheEntryOptions entryOptions = null)
        {
            if(_memoryCache.TryGetValue<TItem>(key, out var value))
            {
                return value;
            }

            return _memoryCache.Set(key, item);
        }

        public TItem Get(string key, MemoryCacheEntryOptions entryOptions = null) => _memoryCache.Get<TItem>(key);

        public void Set(string key, TItem item, MemoryCacheEntryOptions entryOptions = null) => _memoryCache.Set(key, item, entryOptions);
    }
}
