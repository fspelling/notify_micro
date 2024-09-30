using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.NotifyOrchestrator.Domain.Entity;

namespace Poc.NotifyOrchestrator.EntityFramework.EntityConfiguration
{
    internal class UsuarioEmailConfiguration : IEntityTypeConfiguration<UsuarioEmail>
    {
        public void Configure(EntityTypeBuilder<UsuarioEmail> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.UsuarioId).IsRequired();
            builder.Property(p => p.Template).IsRequired();
        }
    }
}
