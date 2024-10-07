using FluentValidation;
using Poc.NotifySend.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifySend.Service.Validators.Notificacao
{
    public class NotificarRequestValidator<T> : AbstractValidator<T> where T : NotificarRequest
    {
        public NotificarRequestValidator()
        {
            RuleFor(request => request.NomeUsuario).NotNull().WithMessage("Usuario nao informado");
            RuleFor(request => request.Template).NotNull().WithMessage("Template nao informado");
        }
    }
}
