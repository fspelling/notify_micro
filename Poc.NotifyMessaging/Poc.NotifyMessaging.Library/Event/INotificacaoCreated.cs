namespace Poc.NotifyMessaging.Library.Event
{
    public interface INotificacaoCreated
    {
        public string UsuarioId { get; }
        public DateTime DataCriacao { get; }
    }
}
