using Microsoft.EntityFrameworkCore;
using NetCoreCache.Domain.Context;
using NetCoreCache.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreCache.Domain.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected DBContext Db;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(DBContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Adicionar(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            Db.SaveChanges();
        }
        
        public virtual IEnumerable<TEntity> ListarTodos()
        {
            return DbSet.ToList();
        }
                
        public void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            Db.SaveChanges();
        }

        public void Dispose()
        {
            if (Db != null)
            {
                Db.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
