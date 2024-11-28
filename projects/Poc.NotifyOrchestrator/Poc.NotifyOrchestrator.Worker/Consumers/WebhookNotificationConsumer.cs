using MassTransit;
using Poc.NotifyMessaging.Library.Event;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces;

namespace Poc.NotifyOrchestrator.Worker.Consumers
{
    public class WebhookNotificationConsumer(IWebhookEndpointsRepository webhookEndpointsRepository) : IConsumer<PagamentoCreatedEvent>
    {
        private readonly IWebhookEndpointsRepository _webhookEndpointsRepository = webhookEndpointsRepository;

        public async Task Consume(ConsumeContext<PagamentoCreatedEvent> context)
        {
            var webhooks = await _webhookEndpointsRepository.BuscarPorEvent(typeof(PagamentoCreatedEvent).Name)!;

            // TODO: realizar chamada refit para notificar os endpoints clients
            foreach (var webhook in webhooks)
            {
            }
        }
    }
}
