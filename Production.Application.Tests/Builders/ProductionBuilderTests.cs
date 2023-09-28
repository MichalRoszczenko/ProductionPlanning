using FluentAssertions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Production.Application.Builders;
using Production.Application.Tests.TestsData.ProductionBuilderTestData;
using Production.Domain.Entities;
using Xunit;

namespace Production.Application.Tests.Builders
{
	public class ProductionBuilderTests
	{
		private readonly ProductionBuilder _productionBuilder;

		public ProductionBuilderTests()
        {
            _productionBuilder = new ProductionBuilder();
        }

        [Fact()]
		public void Init_ReturnProduction_ForExistProduction()
        {
			//arrange
			var production = new Domain.Entities.Production()
			{
				Start = DateTime.Now,
				End = DateTime.Now.AddHours(25),
				InjectionMoldId = Guid.NewGuid(),
				InjectionMoldingMachineId = 5
			};

			//act
            var result = _productionBuilder
				.Init(production)
				.Build();

			//assert
            result.Should().Be(production);
        }

		[Theory()]
		[ClassData(typeof(AddMaterialStatusTestData))]
		public void AddMaterialStatus_ReturnCorrectProductionMaterialStatus_ForCorrectArguments(
			Domain.Entities.Production production, InjectionMold mold,
			Material material,bool isAvailable,int usage)
		{
			//act
			var result = _productionBuilder
				.Init(production)
				.CalculateProductionTime()
				.AddMaterialStatus(mold,material)
				.Build();

			//assert
			result.MaterialStatus.MaterialIsAvailable
				.Should()
				.Be(isAvailable);
			result.MaterialStatus.MaterialUsage
				.Should()
				.Be(usage);
		}

		[Theory()]
		[ClassData(typeof(RemoveMaterialDemandsTestData))]
		public void RemoveMaterialDemands_ReturnUpdatedMaterial_ForCorrectArguments(
			Domain.Entities.Production production, InjectionMold mold,
			Material material, int demands)
		{
			//act
			_productionBuilder
				.Init(production)
				.CalculateProductionTime()
				.RemoveMaterialDemands(mold, material);

			//assert
			material.Stock.PlannedMaterialDemand.Should().Be(demands);
		}
	}
}
