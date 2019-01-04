using System;
using AutoMapper;
using NetCoreCache.Domain.Entities;
using NetCoreCache.Service.ViewModel;

namespace NetCoreCache.Service.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AreaViewModel, Area>()
                .ConstructUsing(c => new Area());

            CreateMap<DepartamentoViewModel, Departamento>()
                .ConstructUsing(c => new Departamento());

            CreateMap<SetorViewModel, Setor>()
                .ConstructUsing(c => new Setor());
        }
    }
}