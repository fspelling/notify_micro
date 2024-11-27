namespace Poc.NotifyPublish.Domain.ViewModel.Webhook.Request
{
    public class RegisterRequest
    {
        public required string Endpoint { get; set; }
        public required string Event { get; set; }
    }
}
