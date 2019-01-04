using NetCoreCache.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreCache.Domain.Entities
{
    public class Departamento
    {
        public Departamento()
        {
            Setores = new List<Setor>();
        }
        public int IdDepartamento { get; set; }
        public int IdArea { get; set; }
        public virtual Area Area { get; set; }
        public string Descricao { get; set; }
        public Status.statusAtual Status { get; set; }
        public List<Setor> Setores { get; set; }
    }
}
