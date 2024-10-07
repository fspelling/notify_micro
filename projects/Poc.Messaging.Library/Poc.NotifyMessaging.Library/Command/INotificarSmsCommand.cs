using Poc.NotifyMessaging.Library.Command.Base;

namespace Poc.NotifyMessaging.Library.Command
{
    public interface INotificarSmsCommand : ICommand
    {
        public string NomeUsuario { get; set; }
        public string SmsUsuario { get; set; }
        public string Template { get; set; }
    }
}
