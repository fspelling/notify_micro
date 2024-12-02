using Poc.NotifyPublish.Data.Repositories.Base;
using Poc.NotifyPublish.Domain.Entity;
using Poc.NotifyPublish.Domain.Interfaces.Repository;

namespace Poc.NotifyPublish.Data.Repositories
{
    public sealed class WebhookEndpointsRepository(NotificacaoDbContext dbContext) : RepositoryBase<WebhookEndpoints>(dbContext), IWebhookEndpointsRepository
    {
    }
}
