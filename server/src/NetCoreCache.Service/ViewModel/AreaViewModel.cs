using NetCoreCache.Service.ViewModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCache.Service.ViewModel
{
    public class AreaViewModel
    {
        public AreaViewModel()
        {           
        }
        public int IdArea { get; set; }
        public string Descricao { get; set; }
        public StatusViewModel.statusAtual Status { get; set; }        
    }
}
