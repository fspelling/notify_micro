using Poc.NotifyOrchestrator.Domain.ViewModel.Pagamento.Request;

namespace Poc.NotifyOrchestrator.Service.Interfaces
{
    public interface IPagamentoService
    {
        Task RealizarPagamento(RealizarPagamentoRequest request);
    }
}
