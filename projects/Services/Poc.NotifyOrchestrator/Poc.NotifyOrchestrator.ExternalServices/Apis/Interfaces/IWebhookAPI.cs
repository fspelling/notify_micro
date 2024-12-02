using Refit;

namespace Poc.NotifyOrchestrator.ExternalServices.Apis.Interfaces
{
    [Headers("accept: */*")]
    public interface IWebhookAPI
    {
        [Post("")]
        Task NotifyAsync([Body] object payload);
    }
}
