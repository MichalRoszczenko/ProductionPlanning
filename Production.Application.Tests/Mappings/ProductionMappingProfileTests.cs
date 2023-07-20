using Xunit;
using AutoMapper;
using Production.Domain.Entities;
using Production.Application.Productions;
using FluentAssertions;

namespace Production.Application.Mappings.Tests
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
		public void MappingProfile_ShouldMapProductionToProductionDtoOutput()
		{
			//arrange

			var production = new Domain.Entities.Production()
			{
				InjectionMold = new InjectionMold()
				{
					Name = "TestName",
				},
				InjectionMoldingMachine = new InjectionMoldingMachine()
				{
					Id = 5
				}
			};

			//act

			var result = _mapper.Map<ProductionDtoOutput>(production);

			//assert

			result.Should().NotBeNull();
			result.InjectionMoldName.Should().Be(production.InjectionMold.Name);			
			result.InjectionMoldingMachineName.Should().Be(production.InjectionMoldingMachine.Name);
		}

		[Fact()]
		public void MappingProfile_ShouldMapProductionToProductionDtoInput()
		{
			//arrange

			var production = new Domain.Entities.Production()
			{
				InjectionMoldId = new Guid(),
				InjectionMoldingMachineId = 7
			};

			//act

			var result = _mapper.Map<ProductionDtoInput>(production);

			//assert

			result.Should().NotBeNull();
			result.InjectionMoldId.Should().Be(production.InjectionMoldId);
			result.InjectionMoldingMachineId.Should().Be(production.InjectionMoldingMachineId);
		}

		[Fact()]
		public void MappingProfile_ShouldMapProductionDtoInputToProduction()
		{
			//arrange

			var productionDto = new ProductionDtoInput()
			{
				InjectionMoldId = new Guid(),
				InjectionMoldingMachineId = 7
			};

			//act

			var result = _mapper.Map<Domain.Entities.Production>(productionDto);

			//assert

			result.Should().NotBeNull();
			result.InjectionMoldId.Should().Be(productionDto.InjectionMoldId);
			result.InjectionMoldingMachineId.Should().Be(productionDto.InjectionMoldingMachineId);
		}
	}
}