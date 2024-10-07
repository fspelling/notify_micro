using FluentValidation;
using Poc.NotifySend.Domain.ViewModel.Notificacao.Request;
using Poc.NotifySend.Service.Interfaces;
using Poc.NotifySend.Service.Services;
using Poc.NotifySend.Service.Validators.Notificacao;
using Poc.NotifySendEmail.Worker.Config;

namespace Poc.NotifySendEmail.Worker
{
    public static class ProgramExtension
    {
        public static void ConfigureInjectDependency(this IServiceCollection services)
            => services.AddScoped<INotificacaoService<NotificarEmailRequest>, NotificacaoEmailService>();

        public static void ConfigureValidators(this IServiceCollection services)
            => services.AddScoped<IValidator<NotificarEmailRequest>, NotificarEmailRequestValidator>();

        public static void ConfigureRabbitmq(this IServiceCollection services)
            => RabbitmqConfig.Configure(services);
    }
}
