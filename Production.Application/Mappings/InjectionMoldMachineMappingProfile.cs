using AutoMapper;
using Production.Application.Dtos;
using Production.Domain.Entities;

namespace Production.Application.Mappings
{
    public class InjectionMoldMachineMappingProfile : Profile
    {
        public InjectionMoldMachineMappingProfile()
        {
            CreateMap<InjectionMoldingMachine, InjectionMoldingMachineDto>()
                .ForMember(dto => dto.PlannedProductions, opt => opt.MapFrom(src => GetMachineProductionDto(src.Productions!)));            
            
            CreateMap<InjectionMoldingMachineDto, InjectionMoldingMachine>();
        }

        public IEnumerable<PlannedProductionDto> GetMachineProductionDto(IEnumerable<Domain.Entities.Production> productions)
        {
            var machineProductionDto = new List<PlannedProductionDto>();

            if (productions.Any())
            {
                foreach (var production in productions)
                {
                    var machineProduction = new PlannedProductionDto()
                    {
                        StartProduction = production.Start,
                        EndProduction = production.End,
                        ProductionId = production.Id
                    };

                    machineProductionDto.Add(machineProduction);
                }
            }

            return machineProductionDto;
        }
    }
}
