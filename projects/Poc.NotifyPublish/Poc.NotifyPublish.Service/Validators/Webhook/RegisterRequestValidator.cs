using FluentValidation;
using Poc.NotifyPublish.Domain.ViewModel.Webhook.Request;

namespace Poc.NotifyPublish.Service.Validators.Webhook
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(request => request.Endpoint).NotNull().NotEmpty().WithMessage("Endpoint deve ser informado");
            RuleFor(request => request.Event).NotNull().NotEmpty().WithMessage("Event deve ser informado");
        }
    }
}
