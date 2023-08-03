using AutoMapper;
using FluentAssertions;
using Production.Application.InjectionMoldMachines;
using Production.Domain.Entities;
using Xunit;

namespace Production.Application.Mappings.Tests
{
    public class InjectionMoldMachineMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ReturnMapInjectionMoldingMachineToInjectionMoldingMachineDto()
        {
            //arrange

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<InjectionMoldMachineMappingProfile>());

            var mapper = configuration.CreateMapper();

            var injectionMachine = new InjectionMoldingMachine()
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

            var result = mapper.Map<InjectionMoldingMachineDto>(injectionMachine);

            //assert

            for (var i = 0; i < injectionMachine.Productions.Count; i++)
            {
                result.PlannedProductions![i].StartProduction.Should().Be(injectionMachine.Productions[i].Start);
                result.PlannedProductions[i].EndProduction.Should().Be(injectionMachine.Productions[i].End);
                result.PlannedProductions[i].ProductionId.Should().Be(injectionMachine.Productions[i].Id);
            }
        }
    }
}