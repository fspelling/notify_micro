using Poc.NotifyMessaging.Library.Command.Base;

namespace Poc.NotifyMessaging.Library.Command
{
    public class WebhookNotificarCommand : ICommand
    {
        public required string Event { get; set; }
    }
}
