using Poc.NotifyOrchestrator.Domain.Entity;
using Poc.NotifyOrchestrator.EntityFramework.Interfaces.Base;

namespace Poc.NotifyOrchestrator.EntityFramework.Interfaces
{
    public interface IUsuarioSmsRepository : IRepositoryBase<UsuarioSms>
    {
        Task<UsuarioSms?> BuscarPorUsuarioId(string usuarioId);
    }
}
