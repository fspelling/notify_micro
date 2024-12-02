using MassTransit;
using Poc.NotifySendSms.Worker.Consumers;
using RabbitMQ.Client;

namespace Poc.NotifySendSms.Worker.Config
{
    public static class RabbitmqConfig
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddTransient<NotificarSmsCommandConsumer>();

            services.AddMassTransit(mt =>
            {
                mt.AddConsumer<NotificarSmsCommandConsumer>();

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
            config.ReceiveEndpoint("notificacao-sms-command", re =>
            {
                re.ConfigureConsumeTopology = false;

                re.SetQuorumQueue();
                re.SetQueueArgument("declare", "lazy");

                re.ConfigureConsumer<NotificarSmsCommandConsumer>(context);

                re.Bind("notificacao-command-exchange", e =>
                {
                    e.ExchangeType = ExchangeType.Direct;
                    e.RoutingKey = "notificacao-sms";
                });
            });
        }
    }
}
