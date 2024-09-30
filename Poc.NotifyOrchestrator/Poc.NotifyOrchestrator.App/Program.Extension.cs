using MassTransit;
using Microsoft.EntityFrameworkCore;
using Poc.NotifyOrchestrator.App.Consumers;
using Poc.NotifyOrchestrator.EntityFramework;
using RabbitMQ.Client;

namespace Poc.NotifyOrchestrator.App
{
    public static class ProgramExtension
    {
        public static void ConfigureInjectDependency(this WebApplicationBuilder builder)
        {
        }

        public static void ConfigureValidators(this WebApplicationBuilder builder)
        {
        }

        public static void ConfigureRabbitmq(this WebApplicationBuilder builder)
        {
            builder.Services.AddMassTransit(mt =>
            {
                mt.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("notify-event-queue", re =>
                    {
                        re.ConfigureConsumeTopology = false;

                        re.SetQuorumQueue();
                        re.SetQueueArgument("declare", "lazy");

                        re.Consumer<NotificacaoConsumer>();

                        re.Bind("notify-event-exchange", e =>
                        {
                            e.ExchangeType = ExchangeType.Direct;
                            e.RoutingKey = "notify-event";
                        });
                    });
                });
            });
        }

        public static void ConfigureDbContextSql(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<NotificacaoDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureRedis(this WebApplicationBuilder builder)
        {
        }
    }
}
