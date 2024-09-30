using Poc.NotifyOrchestrator.App;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureInjectDependency();
builder.ConfigureRabbitmq();
builder.ConfigureValidators();
builder.ConfigureDbContextSql();
builder.ConfigureRedis();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials());
});

var app = builder.Build();
app.Run();