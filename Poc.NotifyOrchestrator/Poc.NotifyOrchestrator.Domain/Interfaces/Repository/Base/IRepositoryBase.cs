﻿using Poc.NotifyOrchestrator.Domain.Entity.Base;

namespace Poc.NotifyOrchestrator.Domain.Interfaces.Repository.Base
{
    public interface IRepositoryBase<Entity> where Entity : EntityBase
    {
        Task Inserir(Entity entidade);
        Task Atualizar(Entity entidade);
        Task<IList<Entity>> Listar();
        Task<Entity?> BuscarPorId(string id);
        Task Remover(string id);
    }
}
