using Poc.NotifyOrchestrator.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifyOrchestrator.Service.Interfaces
{
    public interface INotificacaoService
    {
        Task Notificar(NotificarRequest request);
    }
}
