using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.NotifyOrchestrator.Domain.Entity;

namespace Poc.NotifyOrchestrator.EntityFramework.EntityConfiguration
{
    internal class UsuarioSmsConfiguration : IEntityTypeConfiguration<UsuarioSms>
    {
        public void Configure(EntityTypeBuilder<UsuarioSms> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.UsuarioId).IsRequired();
            builder.Property(p => p.Template).IsRequired();
        }
    }
}
