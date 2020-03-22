﻿using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace TheMovie.Service.Storage
{
    public class RedisStorage<TItem> : IStorage<TItem>
    {
        private readonly IDistributedCache _redisCache;

        public RedisStorage(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<TItem> GetorSet(string key, TItem item, MemoryDistributedCacheOptions entryOptions = null)
        {
            var byteArrayObj = await _redisCache.GetAsync(key);

            if (byteArrayObj != null && byteArrayObj.Length > 0)
            {
                var stringObj = Encoding.UTF8.GetString(byteArrayObj);
                return JsonConvert.DeserializeObject<TItem>(stringObj);
            }

            var serializedStringObj = JsonConvert.SerializeObject(item);
            var byteArray = Encoding.UTF8.GetBytes(serializedStringObj);

            await _redisCache.SetAsync(key, byteArray);
            return item;
        }

        public async Task<TItem> Get(string key, MemoryDistributedCacheOptions entryOptions = null)
        {
            var stringObj = await _redisCache.GetStringAsync(key);
            if (!string.IsNullOrEmpty(stringObj))
            {
                return JsonConvert.DeserializeObject<TItem>(stringObj);
            }

            return default;
        }

        public async Task Set(string key, TItem item, MemoryDistributedCacheOptions entryOptions = null) 
        {
            var serializedStringObj = JsonConvert.SerializeObject(item);
            var byteArray = Encoding.UTF8.GetBytes(serializedStringObj);

            await _redisCache.SetAsync(key, byteArray); 
        }

        #region Redis Get and Save data as string

        //public async Task<TItem> GetorSet(string key, TItem item, MemoryDistributedCacheOptions entryOptions = null)
        //{
        //    var stringObj = await _redisCache.GetStringAsync(key);

        //    if (!string.IsNullOrEmpty(stringObj))
        //    {
        //        return JsonConvert.DeserializeObject<TItem>(stringObj);
        //    }

        //    await _redisCache.SetStringAsync(key, JsonConvert.SerializeObject(item));
        //    return item;
        //}

        //public async Task<TItem> Get(string key, MemoryDistributedCacheOptions entryOptions = null)
        //{
        //    var stringObj = await _redisCache.GetStringAsync(key);
        //    if (!string.IsNullOrEmpty(stringObj))
        //    {
        //        return JsonConvert.DeserializeObject<TItem>(stringObj);
        //    }

        //    return default;
        //}

        //public async Task Set(string key, TItem item, MemoryDistributedCacheOptions entryOptions = null) => await _redisCache.SetStringAsync(key, JsonConvert.SerializeObject(item));
        #endregion
    }
}
