using Poc.NotifyMessaging.Library;

namespace Poc.NotifyOrchestrator.Domain.Interfaces.EventBus
{
    public interface IEventBus
    {
        Task Publish<T>(T message) where T : IMessage;
    }
}
