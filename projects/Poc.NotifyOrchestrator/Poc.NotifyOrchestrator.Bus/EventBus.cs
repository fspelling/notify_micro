using MassTransit;
using Poc.NotifyMessaging.Library;
using Poc.NotifyOrchestrator.Domain.Interfaces.EventBus;

namespace Poc.NotifyOrchestrator.Bus
{
    public class EventBus(IPublishEndpoint publishEndpoint) : IEventBus
    {
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Publish<T>(T message) where T : IMessage
        {
            if (message is null)
                throw new ArgumentNullException(nameof(message));

            await _publishEndpoint.Publish(message);
        }
    }
}
