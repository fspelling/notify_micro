﻿using Poc.NotifyMessaging.Library.Event.Base;

namespace Poc.NotifyMessaging.Library.Event
{
    public interface IPagamentoCreatedEvent : IEvent
    {
        public string UsuarioId { get; }
        public DateTime DataCriacao { get; }
    }
}
