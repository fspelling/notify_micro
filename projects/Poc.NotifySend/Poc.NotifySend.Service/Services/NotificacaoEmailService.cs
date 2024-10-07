using Poc.NotifySend.Domain.ViewModel.Notificacao.Request;
using Poc.NotifySend.Service.Interfaces;

namespace Poc.NotifySend.Service.Services
{
    public class NotificacaoEmailService : INotificacaoService<NotificarEmailRequest>
    {
        public Task Notificar(NotificarEmailRequest request)
        {
            Console.WriteLine($"Email {request.Email} enviado com sucesso.");
            return Task.CompletedTask;
        }
    }
}
