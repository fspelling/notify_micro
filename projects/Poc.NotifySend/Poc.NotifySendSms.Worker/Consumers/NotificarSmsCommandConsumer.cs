using MassTransit;
using Poc.NotifyMessaging.Library.Command;
using Poc.NotifySend.Domain.ViewModel.Notificacao.Request;
using Poc.NotifySend.Service.Interfaces;

namespace Poc.NotifySendSms.Worker.Consumers
{
    public class NotificarSmsCommandConsumer(INotificacaoService<NotificarSmsRequest> notificacaoService) : IConsumer<INotificarSmsCommand>
    {
        private readonly INotificacaoService<NotificarSmsRequest> _notificacaoService = notificacaoService;

        public async Task Consume(ConsumeContext<INotificarSmsCommand> context)
        {
            var request = new NotificarSmsRequest
            {
                NomeUsuario = context.Message.NomeUsuario,
                Telefone = context.Message.SmsUsuario,
                Template = context.Message.Template,
            };

            await _notificacaoService.Notificar(request);
        }
    }
}
