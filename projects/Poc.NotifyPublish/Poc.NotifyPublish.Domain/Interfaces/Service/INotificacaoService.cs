using Poc.NotifyPublish.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifyPublish.Domain.Interfaces.Service
{
    public interface INotificacaoService
    {
        Task Notificar(NotificarRequest request);
    }
}
