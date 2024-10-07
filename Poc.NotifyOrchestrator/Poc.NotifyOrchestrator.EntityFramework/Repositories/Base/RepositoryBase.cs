using Microsoft.EntityFrameworkCore;
using Poc.NotifyOrchestrator.Domain.Entity.Base;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces.Base;

namespace Poc.NotifyOrchestrator.EntityFramework.Repositories.Base
{
    public abstract class RepositoryBase<TEntity>(NotificacaoDbContext dbContext) : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly NotificacaoDbContext dbContext = dbContext;

        public async Task Atualizar(TEntity entidade)
        {
            dbContext.Entry(entidade).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<TEntity?> BuscarPorId(string id)
            => await dbContext.Set<TEntity>().Where(e => e.ID == id).FirstOrDefaultAsync();

        public async Task Inserir(TEntity entidade)
        {
            dbContext.Entry(entidade).State = EntityState.Added;
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> Listar()
            => await dbContext.Set<TEntity>().ToListAsync();

        public async Task Remover(string id)
        {
            var entidade = await dbContext.Set<TEntity>().Where(e => e.ID == id).FirstOrDefaultAsync();

            dbContext.Entry(entidade!).State = EntityState.Deleted;
            await dbContext.SaveChangesAsync();
        }
    }
}
