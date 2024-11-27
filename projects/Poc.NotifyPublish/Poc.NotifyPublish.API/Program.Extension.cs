using FluentValidation;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Poc.NotifyMessaging.Library.Event;
using Poc.NotifyPublish.Bus;
using Poc.NotifyPublish.Data;
using Poc.NotifyPublish.Data.Repositories;
using Poc.NotifyPublish.Domain.Interfaces.EventBus;
using Poc.NotifyPublish.Domain.Interfaces.Repository;
using Poc.NotifyPublish.Domain.Interfaces.Service;
using Poc.NotifyPublish.Domain.ViewModel.Notificacao.Request;
using Poc.NotifyPublish.Domain.ViewModel.Webhook.Request;
using Poc.NotifyPublish.Service.Services;
using Poc.NotifyPublish.Service.Validators.Notificacao;
using Poc.NotifyPublish.Service.Validators.Webhook;
using RabbitMQ.Client;

namespace Poc.NotifyPublish.API
{
    public static class ProgramExtension
    {
        public static void ConfigureInjectDependency(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPagamentoService, PagamentoService>();
            builder.Services.AddScoped<IWebhookService, WebhookService>();
            builder.Services.AddScoped<IEventBus, EventBus>();
            builder.Services.AddScoped<IWebhookEndpointsRepository, WebhookEndpointsRepository>();
        }

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

        public static void ConfigureDbContextSql(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddDbContext<NotificacaoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureValidators(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IValidator<RealizarPagamentoRequest>, RealizarPagamentoRequestValidator>();
            builder.Services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
        }
    }
}
