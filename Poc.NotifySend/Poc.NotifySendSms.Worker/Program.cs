using Poc.NotifySendSms.Worker;

var builder = Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
{
    services.ConfigureInjectDependency();
    services.ConfigureValidators();
    services.ConfigureRabbitmq();
    services.AddHostedService<Worker>();
});

var host = builder.Build();
host.Run();
