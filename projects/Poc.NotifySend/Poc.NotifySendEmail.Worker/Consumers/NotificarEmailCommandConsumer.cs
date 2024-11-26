using MassTransit;
using Poc.NotifyMessaging.Library.Command;
using Poc.NotifySend.Domain.ViewModel.Notificacao.Request;
using Poc.NotifySend.Service.Interfaces;

namespace Poc.NotifySendEmail.Worker.Consumers
{
    public class NotificarEmailCommandConsumer(INotificacaoService<NotificarEmailRequest> notificacaoService) : IConsumer<NotificarEmailCommand>
    {
        private readonly INotificacaoService<NotificarEmailRequest> _notificacaoService = notificacaoService;

        public async Task Consume(ConsumeContext<NotificarEmailCommand> context)
        {
            var request = new NotificarEmailRequest
            {
                NomeUsuario = context.Message.NomeUsuario!,
                Email = context.Message.EmailUsuario!,
                Template = context.Message.Template!,
            };

            await _notificacaoService.Notificar(request);
        }
    }
}
