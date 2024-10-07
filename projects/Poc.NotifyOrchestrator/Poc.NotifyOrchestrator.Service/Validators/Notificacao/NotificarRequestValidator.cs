using FluentValidation;
using Poc.NotifyOrchestrator.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifyOrchestrator.Service.Validators.Notificacao
{
    public class NotificarRequestValidator : AbstractValidator<NotificarRequest>
    {
        public NotificarRequestValidator()
        {
            RuleFor(request => request.UsuarioId).NotNull().WithMessage("Usuario id nao informado");
        }
    }
}
