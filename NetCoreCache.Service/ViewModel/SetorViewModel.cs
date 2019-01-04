using NetCoreCache.Domain.Entities.Enum;
using NetCoreCache.Service.ViewModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreCache.Service.ViewModel
{
    public class SetorViewModel
    {
        public SetorViewModel()
        {}
        public int IdSetor { get; set; }
        public int IdDepartamento { get; set; }
        public virtual DepartamentoViewModel Departamento { get; set; }
        public string Descricao { get; set; }
        public StatusViewModel.statusAtual Status { get; set; }
    }
}
