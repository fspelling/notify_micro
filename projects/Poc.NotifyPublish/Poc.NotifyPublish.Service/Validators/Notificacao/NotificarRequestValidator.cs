using FluentValidation;
using Poc.NotifyPublish.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifyPublish.Service.Validators.Notificacao
{
    public class NotificarRequestValidator : AbstractValidator<NotificarRequest>
    {
        public NotificarRequestValidator()
        {
            RuleFor(request => request.UsuarioID).NotNull().NotEmpty().WithMessage("Usuario id deve ser informado");
        }
    }
}
