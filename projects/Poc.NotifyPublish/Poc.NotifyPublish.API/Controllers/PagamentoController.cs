using Microsoft.AspNetCore.Mvc;
using Poc.NotifyPublish.API.Controllers.Base;
using Poc.NotifyPublish.Domain.Exceptions;
using Poc.NotifyPublish.Domain.Interfaces.Service;
using Poc.NotifyPublish.Domain.ViewModel.Base;
using Poc.NotifyPublish.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifyPublish.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController(IPagamentoService pagamentoService) : BaseController
    {
        private readonly IPagamentoService _pagamentoService = pagamentoService;

        [HttpPost]
        public async Task<ActionResult<CustomResponseViewModel>> RealizarPagamento([FromBody] RealizarPagamentoRequest request)
        {
            try
            {
                await _pagamentoService.RealizarPagamento(request);
                return CustomResponse();
            }
            catch (PagamentoException e)
            {
                return CustomResponseError(System.Net.HttpStatusCode.BadRequest, e);
            }
            catch (Exception e)
            {
                return CustomResponseError(System.Net.HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
