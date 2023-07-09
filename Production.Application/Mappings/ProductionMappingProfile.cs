using AutoMapper;
using Production.Application.Production;
using Production.Domain.Entities;

namespace Production.Application.Mappings
{
    public class ProductionMappingProfile : Profile
    {
        public ProductionMappingProfile()
        {
            CreateMap<Domain.Entities.Production, ProductionDto>()
                .ForMember(x => x.InjectionMoldingMachineName, opt => opt.MapFrom(src => src.InjectionMoldingMachine.Name))
                .ForMember(x => x.InjectionMoldName, opt => opt.MapFrom(src => src.InjectionMold.Name));
        }
    }
}
