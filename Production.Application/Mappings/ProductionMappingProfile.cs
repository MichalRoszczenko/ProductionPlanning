using AutoMapper;
using Production.Application.Productions;
using Production.Domain.Entities;

namespace Production.Application.Mappings
{
    public class ProductionMappingProfile : Profile
    {
        public ProductionMappingProfile()
        {
            CreateMap<Domain.Entities.Production, ProductionDtoOutput>()
                .ForMember(x => x.InjectionMoldingMachineName, opt => opt.MapFrom(src => src.InjectionMoldingMachine.Name))
                .ForMember(x => x.InjectionMoldName, opt => opt.MapFrom(src => src.InjectionMold.Name));

            CreateMap<ProductionDtoInput, Domain.Entities.Production>()
                .ForMember(s => s.InjectionMoldingMachine, opt => opt.MapFrom(src => new InjectionMoldingMachine()
                {
                    Id = src.InjectionMoldingMachineId
                }))
                .ForMember(s => s.InjectionMold, opt => opt.MapFrom(src => new InjectionMold()
                {
                    Id = src.InjectionMoldId
                }));

            CreateMap<Domain.Entities.Production, ProductionDtoInput>()
                .ForMember(x => x.InjectionMoldId, opt => opt.MapFrom(src => src.InjectionMoldId))
                .ForMember(x => x.InjectionMoldingMachineId, opt => opt.MapFrom(src => src.InjectionMoldingMachineId));
        }
    }
}
