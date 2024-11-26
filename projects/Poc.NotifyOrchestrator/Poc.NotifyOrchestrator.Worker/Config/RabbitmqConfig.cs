﻿using MassTransit;
using Poc.NotifyMessaging.Library.Command;
using Poc.NotifyOrchestrator.Worker.Consumers;
using RabbitMQ.Client;

namespace Poc.NotifyOrchestrator.Worker.Config
{
    public static class RabbitmqConfig
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddMassTransit(mt =>
            {
                mt.AddConsumer<PagamentoCreatedEventConsumer>();

                mt.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    ConfigurePublishers(cfg);
                    ConfigureConsumers(context, cfg);
                });
            });

            services.AddTransient<PagamentoCreatedEventConsumer>();
        }

        private static void ConfigurePublishers(IRabbitMqBusFactoryConfigurator config)
        {
            config.Message<NotificarEmailCommand>(e => e.SetEntityName("notificacao-command-exchange"));
            config.Publish<NotificarEmailCommand>(e => e.ExchangeType = ExchangeType.Direct);
            config.Send<NotificarEmailCommand>(e => e.UseRoutingKeyFormatter(context => "notificacao-email"));

            config.Message<NotificarSmsCommand>(e => e.SetEntityName("notificacao-command-exchange"));
            config.Publish<NotificarSmsCommand>(e => e.ExchangeType = ExchangeType.Direct);
            config.Send<NotificarSmsCommand>(e => e.UseRoutingKeyFormatter(context => "notificacao-sms"));
        }

        private static void ConfigureConsumers(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator config)
        {
            config.ReceiveEndpoint("pagamento-created-event", re =>
            {
                re.ConfigureConsumeTopology = false;

                re.SetQuorumQueue();
                re.SetQueueArgument("declare", "lazy");

                re.ConfigureConsumer<PagamentoCreatedEventConsumer>(context);

                re.Bind("pagamento-created-event-exchange", e =>
                {
                    e.ExchangeType = ExchangeType.Direct;
                    e.RoutingKey = "pagamento-created";
                });
            });
        }
    }
}
