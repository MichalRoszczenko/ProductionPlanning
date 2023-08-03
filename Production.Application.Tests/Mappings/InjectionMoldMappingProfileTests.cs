using AutoMapper;
using FluentAssertions;
using Production.Application.InjectionMolds;
using Production.Domain.Entities;
using Xunit;

namespace Production.Application.Mappings.Tests
{
    public class InjectionMoldMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapInjectionMoldToInjectionMoldDto()
        {
            //arrange

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<InjectionMoldMappingProfile>());

            var mapper = configuration.CreateMapper();

            var injectionMold = new InjectionMold()
            {
                Productions = new List<Domain.Entities.Production>
                {
                    new Domain.Entities.Production()
                    {
                        Id= 5,
                        Start = DateTime.Now,
                        End = DateTime.Now.AddDays(1)
                    },
                    new Domain.Entities.Production()
                    {
                        Id= 6,
                        Start = DateTime.Now,
                        End = DateTime.Now.AddDays(1)
                    }
                }
            };

            //act

            var result = mapper.Map<InjectionMoldDto>(injectionMold);

            //assert

            for ( var i = 0 ; i < injectionMold.Productions.Count;i++)
            {
                result.PlannedProductions![i].StartProduction.Should().Be(injectionMold.Productions[i].Start);
                result.PlannedProductions[i].EndProduction.Should().Be(injectionMold.Productions[i].End);
                result.PlannedProductions[i].ProductionId.Should().Be(injectionMold.Productions[i].Id);
            }
        }

    }
}