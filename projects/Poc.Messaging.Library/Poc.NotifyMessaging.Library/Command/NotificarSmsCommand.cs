using Poc.NotifyMessaging.Library.Command.Base;

namespace Poc.NotifyMessaging.Library.Command
{
    public class NotificarSmsCommand : ICommand
    {
        public string? NomeUsuario { get; set; }
        public string? SmsUsuario { get; set; }
        public string? Template { get; set; }
    }
}
