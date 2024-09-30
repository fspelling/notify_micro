using FluentValidation;
using MassTransit;
using Poc.NotifyMessaging.Library.Event;
using Poc.NotifyPublish.Domain.Exceptions;
using Poc.NotifyPublish.Domain.Extensions;
using Poc.NotifyPublish.Domain.Interfaces.Service;
using Poc.NotifyPublish.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifyPublish.Service.Services
{
    public class NotificacaoService(IValidator<NotificarRequest> validatorNotificarRequest, IPublishEndpoint publishEndpoint) : INotificacaoService
    {
        private readonly IValidator<NotificarRequest> _validatorNotificarRequest = validatorNotificarRequest;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Notificar(NotificarRequest request)
        {
            await _validatorNotificarRequest.ValidarRequestException<NotificarRequest, NotificacaoException>(request);

            await _publishEndpoint.Publish<INotificacaoCreated>(new
            {
                UsuarioId = request.UsuarioID,
                DataCriacao = DateTime.Now
            });
        }
    }
}
