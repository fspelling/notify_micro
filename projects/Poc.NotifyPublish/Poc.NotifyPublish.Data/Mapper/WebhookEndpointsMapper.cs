using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.NotifyPublish.Domain.Entity;

namespace Poc.NotifyPublish.Data.Mapper
{
    internal class WebhookEndpointsMapper : IEntityTypeConfiguration<WebhookEndpoints>
    {
        public void Configure(EntityTypeBuilder<WebhookEndpoints> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            builder.Property(p => p.Endpoint).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Event).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Ativo).IsRequired();
            builder.Property(p => p.DataCriacao).IsRequired();
        }
    }
}
