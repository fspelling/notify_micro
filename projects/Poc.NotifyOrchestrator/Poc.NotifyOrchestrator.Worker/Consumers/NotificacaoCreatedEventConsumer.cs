﻿using MassTransit;
using Poc.NotifyMessaging.Library.Event;
using Poc.NotifyOrchestrator.Domain.ViewModel.Pagamento.Request;
using Poc.NotifyOrchestrator.Service.Interfaces;

namespace Poc.NotifyOrchestrator.Worker.Consumers
{
    public class PagamentoCreatedEventConsumer(IPagamentoService pagamentoService) : IConsumer<PagamentoCreatedEvent>
    {
        private readonly IPagamentoService _pagamentoService = pagamentoService;

        public async Task Consume(ConsumeContext<PagamentoCreatedEvent> context)
        {
            var message = context.Message;
            await _pagamentoService.RealizarPagamento(new RealizarPagamentoRequest { UsuarioId = message.UsuarioId!, FormaPagamento = message.FormaPagamento! });
        }
    }
}
