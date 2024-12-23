﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Poc.NotifyOrchestrator.Bus;
using Poc.NotifyOrchestrator.Cache.Caches;
using Poc.NotifyOrchestrator.Cache.Interfaces;
using Poc.NotifyOrchestrator.Domain.Interfaces.EventBus;
using Poc.NotifyOrchestrator.Domain.ViewModel.Pagamento.Request;
using Poc.NotifyOrchestrator.EntityFramework;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces;
using Poc.NotifyOrchestrator.EntityFramework.Repositories;
using Poc.NotifyOrchestrator.ExternalServices.Apis.Interfaces;
using Poc.NotifyOrchestrator.ExternalServices.Factory;
using Poc.NotifyOrchestrator.Service.Interfaces;
using Poc.NotifyOrchestrator.Service.Services;
using Poc.NotifyOrchestrator.Service.Validators.Notificacao;
using Poc.NotifyOrchestrator.Worker.Config;

namespace Poc.NotifyOrchestrator.Worker
{
    public static class ProgramExtension
    {
        public static void ConfigureInjectDependency(this IServiceCollection services)
        {
            services.AddScoped<IPagamentoService, PagamentoService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioEmailRepository, UsuarioEmailRepository>();
            services.AddScoped<IUsuarioSmsRepository, UsuarioSmsRepository>();
            services.AddScoped<IWebhookEndpointsRepository, WebhookEndpointsRepository>();

            services.AddScoped<IUsuarioNotificacaoCache, UsuarioNotificacaoCache>();
            services.AddScoped<IEventBus, EventBus>();

            services.AddScoped<WebhookClientFactory>();
        }

        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RealizarPosPagamentoRequest>, RealizarPosPagamentoRequestValidator>();
        }

        public static void ConfigureRabbitmq(this IServiceCollection services)
            => RabbitmqConfig.Configure(services);

        public static void ConfigureDbContextSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NotificacaoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureRedis(this IServiceCollection services)
            => services.AddStackExchangeRedisCache(opt => opt.Configuration = "redis:6379");
    }
}
