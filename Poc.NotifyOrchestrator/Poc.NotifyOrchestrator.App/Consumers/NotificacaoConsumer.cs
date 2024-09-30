using MassTransit;
using Poc.NotifyMessaging.Library.Event;

namespace Poc.NotifyOrchestrator.App.Consumers
{
    public class NotificacaoConsumer : IConsumer<INotificacaoCreated>
    {
        public Task Consume(ConsumeContext<INotificacaoCreated> context)
        {
            return Task.CompletedTask;
        }
    }
}
