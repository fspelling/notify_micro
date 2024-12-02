namespace Poc.NotifyOrchestrator.Cache.ModelCache
{
    public class UsuarioNotificacao
    {
        public required string UsuarioId { get; set; }
        public required string UsuarioNome { get; set; }
        public required string UsuarioEmail { get; set; }
        public string? UsuarioSms { get; set; }
        public required string TemplateEmail { get; set; }
        public required string TemplateSms { get; set; }
    }
}
