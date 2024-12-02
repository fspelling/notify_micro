using Poc.NotifyPublish.Domain.Entity.Base;

namespace Poc.NotifyPublish.Domain.Entity
{
    public class WebhookEndpoints : EntityBase
    {
        public required string Endpoint { get; set; }
        public required string Event { get; set; }
        public required bool Ativo { get; set; }
        public required DateTime DataCriacao { get; set; }
    }
}
