using AutoMapper;
using Production.Application.Dtos;
using Production.Domain.Entities;

namespace Production.Application.Mappings
{
    public class ProductionMappingProfile : Profile
    {
        public ProductionMappingProfile()
        {
            CreateMap<Domain.Entities.Production, ProductionDto>()
                .ForMember(x => x.InjectionMoldId, opt => opt.MapFrom(src => src.InjectionMold.Id))
                .ForMember(x => x.InjectionMoldName, opt => opt.MapFrom(src => src.InjectionMold.Name))
                .ForMember(x => x.InjectionMoldingMachineId, opt => opt.MapFrom(src => src.InjectionMoldingMachine.Id))
                .ForMember(x => x.InjectionMoldingMachineName, opt => opt.MapFrom(src => src.InjectionMoldingMachine.Name))
                .ForMember(x => x.MaterialIsAvailable, opt => opt.MapFrom(src => src.MaterialStatus.MaterialIsAvailable))
                .ForMember(x => x.MaterialUsage, opt => opt.MapFrom(src => src.MaterialStatus.MaterialUsage));

            CreateMap<ProductionDto, Domain.Entities.Production>()
                .ForMember(s => s.InjectionMoldingMachine, opt => opt.MapFrom(src => new InjectionMoldingMachine()
                {
                    Id = src.InjectionMoldingMachineId,
                    Name = src.InjectionMoldingMachineName!,
                }))
                .ForMember(s => s.InjectionMold, opt => opt.MapFrom(src => new InjectionMold()
                {
                    Id = src.InjectionMoldId,
                    Name = src.InjectionMoldName!
                }))
                .ForMember(s => s.MaterialStatus, opt => opt.MapFrom(src => new MaterialStatus()
                {
                    MaterialIsAvailable = src.MaterialIsAvailable,
                    MaterialUsage = src.MaterialUsage,
                }));

            CreateMap<MaterialStatus, MaterialStatusDto>().ReverseMap();
        }
    }
}
