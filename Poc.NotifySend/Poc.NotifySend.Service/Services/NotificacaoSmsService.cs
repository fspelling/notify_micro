using Poc.NotifySend.Domain.ViewModel.Notificacao.Request;
using Poc.NotifySend.Service.Interfaces;

namespace Poc.NotifySend.Service.Services
{
    public class NotificacaoSmsService : INotificacaoService<NotificarSmsRequest>
    {
        public Task Notificar(NotificarSmsRequest request)
        {
            Console.WriteLine($"Sms do nuemro {request.Telefone} enviado com sucesso.");
            return Task.CompletedTask;
        }
    }
}
