using Poc.NotifyPublish.Domain.ViewModel.Webhook.Request;

namespace Poc.NotifyPublish.Domain.Interfaces.Service
{
    public interface IWebhookService
    {
        Task Registrar(RegisterRequest request);
    }
}
