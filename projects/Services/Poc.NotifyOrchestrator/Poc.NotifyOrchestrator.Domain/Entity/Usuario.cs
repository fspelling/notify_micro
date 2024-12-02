using Poc.NotifyOrchestrator.Domain.Entity.Base;

namespace Poc.NotifyOrchestrator.Domain.Entity
{
    public class Usuario : EntityBase
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public string? Telefone { get; set; }
    }
}
