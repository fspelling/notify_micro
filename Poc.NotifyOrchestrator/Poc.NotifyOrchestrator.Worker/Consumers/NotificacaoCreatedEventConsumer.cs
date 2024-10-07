using MassTransit;
using Poc.NotifyMessaging.Library.Event;
using Poc.NotifyOrchestrator.Domain.ViewModel.Notificacao.Request;
using Poc.NotifyOrchestrator.Service.Interfaces;

namespace Poc.NotifyOrchestrator.Worker.Consumers
{
    public class NotificacaoCreatedEventConsumer(INotificacaoService notificacaoService) : IConsumer<IPagamentoCreatedEvent>
    {
        private readonly INotificacaoService _notificacaoService = notificacaoService;

        public async Task Consume(ConsumeContext<IPagamentoCreatedEvent> context)
        {
            var message = context.Message;
            await _notificacaoService.Notificar(new NotificarRequest { UsuarioId = message.UsuarioId });
        }
    }
}
