﻿using FluentValidation;
using MassTransit;
using Poc.NotifyMessaging.Library.Command;
using Poc.NotifyOrchestrator.Cache.Interfaces;
using Poc.NotifyOrchestrator.Cache.ModelCache;
using Poc.NotifyOrchestrator.Domain.Exceptions;
using Poc.NotifyOrchestrator.Domain.Extensions;
using Poc.NotifyOrchestrator.Domain.ViewModel.Notificacao.Request;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces;
using Poc.NotifyOrchestrator.Service.Interfaces;

namespace Poc.NotifyOrchestrator.Service.Services
{
    public class NotificacaoService(
        IValidator<NotificarRequest> notificarRequestValidator,
        IUsuarioNotificacaoCache usuarioNotificacaoCache,
        IUsuarioRepository usuarioRepository,
        IUsuarioEmailRepository usuarioEmailRepository,
        IUsuarioSmsRepository usuarioSmsRepository,
        IPublishEndpoint publishEndpoint
    ) : INotificacaoService
    {
        private readonly IValidator<NotificarRequest> _notificarRequestValidator = notificarRequestValidator;

        private readonly IUsuarioNotificacaoCache _usuarioNotificacaoCache = usuarioNotificacaoCache;

        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IUsuarioEmailRepository _usuarioEmailRepository = usuarioEmailRepository;
        private readonly IUsuarioSmsRepository _usuarioSmsRepository = usuarioSmsRepository;

        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task Notificar(NotificarRequest request)
        {
            await _notificarRequestValidator.ValidarRequestException<NotificarRequest, NotificacaoException>(request);

            var usuarioNotificacao = await CarregarUsuarioNotificacao(request.UsuarioId);

            if (usuarioNotificacao is null)
                throw new NotificacaoException("Usuario nao econtrado na base");

            await NotificarEmailCommand(usuarioNotificacao.UsuarioNome, usuarioNotificacao.UsuarioEmail, usuarioNotificacao.TemplateEmail);

            if (usuarioNotificacao.UsuarioSms is not null)
                await NotificarSmsCommand(usuarioNotificacao.UsuarioNome, usuarioNotificacao.UsuarioSms, usuarioNotificacao.TemplateSms);
        }

        private async Task<UsuarioNotificacao?> CarregarUsuarioNotificacao(string usuarioId)
        {
            var usuarioNotificacao = await _usuarioNotificacaoCache.GetCache(usuarioId);

            if (usuarioNotificacao is null)
            {
                var usuario = await _usuarioRepository.BuscarPorId(usuarioId);
                var usuarioEmail = await _usuarioEmailRepository.BuscarPorUsuarioId(usuarioId);
                var usuarioSms = await _usuarioSmsRepository.BuscarPorUsuarioId(usuarioId);

                if (usuario is null || usuarioEmail is null || usuarioSms is null)
                    throw new NotificacaoException("Usuario nao encontrado na base");

                usuarioNotificacao = new UsuarioNotificacao
                {
                    UsuarioId = usuarioId,
                    TemplateEmail = usuarioEmail!.Template,
                    TemplateSms = usuarioSms!.Template,
                    UsuarioEmail = usuario!.Email,
                    UsuarioSms = usuario.Telefone,
                    UsuarioNome = usuario.Nome,
                };

                await _usuarioNotificacaoCache.SetCache(usuarioId, usuarioNotificacao);
            }

            return usuarioNotificacao;
        }

        private async Task NotificarEmailCommand(string nomeUsuario, string email, string template)
        {
            await _publishEndpoint.Publish<INotificarEmailCommand>(new
            {
                NomeUsuario = nomeUsuario,
                EmailUsuario = email,
                Template = template
            });
        }

        private async Task NotificarSmsCommand(string nomeUsuario, string sms, string template)
        {
            await _publishEndpoint.Publish<INotificarSmsCommand>(new
            {
                NomeUsuario = nomeUsuario,
                SmsUsuario = sms,
                Template = template
            });
        }
    }
}
