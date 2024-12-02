namespace Poc.NotifyPublish.Domain.Entity.Base
{
    public abstract class EntityBase
    {
        public string ID { get; } = Guid.NewGuid().ToString();
    }
}
