using FluentAssertions;
using Moq;
using Production.Application.InventoryHandling;
using Production.Application.Tests.TestsData.InventoryHandlingTestData;
using Production.Domain.Interfaces;
using Xunit;

namespace Production.Application.Tests.InventoryHandling
{
	public class MaterialInventoryHandlerTests
	{
		[Theory()]
		[ClassData(typeof(AddMaterialDemandTestData))]
		public void AddMaterialDemand_CalculateMaterialToOrder_ForValidArguments(Domain.Entities.Material material,
			MaterialRequirements materialRequirementsInfo, int materialToOrder)
		{
			//arrange
			material.Stock.CountMaterialToOrder();
			var startedMaterialInStock = material.Stock.MaterialInStock;
			var startedMaterialDemand = material.Stock.PlannedMaterialDemand;

			var mockIProductionRepository = new Mock<IProductionRepository>();
			var materialhandler = new MaterialInventoryHandler(mockIProductionRepository.Object);

			//act

			materialhandler.AddMaterialDemand(material, materialRequirementsInfo);

			//assert

			material.Stock.MaterialInStock.Should().Be(startedMaterialInStock);
			material.Stock.PlannedMaterialDemand.Should().Be(startedMaterialDemand + materialRequirementsInfo.Usage);
			material.Stock.MaterialToOrder.Should().Be(materialToOrder);
		}

		[Theory()]
		[ClassData(typeof(RemoveMaterialDemandTestData))]
		public void RemoveMaterialDemand_CalculateMaterialToOrder_ForValidArguments(Domain.Entities.Material material,
			MaterialRequirements materialRequirementsInfo, int materialToOrder)
		{
			//arrange

			material.Stock.CountMaterialToOrder();
			var startedMaterialInStock = material.Stock.MaterialInStock;
			var startedMaterialDemand = material.Stock.PlannedMaterialDemand;

			var mockIProductionRepository = new Mock<IProductionRepository>();
			var materialhandler = new MaterialInventoryHandler(mockIProductionRepository.Object);

			//act

			materialhandler.RemoveMaterialDemand(material, materialRequirementsInfo);

			//assert

			material.Stock.MaterialInStock.Should().Be(startedMaterialInStock);
			material.Stock.PlannedMaterialDemand.Should().Be(startedMaterialDemand - materialRequirementsInfo.Usage);
			material.Stock.MaterialToOrder.Should().Be(materialToOrder);
		}

		[Theory()]
		[ClassData(typeof(CalculateDemandsTestData))]
		public async Task CalculateDemands_ReturnCorrectMaterialIsAvailableStatus_ForValidArguments(
			Domain.Entities.Material material, List<Domain.Entities.Production> productions, bool[] expectedResults)
		{
			//arrange

			var mockIProductionRepository = new Mock<IProductionRepository>();

			mockIProductionRepository.Setup(x => x.GetAll()).ReturnsAsync(productions);

			var materialhandler = new MaterialInventoryHandler(mockIProductionRepository.Object);

			//act

			await materialhandler.CalculateDemands(material);

			//assert

			for (int i = 0; i < productions.Count; i++)
			{
				productions[i].MaterialStatus.MaterialIsAvailable.Should().Be(expectedResults[i]);
			}
		}
	}
}