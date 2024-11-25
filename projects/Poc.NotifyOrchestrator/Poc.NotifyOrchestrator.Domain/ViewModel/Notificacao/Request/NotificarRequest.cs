namespace Poc.NotifyOrchestrator.Domain.ViewModel.Pagamento.Request
{
    public class RealizarPagamentoRequest
    {
        public required string UsuarioId { get; set; }
        public required string FormaPagamento { get; set; }
    }
}
