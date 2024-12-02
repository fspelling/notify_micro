using FluentValidation;
using Poc.NotifyOrchestrator.Domain.Exceptions;
using Poc.NotifyOrchestrator.Domain.Extensions;
using Poc.NotifyOrchestrator.Domain.ViewModel.Pagamento.Request;
using Poc.NotifyOrchestrator.Service.Interfaces;

namespace Poc.NotifyOrchestrator.Service.Services
{
    public class PagamentoService(IValidator<RealizarPosPagamentoRequest> notificarRequestValidator) : IPagamentoService
    {
        private readonly IValidator<RealizarPosPagamentoRequest> _notificarRequestValidator = notificarRequestValidator;

        public async Task RealizarPosPagamento(RealizarPosPagamentoRequest request)
        {
            await _notificarRequestValidator.ValidarRequestException<RealizarPosPagamentoRequest, PagamentoException>(request);

            Console.Write($"Simulando o POS pagamento ja realizado do usuario: {request.UsuarioId}, pela forma de pagamento: {request.FormaPagamento}");
        }
    }
}
