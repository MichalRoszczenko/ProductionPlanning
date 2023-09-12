using Xunit;
using AutoMapper;
using Production.Domain.Entities;
using FluentAssertions;
using Production.Application.Mappings;
using Production.Application.Dtos;

namespace Production.Application.Tests.Mappings
{
    public class ProductionMappingProfileTests
    {
        private readonly IMapper _mapper;

        public ProductionMappingProfileTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new ProductionMappingProfile()));

            _mapper = configuration.CreateMapper();
        }

        [Fact()]
        public void MappingProfile_ShouldMapProductionToProductionDto()
        {
            //arrange

            var production = new Domain.Entities.Production()
            {
                InjectionMold = new InjectionMold()
                {
                    Id = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                    Name = "TestMoldName",
                },
                InjectionMoldingMachine = new InjectionMoldingMachine()
                {
                    Id = 5,
                    Name = "TestMachineName",
                },
                MaterialStatus = new MaterialStatus()
                {
                    MaterialIsAvailable = true,
                    MaterialUsage = 400
                }
            };            
            
            var productionDto = new ProductionDto()
            {
                InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                InjectionMoldName = "TestMoldName",
                InjectionMoldingMachineId = 5,
                InjectionMoldingMachineName = "TestMachineName",
                MaterialIsAvailable = true,
                MaterialUsage = 400
            };

            //act

            var result = _mapper.Map<ProductionDto>(production);

            //assert

            result.Should().BeEquivalentTo(productionDto);
        }

        [Fact()]
        public void MappingProfile_ShouldMapProductionDtoToProduction()
        {
            //arrange

            var productionDto = new ProductionDto()
            {
                InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                InjectionMoldName = "TestInjectionMoldName",
                InjectionMoldingMachineId = 7,
                InjectionMoldingMachineName = "TestInjectionMachineName",
                MaterialIsAvailable = false,
                MaterialUsage = 1111
            }; 
            
            var production = new Domain.Entities.Production()
            {
                InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                InjectionMold = new InjectionMold()
                {
                    Id = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                    Name = "TestInjectionMoldName",
                },
                InjectionMoldingMachineId = 7,
                InjectionMoldingMachine = new InjectionMoldingMachine()
                {
                    Id = 7,
                    Name = "TestInjectionMachineName",
                },
                MaterialStatus = new MaterialStatus()
                {
                    MaterialIsAvailable = false,
                    MaterialUsage = 1111
                }
            };

            //act

            var result = _mapper.Map<Domain.Entities.Production>(productionDto);

            //assert

            result.Should().BeEquivalentTo(production);
        }
    }
}