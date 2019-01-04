using Microsoft.EntityFrameworkCore;
using NetCoreCache.Domain.Context;
using NetCoreCache.Domain.Entities;
using NetCoreCache.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreCache.Domain.Repositories
{
    public class SetorRepository : RepositoryBase<Setor>, ISetorRepository
    {
        public SetorRepository(DBContext context)
            : base(context)
        {
        }

        public override IEnumerable<Setor> ListarTodos()
        {
            return new List<Setor>();
        }
    }
}
