using AutoMapper;
using Production.Application.InjectionMoldMachines;
using Production.Domain.Entities;

namespace Production.Application.Mappings
{
    public class InjectionMoldMachineProfile : Profile
    {
        public InjectionMoldMachineProfile()
        {
            CreateMap<InjectionMoldingMachine, InjectionMoldingMachineDto>().ReverseMap();
        }
    }
}
