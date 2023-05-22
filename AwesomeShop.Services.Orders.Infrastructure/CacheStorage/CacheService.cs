using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace AwesomeShop.Services.Orders.Infrastructure.CacheStorage
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var objectString = await _cache.GetStringAsync(key);

            if(string.IsNullOrEmpty(objectString)){
                Console.WriteLine($"Cache key {key} notFound!");

                return default(T);
            }

            Console.WriteLine($"Cache key found for key {key}");

            return JsonConvert.DeserializeObject<T>(objectString);
        }

        public async Task SetAsync<T>(string key, T data)
        {
            
            var memoryCacheEntryOptions =  new DistributedCacheEntryOptions {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(36000),
                SlidingExpiration = TimeSpan.FromSeconds(1200)
            };

            var objectString = JsonConvert.SerializeObject(data);

            Console.WriteLine($"Cache key {key}");

            await _cache.SetStringAsync(key, objectString, memoryCacheEntryOptions);
        }
    }
}