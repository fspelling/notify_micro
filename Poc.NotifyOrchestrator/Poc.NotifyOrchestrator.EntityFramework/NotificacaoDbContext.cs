using Microsoft.EntityFrameworkCore;
using Poc.NotifyOrchestrator.Domain.Entity;
using Poc.NotifyOrchestrator.EntityFramework.EntityConfiguration;

namespace Poc.NotifyOrchestrator.EntityFramework
{
    public class NotificacaoDbContext(DbContextOptions<NotificacaoDbContext> options) : DbContext(options)
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioEmail> UsuarioEmail { get; set; }
        public DbSet<UsuarioSms> UsuarioSms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEmailConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioSmsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
