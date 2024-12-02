using Poc.NotifyOrchestrator.Worker;

var builder = Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
{

    services.ConfigureInjectDependency();
    services.ConfigureValidators();
    services.ConfigureRabbitmq();
    services.ConfigureDbContextSql(hostContext.Configuration);
    services.ConfigureRedis();
}); 

var host = builder.Build();
host.Run();
