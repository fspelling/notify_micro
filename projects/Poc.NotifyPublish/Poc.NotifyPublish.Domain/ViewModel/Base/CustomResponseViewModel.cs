using System.Net;

namespace Poc.NotifyPublish.Domain.ViewModel.Base
{
    public class CustomResponseViewModel<T>(T result)
    {
        public string Mensagem { get; set; } = "Operação realizada com sucesso.";
        public bool Error { get; set; } = false;
        public T Result { get; set; } = result;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }

    public class CustomResponseViewModel
    {
        public string Mensagem { get; set; } = "Operação realizada com sucesso.";
        public bool Error { get; set; } = false;
        public object Result { get; set; } = null!;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
