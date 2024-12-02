using Microsoft.EntityFrameworkCore;
using Poc.NotifyOrchestrator.Domain.Entity;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces;
using Poc.NotifyOrchestrator.EntityFramework.Repositories.Base;

namespace Poc.NotifyOrchestrator.EntityFramework.Repositories
{
    public class UsuarioEmailRepository(NotificacaoDbContext dbContext) : RepositoryBase<UsuarioEmail>(dbContext), IUsuarioEmailRepository
    {
        public async Task<UsuarioEmail?> BuscarPorUsuarioId(string usuarioId)
            => await dbContext.UsuarioEmail.FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);
    }
}
