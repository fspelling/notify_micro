using MassTransit;
using Poc.NotifyMessaging.Library.Command;
using Poc.NotifyMessaging.Library.Event;
using Poc.NotifyOrchestrator.Cache.Interfaces;
using Poc.NotifyOrchestrator.Cache.ModelCache;
using Poc.NotifyOrchestrator.Domain.Exceptions;
using Poc.NotifyOrchestrator.Domain.Interfaces.EventBus;
using Poc.NotifyOrchestrator.Domain.ViewModel.Pagamento.Request;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces;
using Poc.NotifyOrchestrator.Service.Interfaces;

namespace Poc.NotifyOrchestrator.Worker.Consumers
{
    public class NotificacaoCreatedConsumer(
        IPagamentoService pagamentoService, 
        IUsuarioNotificacaoCache usuarioNotificacaoCache,
        IUsuarioRepository usuarioRepository,
        IUsuarioEmailRepository usuarioEmailRepository,
        IUsuarioSmsRepository usuarioSmsRepository,
        IEventBus eventBus
    ) : IConsumer<PagamentoCreatedEvent>
    {
        private readonly IPagamentoService _pagamentoService = pagamentoService;
        private readonly IUsuarioNotificacaoCache _usuarioNotificacaoCache = usuarioNotificacaoCache;
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IUsuarioEmailRepository _usuarioEmailRepository = usuarioEmailRepository;
        private readonly IUsuarioSmsRepository _usuarioSmsRepository = usuarioSmsRepository;
        private readonly IEventBus _eventBus = eventBus;

        public async Task Consume(ConsumeContext<PagamentoCreatedEvent> context)
        {
            var message = context.Message;

            await _pagamentoService.RealizarPosPagamento(new RealizarPosPagamentoRequest { UsuarioId = message.UsuarioId!, FormaPagamento = message.FormaPagamento! });
            await NotificarPagamentoCommand(message.UsuarioId!);
        }

        #region Metodos Auxiliares

        private async Task<UsuarioNotificacao?> CarregarUsuarioNotificacao(string usuarioId)
        {
            var usuarioNotificacao = await _usuarioNotificacaoCache.GetCache(usuarioId);

            if (usuarioNotificacao is null)
            {
                var usuario = await _usuarioRepository.BuscarPorId(usuarioId);
                var usuarioEmail = await _usuarioEmailRepository.BuscarPorUsuarioId(usuarioId);
                var usuarioSms = await _usuarioSmsRepository.BuscarPorUsuarioId(usuarioId);

                if (usuario is null || usuarioEmail is null || usuarioSms is null)
                    throw new PagamentoException("Usuario nao encontrado na base");

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

        private async Task NotificarPagamentoCommand(string usuarioId)
        {
            var usuarioNotificacao = await CarregarUsuarioNotificacao(usuarioId);

            await NotificarEmailCommand(usuarioNotificacao!.UsuarioNome, usuarioNotificacao.UsuarioEmail, usuarioNotificacao.TemplateEmail);

            if (usuarioNotificacao.UsuarioSms is not null)
                await NotificarSmsCommand(usuarioNotificacao.UsuarioNome, usuarioNotificacao.UsuarioSms, usuarioNotificacao.TemplateSms);
        }

        #region Publish Commands

        private async Task NotificarEmailCommand(string nomeUsuario, string email, string template)
        {
            await _eventBus.Publish(new NotificarEmailCommand
            {
                NomeUsuario = nomeUsuario,
                EmailUsuario = email,
                Template = template
            });
        }

        private async Task NotificarSmsCommand(string nomeUsuario, string sms, string template)
        {
            await _eventBus.Publish(new NotificarSmsCommand
            {
                NomeUsuario = nomeUsuario,
                SmsUsuario = sms,
                Template = template
            });
        }

        #endregion

        #endregion
    }
}
