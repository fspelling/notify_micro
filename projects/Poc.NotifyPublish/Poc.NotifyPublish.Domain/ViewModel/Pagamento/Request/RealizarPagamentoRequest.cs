using Poc.NotifyPublish.Domain.Enums;

namespace Poc.NotifyPublish.Domain.ViewModel.Notificacao.Request
{
    public class RealizarPagamentoRequest
    {
        public required string UsuarioID { get; set; }
        public required FormaPagamentoEnum FormaPagamento { get; set; }
    }
}
