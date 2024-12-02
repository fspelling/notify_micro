using MassTransit;
using Poc.NotifySendEmail.Worker.Consumers;
using RabbitMQ.Client;

namespace Poc.NotifySendEmail.Worker.Config
{
    public static class RabbitmqConfig
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddTransient<NotificarEmailCommandConsumer>();

            services.AddMassTransit(mt =>
            {
                mt.AddConsumer<NotificarEmailCommandConsumer>();

                mt.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    ConfigureConsumers(context, cfg);
                });
            });
        }

        private static void ConfigureConsumers(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator config)
        {
            config.ReceiveEndpoint("notificacao-email-command", re =>
            {
                re.ConfigureConsumeTopology = false;

                re.SetQuorumQueue();
                re.SetQueueArgument("declare", "lazy");

                re.ConfigureConsumer<NotificarEmailCommandConsumer>(context);

                re.Bind("notificacao-command-exchange", e =>
                {
                    e.ExchangeType = ExchangeType.Direct;
                    e.RoutingKey = "notificacao-email";
                });
            });
        }
    }
}
