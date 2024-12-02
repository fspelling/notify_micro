using Microsoft.AspNetCore.Mvc;
using Poc.NotifyMicro.WebhookClient.API.Controllers.Base;
using Poc.NotifyMicro.WebhookClient.API.ViewModel;

namespace Poc.NotifyMicro.WebhookClient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<ActionResult<CustomResponseViewModel>> Notificar([FromBody] object request)
        {
            try
            {
                await Task.CompletedTask;
                return CustomResponse();
            }
            catch (Exception e)
            {
                return CustomResponseError(System.Net.HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
