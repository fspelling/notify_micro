using Poc.NotifyOrchestrator.Domain.Entity.Base;

namespace Poc.NotifyOrchestrator.Domain.Entity
{
    public class UsuarioEmail : EntityBase
    {
        public required string UsuarioId { get; set; }
        public required string Template { get; set; }
        public string Idioma { get; set; } = "PT-BR";
    }
}
