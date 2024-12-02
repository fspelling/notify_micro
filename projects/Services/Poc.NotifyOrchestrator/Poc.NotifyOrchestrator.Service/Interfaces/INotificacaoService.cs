namespace Poc.NotifyOrchestrator.Service.Interfaces
{
    public interface INotificacaoService
    {
        Task NotificarEmail(string usuarioId);
        Task NotificarSMS(string usuarioId);
    }
}
