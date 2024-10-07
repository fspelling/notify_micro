using FluentValidation;
using Poc.NotifySend.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifySend.Service.Validators.Notificacao
{
    public class NotificarEmailRequestValidator : NotificarRequestValidator<NotificarEmailRequest>
    {
        public NotificarEmailRequestValidator()
            => RuleFor(request => request.Email).NotNull().WithMessage("Email nao informado");
    }
}
