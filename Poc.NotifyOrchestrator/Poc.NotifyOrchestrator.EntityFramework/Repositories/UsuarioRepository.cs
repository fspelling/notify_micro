using Poc.NotifyOrchestrator.Domain.Entity;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces;
using Poc.NotifyOrchestrator.EntityFramework.Repositories.Base;

namespace Poc.NotifyOrchestrator.EntityFramework.Repositories
{
    public class UsuarioRepository(NotificacaoDbContext dbContext) : RepositoryBase<Usuario>(dbContext), IUsuarioRepository
    {
    }
}
