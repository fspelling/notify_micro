using FluentValidation;
using MassTransit;
using Poc.NotifyMessaging.Library.Event;
using Poc.NotifyPublish.Domain.Exceptions;
using Poc.NotifyPublish.Domain.Extensions;
using Poc.NotifyPublish.Domain.Interfaces.Service;
using Poc.NotifyPublish.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifyPublish.Service.Services
{
    public class PagamentoService(IValidator<RealizarPagamentoRequest> validatorNotificarRequest, IPublishEndpoint publishEndpoint) : IPagamentoService
    {
        private readonly IValidator<RealizarPagamentoRequest> _validatorNotificarRequest = validatorNotificarRequest;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task RealizarPagamento(RealizarPagamentoRequest request)
        {
            await _validatorNotificarRequest.ValidarRequestException<RealizarPagamentoRequest, PagamentoException>(request);

            await _publishEndpoint.Publish<IPagamentoCreatedEvent>(new
            {
                UsuarioId = request.UsuarioID,
                FormaPagamento = request.FormaPagamento.ToString(),
                DataCriacao = DateTime.Now
            });
        }
    }
}
