using Poc.NotifyMessaging.Library;

namespace Poc.NotifyPublish.Domain.Interfaces.EventBus
{
    public interface IEventBus
    {
        Task Publish<T>(T message) where T : IMessage;
    }
}
