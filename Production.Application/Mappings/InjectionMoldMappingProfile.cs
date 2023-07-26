using AutoMapper;
using Production.Application.InjectionMolds;

namespace Production.Application.Mappings
{
    public class InjectionMoldMappingProfile : Profile
    {
        public InjectionMoldMappingProfile()
        {
            CreateMap<InjectionMoldDto, Domain.Entities.InjectionMold>();

            CreateMap<Domain.Entities.InjectionMold, InjectionMoldDto>()
                .ForMember(x => x.PlannedProductions, opt => opt.MapFrom(src => GetProductionTimes(src.Productions!)));
        }

        private List<PlannedProduction> GetProductionTimes(IEnumerable<Domain.Entities.Production> productions)
        {
            var productionTimes = new List<PlannedProduction>();

            if (productions.Any())
            {
                foreach (var production in productions)
                {
                    var productionTime = new PlannedProduction()
                    {
                        ProductionId = production.Id,
                        StartProduction = production.Start,
                        EndProduction = production.End
                    };

                    productionTimes.Add(productionTime);
                }
            }

            return productionTimes;
        }
    }
}
