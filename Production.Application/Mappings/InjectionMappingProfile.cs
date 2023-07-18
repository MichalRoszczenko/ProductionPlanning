using AutoMapper;
using Production.Application.InjectionMolds;

namespace Production.Application.Mappings
{
    public class InjectionMappingProfile : Profile
    {
        public InjectionMappingProfile()
        {
            CreateMap<Domain.Entities.InjectionMold, InjectionMoldDto>().ReverseMap();
        }
    }
}
