using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreCache.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);        
        void Remover(int id);
        IEnumerable<TEntity> ListarTodos();
        void Dispose();
    }
}
