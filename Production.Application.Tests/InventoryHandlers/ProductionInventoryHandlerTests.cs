using Moq;
using Production.Application.Interfaces;
using Production.Domain.Interfaces;
using Production.Domain.Entities;
using Xunit;
using FluentAssertions;
using Production.Application.Tests.TestsData.ProductionInventoryHandlingTestData;

namespace Production.Application.InventoryHandlers.Tests
{
	public class ProductionInventoryHandlerTests
	{
		[Theory()]
		[ClassData(typeof(AddMaterialReservationTestData))]
		public async Task AddMaterialReservation_ReturnCorrectMaterialStatusDto_ForCorrectArguments(
			Domain.Entities.Production production,InjectionMold mold,
			Material material, bool isAvailable, int usage)
		{
			//assert

			production.ProductionTimeCalculation();

			var productionInventoryHandler = CreateProductionInventoryHandler(material, mold);

			//act

			var result = await productionInventoryHandler.AddMaterialReservation(production);

			//arrange

			result.MaterialIsAvailable.Should().Be(isAvailable);
			result.MaterialUsage.Should().Be(usage);
		}

		private ProductionInventoryHandler CreateProductionInventoryHandler(Material material, InjectionMold mold)
		{
			var mockMaterialRepo = new Mock<IMaterialRepository>();
			mockMaterialRepo.Setup(e => e.GetByMoldId(It.IsAny<Guid>())).ReturnsAsync(material);

			var mockMoldRepo = new Mock<IInjectionMoldRepository>();
			mockMoldRepo.Setup(e => e.GetById(It.IsAny<Guid>(), false))
				.ReturnsAsync(mold);

			var mockMaterialInventoryHandler = new Mock<IMaterialInventoryHandler>();

			var productionInventoryHandler = new ProductionInventoryHandler(mockMaterialRepo.Object,
				mockMaterialInventoryHandler.Object, mockMoldRepo.Object);

			return productionInventoryHandler;
		}
	}
}