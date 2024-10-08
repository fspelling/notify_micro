using Microsoft.Extensions.Caching.Distributed;
using Poc.NotifyOrchestrator.Cache.Interfaces.Base;
using System.Text.Json;

namespace Poc.NotifyOrchestrator.Cache.Caches.Base
{
    public abstract class CacheBase<T>(IDistributedCache cache) : ICacheBase<T>
    {
        private readonly IDistributedCache _cache = cache;
        private readonly string _key = typeof(T).Name;

        public async Task<T?> GetCache(string id)
        {
            var json = await _cache.GetAsync($"{_key}:{id}");
            return json is not null ? JsonSerializer.Deserialize<T>(json) : default;
        }

        public async Task RemoveCache(string id)
            => await _cache.RemoveAsync($"{_key}:{id}");

        public async Task SetCache(string id, T value, TimeSpan? expery = null)
        {
            var options = new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expery };

            var json = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync($"{_key}:{id}", json, options);
        }
    }
}
