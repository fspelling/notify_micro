using Poc.NotifyMessaging.Library.Event.Base;

namespace Poc.NotifyMessaging.Library.Event
{
    public class PagamentoCreatedEvent : IEvent
    {
        public string? UsuarioId { get; set; }
        public string? FormaPagamento { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
