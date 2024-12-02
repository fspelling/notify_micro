using FluentValidation;
using Poc.NotifyMessaging.Library.Event;
using Poc.NotifyPublish.Domain.Exceptions;
using Poc.NotifyPublish.Domain.Extensions;
using Poc.NotifyPublish.Domain.Interfaces.EventBus;
using Poc.NotifyPublish.Domain.Interfaces.Service;
using Poc.NotifyPublish.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifyPublish.Service.Services
{
    public class PagamentoService(IValidator<RealizarPagamentoRequest> validatorNotificarRequest, IEventBus eventBus) : IPagamentoService
    {
        private readonly IValidator<RealizarPagamentoRequest> _validatorNotificarRequest = validatorNotificarRequest;
        private readonly IEventBus _eventBus = eventBus;

        public async Task RealizarPagamento(RealizarPagamentoRequest request)
        {
            await _validatorNotificarRequest.ValidarRequestException<RealizarPagamentoRequest, PagamentoException>(request);

            await _eventBus.Publish(new PagamentoCreatedEvent
            {
                UsuarioId = request.UsuarioID,
                FormaPagamento = request.FormaPagamento.ToString()
            });
        }
    }
}
