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
            Departamentos = new List<DepartamentoViewModel>();
        }
        public int IdArea { get; set; }
        public string Descricao { get; set; }
        public StatusViewModel.statusAtual Status { get; set; }
        public virtual List<DepartamentoViewModel> Departamentos { get; set; }
    }
}
