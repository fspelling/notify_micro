namespace Poc.NotifyOrchestrator.Domain.ViewModel.Pagamento.Request
{
    public class RealizarPosPagamentoRequest
    {
        public required string UsuarioId { get; set; }
        public required string FormaPagamento { get; set; }
    }
}
