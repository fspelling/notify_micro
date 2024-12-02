using Microsoft.Extensions.Caching.Distributed;
using Poc.NotifyOrchestrator.Cache.Caches.Base;
using Poc.NotifyOrchestrator.Cache.Interfaces;
using Poc.NotifyOrchestrator.Cache.ModelCache;

namespace Poc.NotifyOrchestrator.Cache.Caches
{
    public class UsuarioNotificacaoCache(IDistributedCache cache) : CacheBase<UsuarioNotificacao>(cache), IUsuarioNotificacaoCache
    {
    }
}
