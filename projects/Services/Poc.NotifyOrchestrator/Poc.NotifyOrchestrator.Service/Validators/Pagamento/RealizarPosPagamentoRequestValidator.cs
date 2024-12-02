using FluentValidation;
using Poc.NotifyOrchestrator.Domain.ViewModel.Pagamento.Request;

namespace Poc.NotifyOrchestrator.Service.Validators.Notificacao
{
    public class RealizarPosPagamentoRequestValidator : AbstractValidator<RealizarPosPagamentoRequest>
    {
        public RealizarPosPagamentoRequestValidator()
        {
            RuleFor(request => request.UsuarioId).NotNull().WithMessage("Usuario id nao informado");
            RuleFor(request => request.FormaPagamento).NotNull().WithMessage("Forma de pagamento nao informado");
        }
    }
}
