using FluentValidation;
using Poc.NotifyPublish.Domain.Entity;
using Poc.NotifyPublish.Domain.Exceptions;
using Poc.NotifyPublish.Domain.Extensions;
using Poc.NotifyPublish.Domain.Interfaces.Repository;
using Poc.NotifyPublish.Domain.Interfaces.Service;
using Poc.NotifyPublish.Domain.ViewModel.Webhook.Request;

namespace Poc.NotifyPublish.Service.Services
{
    public class WebhookService(IValidator<RegisterRequest> validatorRegisterRequest, IWebhookEndpointsRepository webhookEndpointsRepository) : IWebhookService
    {
        private readonly IValidator<RegisterRequest> _validatorRegisterRequest = validatorRegisterRequest;
        private readonly IWebhookEndpointsRepository _webhookEndpointsRepository = webhookEndpointsRepository;

        public async Task Registrar(RegisterRequest request)
        {
            await _validatorRegisterRequest.ValidarRequestException<RegisterRequest, WebhookException>(request);

            await _webhookEndpointsRepository.Inserir(new WebhookEndpoints
            {
                Endpoint = request.Endpoint,
                Event = request.Event,
                Ativo = true,
                DataCriacao = DateTime.Now
            });
        }
    }
}
