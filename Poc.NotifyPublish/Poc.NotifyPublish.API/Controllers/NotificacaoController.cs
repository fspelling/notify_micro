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
    public class NotificacaoController(INotificacaoService notificacaoService) : BaseController
    {
        private readonly INotificacaoService _notificacaoService = notificacaoService;

        [HttpPost]
        public async Task<ActionResult<CustomResponseViewModel<object>>> Notificar([FromBody]NotificarRequest request)
        {
            try
            {
                await _notificacaoService.Notificar(request);
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
