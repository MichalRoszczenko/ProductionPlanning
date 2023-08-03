using AutoMapper;
using Production.Application.Material;

namespace Production.Application.Mappings
{
    public class MaterialMappingProfile : Profile
    {
        public MaterialMappingProfile()
        {
            CreateMap<Domain.Entities.Material, MaterialDto>().ReverseMap();
        }
    }
}
