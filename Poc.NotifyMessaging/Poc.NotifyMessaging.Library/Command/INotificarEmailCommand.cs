using Poc.NotifyMessaging.Library.Command.Base;

namespace Poc.NotifyMessaging.Library.Command
{
    public interface INotificarEmailCommand : ICommand
    {
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string Template { get; set; }
    }
}
