using AutoMapper;
using NetCoreCache.Domain.Entities;
using NetCoreCache.Service.ViewModel;

namespace NetCoreCache.Service.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Area, AreaViewModel>();
            CreateMap<Departamento, DepartamentoViewModel>();
            CreateMap<Setor, SetorViewModel>();
        }
    }
}