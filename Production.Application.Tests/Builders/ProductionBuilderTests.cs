using FluentAssertions;
using Production.Application.Builders;
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
			_productionBuilder.Init(production);
            var result = _productionBuilder.Build();

			//assert
            result.Should().Be(production);
        }
	}
}
