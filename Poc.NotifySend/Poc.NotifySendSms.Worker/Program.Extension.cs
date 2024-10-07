using FluentValidation;
using Poc.NotifySend.Domain.ViewModel.Notificacao.Request;
using Poc.NotifySend.Service.Interfaces;
using Poc.NotifySend.Service.Services;
using Poc.NotifySend.Service.Validators.Notificacao;
using Poc.NotifySendSms.Worker.Config;

namespace Poc.NotifySendSms.Worker
{
    public static class ProgramExtension
    {
        public static void ConfigureInjectDependency(this IServiceCollection services)
            => services.AddScoped<INotificacaoService<NotificarSmsRequest>, NotificacaoSmsService>();

        public static void ConfigureValidators(this IServiceCollection services)
            => services.AddScoped<IValidator<NotificarSmsRequest>, NotificarSmsRequestValidator>();

        public static void ConfigureRabbitmq(this IServiceCollection services)
            => RabbitmqConfig.Configure(services);
    }
}
