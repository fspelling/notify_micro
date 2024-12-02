using Poc.NotifySend.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifySend.Service.Interfaces
{
    public interface INotificacaoService<TRequestProvider> where TRequestProvider : NotificarRequest
    {
        Task Notificar(TRequestProvider request);
    }
}
