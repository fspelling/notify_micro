using Poc.NotifyOrchestrator.Domain.Entity;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces.Base;

namespace Poc.NotifyOrchestrator.EntityFramework.Interfaces
{
    public interface IWebhookEndpointsRepository : IRepositoryBase<WebhookEndpoints>
    {
        Task<List<WebhookEndpoints>> BuscarPorEvent(string @event);
    }
}
