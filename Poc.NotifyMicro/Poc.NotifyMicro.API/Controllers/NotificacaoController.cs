using Microsoft.AspNetCore.Mvc;
using Poc.NotifyMicro.API.Controllers.Base;
using Poc.NotifyMicro.Domain.Exceptions;
using Poc.NotifyMicro.Domain.ViewModel.Base;
using Poc.NotifyMicro.Domain.ViewModel.Notificacao.Request;

namespace Poc.NotifyMicro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacaoController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<CustomResponseViewModel<object>>> Notificar(NotificarRequest request)
        {
            try
            {
                return CustomResponse<object>(null!);
            }
            catch (NotificacaoException e)
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
