using Microsoft.EntityFrameworkCore;
using Poc.NotifyOrchestrator.Domain.Entity;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces;
using Poc.NotifyOrchestrator.EntityFramework.Repositories.Base;

namespace Poc.NotifyOrchestrator.EntityFramework.Repositories
{
    public class UsuarioSmsRepository(NotificacaoDbContext dbContext) : RepositoryBase<UsuarioSms>(dbContext), IUsuarioSmsRepository
    {
        public async Task<UsuarioSms?> BuscarPorUsuarioId(string usuarioId)
            => await dbContext.UsuarioSms.FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);
    }
}
