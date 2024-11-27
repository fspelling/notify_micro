using Microsoft.EntityFrameworkCore;
using Poc.NotifyPublish.Data.Mapper;
using Poc.NotifyPublish.Domain.Entity;

namespace Poc.NotifyPublish.Data
{
    public class NotificacaoDbContext : DbContext
    {
        public DbSet<WebhookEndpoints> WebhookEndpoints { get; set; }

        public NotificacaoDbContext(DbContextOptions<NotificacaoDbContext> options) : base(options)
            => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WebhookEndpointsMapper());
            base.OnModelCreating(modelBuilder);
        }
    }
}
