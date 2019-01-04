using Microsoft.EntityFrameworkCore;
using NetCoreCache.Domain.Context;
using NetCoreCache.Domain.Entities;
using NetCoreCache.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreCache.Domain.Repositories
{
    public class DepartamentoRepository : RepositoryBase<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(DBContext context)
            : base(context)
        {
        }

        public override IEnumerable<Departamento> ListarTodos()
        {
            return new List<Departamento>();
        }
    }
}
