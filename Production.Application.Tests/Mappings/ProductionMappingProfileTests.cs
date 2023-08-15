using Xunit;
using AutoMapper;
using Production.Domain.Entities;
using Production.Application.Productions;
using FluentAssertions;
using Production.Application.Mappings;

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
                    Id = Guid.NewGuid(),
                    Name = "TestMoldName",
                },
                InjectionMoldingMachine = new InjectionMoldingMachine()
                {
                    Id = 5,
                    Name = "TestMachineName",
                }
            };

            //act

            var result = _mapper.Map<ProductionDto>(production);

            //assert

            result.Should().NotBeNull();
            result.InjectionMoldId.Should().Be(production.InjectionMold.Id);
            result.InjectionMoldName.Should().Be(production.InjectionMold.Name);
            result.InjectionMoldingMachineId.Should().Be(production.InjectionMoldingMachine.Id);
            result.InjectionMoldingMachineName.Should().Be(production.InjectionMoldingMachine.Name);
        }

        [Fact()]
        public void MappingProfile_ShouldMapProductionDtoInputToProduction()
        {
            //arrange

            var productionDto = new ProductionDto()
            {
                InjectionMoldId = Guid.NewGuid(),
                InjectionMoldName = "TestInjectionMoldName",
                InjectionMoldingMachineId = 7,
                InjectionMoldingMachineName = "TestInjectionMachineName"
            };

            //act

            var result = _mapper.Map<Domain.Entities.Production>(productionDto);

            //assert

            result.Should().NotBeNull();
            result.InjectionMold.Id.Should().Be(productionDto.InjectionMoldId);
            result.InjectionMold.Name.Should().Be(productionDto.InjectionMoldName);
            result.InjectionMoldingMachine.Id.Should().Be(productionDto.InjectionMoldingMachineId);
            result.InjectionMoldingMachine.Name.Should().Be(productionDto.InjectionMoldingMachineName);
        }
    }
}