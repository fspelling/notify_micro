using FluentValidation;
using Poc.NotifyPublish.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifyPublish.Service.Validators.Notificacao
{
    public class RealizarPagamentoRequestValidator : AbstractValidator<RealizarPagamentoRequest>
    {
        public RealizarPagamentoRequestValidator()
        {
            RuleFor(request => request.UsuarioID).NotNull().NotEmpty().WithMessage("Usuario id deve ser informado");
            RuleFor(request => request.FormaPagamento).NotNull().NotEmpty().WithMessage("Usuario id deve ser informado");
        }
    }
}
