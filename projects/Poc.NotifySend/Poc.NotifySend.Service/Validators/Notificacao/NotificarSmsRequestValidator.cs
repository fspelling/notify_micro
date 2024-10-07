using FluentValidation;
using Poc.NotifySend.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifySend.Service.Validators.Notificacao
{
    public class NotificarSmsRequestValidator : NotificarRequestValidator<NotificarSmsRequest>
    {
        public NotificarSmsRequestValidator()
            => RuleFor(request => request.Telefone).NotNull().WithMessage("Telefone nao informado");
    }
}
