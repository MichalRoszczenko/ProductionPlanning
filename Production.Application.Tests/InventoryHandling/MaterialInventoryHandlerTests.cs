using FluentAssertions;
using Moq;
using Production.Application.Tests.TestsData.InventoryHandlingTestData;
using Production.Domain.Interfaces;
using Xunit;

namespace Production.Application.InventoryHandling.Tests
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
	}
}