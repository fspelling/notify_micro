using Microsoft.AspNetCore.Mvc;
using Poc.NotifyPublish.API.Controllers.Base;
using Poc.NotifyPublish.Domain.Exceptions;
using Poc.NotifyPublish.Domain.Interfaces.Service;
using Poc.NotifyPublish.Domain.ViewModel.Base;
using Poc.NotifyPublish.Domain.ViewModel.Webhook.Request;

namespace Poc.NotifyPublish.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController(IWebhookService webhookService) : BaseController
    {
        private readonly IWebhookService _webhookService = webhookService;

        [HttpPost("[action]")]
        public async Task<ActionResult<CustomResponseViewModel>> Register([FromBody] RegisterRequest request)
        {
            try
            {
                await _webhookService.Registrar(request);
                return CustomResponse();
            }
            catch (WebhookException e)
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
