namespace Poc.NotifySend.Domain.ViewModel.Notificacao.Request
{
    public abstract class NotificarRequest
    {
        public required string NomeUsuario { get; set; }
        public required string Template { get; set; }
    }

    public class NotificarEmailRequest : NotificarRequest
    {
        public required string Email { get; set; }
    }

    public class NotificarSmsRequest : NotificarRequest
    {
        public required string Telefone { get; set; }
    }
}
