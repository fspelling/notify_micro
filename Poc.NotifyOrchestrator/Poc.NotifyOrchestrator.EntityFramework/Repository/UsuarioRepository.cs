using Poc.NotifyOrchestrator.Domain.Entity;
using Poc.NotifyOrchestrator.Domain.Interfaces.Repository;
using Poc.NotifyOrchestrator.EntityFramework.Repository.Base;

namespace Poc.NotifyOrchestrator.EntityFramework.Repository
{
    public class UsuarioRepository(NotificacaoDbContext dbContext) : RepositoryBase<Usuario>(dbContext), IUsuarioRepository
    {
    }
}
