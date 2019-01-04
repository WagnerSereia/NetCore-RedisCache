using NetCoreCache.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreCache.Domain.Entities
{
    public class Setor
    {
        public Setor()
        {}
        public int IdSetor { get; set; }
        public int IdDepartamento { get; set; }
        public virtual Departamento Departamento { get; set; }
        public string Descricao { get; set; }
        public Status.statusAtual Status { get; set; }
    }
}
