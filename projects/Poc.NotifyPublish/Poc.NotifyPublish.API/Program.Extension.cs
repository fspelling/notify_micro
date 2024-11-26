using FluentValidation;
using MassTransit;
using Poc.NotifyMessaging.Library.Event;
using Poc.NotifyPublish.Domain.Interfaces.Service;
using Poc.NotifyPublish.Domain.ViewModel.Notificacao.Request;
using Poc.NotifyPublish.Service.Services;
using Poc.NotifyPublish.Service.Validators.Notificacao;
using RabbitMQ.Client;

namespace Poc.NotifyPublish.API
{
    public static class ProgramExtension
    {
        public static void ConfigureInjectDependency(this WebApplicationBuilder builder)
            => builder.Services.AddScoped<IPagamentoService, PagamentoService>();

        public static void ConfigureRabbitmq(this WebApplicationBuilder builder)
        {
            builder.Services.AddMassTransit(busConfiguration =>
            {
                busConfiguration.SetKebabCaseEndpointNameFormatter();

                busConfiguration.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq", "/", hostConfigurator =>
                    {
                        hostConfigurator.Username("guest");
                        hostConfigurator.Password("guest");
                    });

                    cfg.Message<PagamentoCreatedEvent>(e => e.SetEntityName("pagamento-created-event-exchange"));
                    cfg.Publish<PagamentoCreatedEvent>(e => e.ExchangeType = ExchangeType.Direct);
                    cfg.Send<PagamentoCreatedEvent>(e => e.UseRoutingKeyFormatter(context => "pagamento-created"));
                });
            });
        }

        public static void ConfigureValidators(this WebApplicationBuilder builder)
            => builder.Services.AddScoped<IValidator<RealizarPagamentoRequest>, RealizarPagamentoRequestValidator>();
    }
}
