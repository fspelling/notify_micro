using MassTransit;
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
                mt.AddConsumer<NotificacaoCreatedConsumer>();
                mt.AddConsumer<WebhookNotificationConsumer>();

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

            services.AddTransient<NotificacaoCreatedConsumer>();
            services.AddTransient<WebhookNotificationConsumer>();
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
            config.ReceiveEndpoint("notificacao-created-queue", re =>
            {
                re.ConfigureConsumeTopology = false;

                re.SetQuorumQueue();
                re.SetQueueArgument("declare", "lazy");

                re.ConfigureConsumer<NotificacaoCreatedConsumer>(context);

                re.Bind("pagamento-created-event-exchange", e =>
                {
                    e.ExchangeType = ExchangeType.Fanout;
                });
            });

            config.ReceiveEndpoint("webhook-notification-queue", re =>
            {
                re.ConfigureConsumeTopology = false;

                re.SetQuorumQueue();
                re.SetQueueArgument("declare", "lazy");

                re.ConfigureConsumer<WebhookNotificationConsumer>(context);

                re.Bind("pagamento-created-event-exchange", e =>
                {
                    e.ExchangeType = ExchangeType.Fanout;
                });
            });
        }
    }
}
