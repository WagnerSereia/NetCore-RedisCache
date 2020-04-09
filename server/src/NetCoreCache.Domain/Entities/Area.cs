using NetCoreCache.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreCache.Domain.Entities
{
    public class Area
    {
        public Area()
        {
        }
        public int IdArea { get; set; }
        public string Descricao { get; set; }
        public Status.statusAtual Status { get; set; }
    }
}
