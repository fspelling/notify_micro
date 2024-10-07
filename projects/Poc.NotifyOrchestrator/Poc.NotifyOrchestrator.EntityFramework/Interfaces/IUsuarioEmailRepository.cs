using Poc.NotifyOrchestrator.Domain.Entity;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces.Base;

namespace Poc.NotifyOrchestrator.EntityFramework.Interfaces
{
    public interface IUsuarioEmailRepository : IRepositoryBase<UsuarioEmail>
    {
        Task<UsuarioEmail?> BuscarPorUsuarioId(string usuarioId);
    }
}
