using FluentAssertions;
using Production.Application.Tests.TestsData.InventoryHandlingTestData;
using Xunit;

namespace Production.Application.InventoryHandling.Tests
{
    public class MaterialInventoryHandlerTests
    {
  //      [Theory()]
  //      [ClassData(typeof(AddMaterialDemandTestData))]
  //      public void AddMaterialDemand_CalculateMaterialToOrder_ForValidArguments(Domain.Entities.Material material, 
  //          MaterialRequirements materialRequirementsInfo, int materialToOrder)
  //      {
  //          //arrange
  //          material.Stock.CountMaterialToOrder();
		//	var startedMaterialInStock = material.Stock.MaterialInStock;
		//	var startedMaterialDemand = material.Stock.PlannedMaterialDemand;

		//	var materialhandler = new MaterialInventoryHandler();

		//	//act

  //          materialhandler.AddMaterialDemand(material, materialRequirementsInfo);

  //          //assert

		//	material.Stock.MaterialInStock.Should().Be(startedMaterialInStock);
		//	material.Stock.PlannedMaterialDemand.Should().Be(startedMaterialDemand+materialRequirementsInfo.Usage);
  //          material.Stock.MaterialToOrder.Should().Be(materialToOrder);
		//}

		//[Theory()]
		//[ClassData(typeof(RemoveMaterialDemandTestData))]
		//public void RemoveMaterialDemand_CalculateMaterialToOrder_ForValidArguments(Domain.Entities.Material material,
		//	MaterialRequirements materialRequirementsInfo, int materialToOrder)
		//{
		//	//arrange

		//	material.Stock.CountMaterialToOrder();
		//	var startedMaterialInStock = material.Stock.MaterialInStock;
		//	var startedMaterialDemand = material.Stock.PlannedMaterialDemand;

		//	var materialhandler = new MaterialInventoryHandler();

		//	//act

		//	materialhandler.RemoveMaterialDemand(material, materialRequirementsInfo);

		//	//assert

		//	material.Stock.MaterialInStock.Should().Be(startedMaterialInStock);
		//	material.Stock.PlannedMaterialDemand.Should().Be(startedMaterialDemand - materialRequirementsInfo.Usage);
		//	material.Stock.MaterialToOrder.Should().Be(materialToOrder);
		//}

		//[Theory()]
		//[ClassData(typeof(CheckMaterialDemandTestData))]
		//public void CheckMaterialDemand_CalculateMaterialToOrder_ForValidArguments(Domain.Entities.Material material, int materialToOrder)
		//{
		//	//arrange

		//	material.Stock.CountMaterialToOrder();
		//	var startedMaterialInStock = material.Stock.MaterialInStock;
		//	var startedMaterialDemand = material.Stock.PlannedMaterialDemand;

		//	var materialhandler = new MaterialInventoryHandler();

		//	//act

		//	materialhandler.CheckMaterialDemand(material);

		//	//assert

		//	material.Stock.MaterialInStock.Should().Be(startedMaterialInStock);
		//	material.Stock.PlannedMaterialDemand.Should().Be(startedMaterialDemand);
		//	material.Stock.MaterialToOrder.Should().Be(materialToOrder);
		//}
	}
}