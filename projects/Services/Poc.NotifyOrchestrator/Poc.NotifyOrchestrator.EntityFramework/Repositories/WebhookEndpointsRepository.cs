using Microsoft.EntityFrameworkCore;
using Poc.NotifyOrchestrator.Domain.Entity;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces;
using Poc.NotifyOrchestrator.EntityFramework.Repositories.Base;

namespace Poc.NotifyOrchestrator.EntityFramework.Repositories
{
    public class WebhookEndpointsRepository(NotificacaoDbContext dbContext) : RepositoryBase<WebhookEndpoints>(dbContext), IWebhookEndpointsRepository
    {
        public async Task<List<WebhookEndpoints>> BuscarPorEvent(string @event)
            => await dbContext.Set<WebhookEndpoints>().Where(e => e.Event == @event).ToListAsync();
    }
}
