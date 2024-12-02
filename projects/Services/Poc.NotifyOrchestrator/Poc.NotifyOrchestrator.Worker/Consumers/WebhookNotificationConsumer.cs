using MassTransit;
using Poc.NotifyMessaging.Library.Event;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces;
using Poc.NotifyOrchestrator.ExternalServices.Factory;

namespace Poc.NotifyOrchestrator.Worker.Consumers
{
    public class WebhookNotificationConsumer(IWebhookEndpointsRepository webhookEndpointsRepository, WebhookClientFactory webhookClientFactory) : IConsumer<PagamentoCreatedEvent>
    {
        private readonly IWebhookEndpointsRepository _webhookEndpointsRepository = webhookEndpointsRepository;
        private readonly WebhookClientFactory _webhookClientFactory = webhookClientFactory;

        public async Task Consume(ConsumeContext<PagamentoCreatedEvent> context)
        {
            var webhooks = await _webhookEndpointsRepository.BuscarPorEvent(typeof(PagamentoCreatedEvent).Name)!;
            var payload = new { EventName = nameof(PagamentoCreatedEvent), Data = context.Message };

            foreach (var webhook in webhooks)
            {
                var webhookClient = _webhookClientFactory.CreateClient(webhook.Endpoint);
                await webhookClient.NotifyAsync(payload);
            }
        }
    }
}
