﻿using NetCoreCache.UI.ViewModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreCache.UI.ViewModel
{
    public class DepartamentoViewModel
    {
        public DepartamentoViewModel()
        {
            Setores = new List<SetorViewModel>();
        }
        public int IdDepartamento { get; set; }
        public int IdArea { get; set; }
        public virtual AreaViewModel Area { get; set; }
        public string Descricao { get; set; }
        public StatusViewModel.statusAtual Status { get; set; }
        public virtual List<SetorViewModel> Setores { get; set; }
    }
}
