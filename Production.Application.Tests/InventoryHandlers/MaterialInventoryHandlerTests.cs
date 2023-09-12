using FluentAssertions;
using Moq;
using Production.Application.Dtos;
using Production.Application.InventoryHandling;
using Production.Application.Tests.TestsData.InventoryHandlingTestData;
using Production.Domain.Interfaces;
using Production.Domain.Entities;
using Xunit;

namespace Production.Application.Tests.InventoryHandlers
{
    public class MaterialInventoryHandlerTests
    {
        [Theory()]
        [ClassData(typeof(AddMaterialDemandTestData))]
        public void AddMaterialDemand_CalculateMaterialToOrder_ForCorrectArguments(Material material,
            MaterialRequirements materialRequirementsInfo, int materialToOrder)
        {
            //arrange

            material.Stock.CountMaterialToOrder();
            var startedMaterialInStock = material.Stock.MaterialInStock;
            var startedMaterialDemand = material.Stock.PlannedMaterialDemand;

            var materialhandler = GetMaterialHandler();

            //act

            materialhandler.AddMaterialDemand(material, materialRequirementsInfo);

            //assert

            material.Stock.MaterialInStock.Should().Be(startedMaterialInStock);
            material.Stock.PlannedMaterialDemand.Should().Be(startedMaterialDemand + materialRequirementsInfo.Usage);
            material.Stock.MaterialToOrder.Should().Be(materialToOrder);
        }

        [Theory()]
        [ClassData(typeof(RemoveMaterialDemandTestData))]
        public void RemoveMaterialDemand_CalculateMaterialToOrder_ForCorrectArguments(Material material,
            MaterialRequirements materialRequirementsInfo, int materialToOrder)
        {
            //arrange

            material.Stock.CountMaterialToOrder();
            var startedMaterialInStock = material.Stock.MaterialInStock;
            var startedMaterialDemand = material.Stock.PlannedMaterialDemand;

            var materialhandler = GetMaterialHandler();

            //act

            materialhandler.RemoveMaterialDemand(material, materialRequirementsInfo);

            //assert

            material.Stock.MaterialInStock.Should().Be(startedMaterialInStock);
            material.Stock.PlannedMaterialDemand.Should().Be(startedMaterialDemand - materialRequirementsInfo.Usage);
            material.Stock.MaterialToOrder.Should().Be(materialToOrder);
        }

        [Theory()]
        [ClassData(typeof(CalculateDemandsTestData))]
        public async Task CalculateDemands_ReturnCorrectMaterialIsAvailableStatus_ForCorrectArguments(
            Material material, List<Domain.Entities.Production> productions, bool[] expectedResults)
        {
            //arrange

            MaterialInventoryHandler materialHandler = GetMaterialHandlerWithMockedProductions(productions);

            //act

            await materialHandler.CalculateDemands(material);

            //assert

            for (int i = 0; i < productions.Count; i++)
            {
                productions[i].MaterialStatus.MaterialIsAvailable.Should().Be(expectedResults[i]);
            }
        }

        [Theory()]
        [ClassData(typeof(RemoveMaterialFromProductionTestData))]
        public async Task RemoveMaterialFromProduction_ReturnCorrectMaterialIsAvailable_ForCorrectArguments(
            Material material, List<Domain.Entities.Production> productions, bool[] expectedResults)
        {
            //assert

            MaterialInventoryHandler materialHandler = GetMaterialHandlerWithMockedProductions(productions);

            //act

            await materialHandler.RemoveMaterialFromProductions(material);

            //assert

            for (int i = 0; i < productions.Count; i++)
            {
                productions[i].MaterialStatus.MaterialIsAvailable.Should().Be(expectedResults[i]);
            }
        }

        private static MaterialInventoryHandler GetMaterialHandlerWithMockedProductions(List<Domain.Entities.Production> productions)
        {
            var mockIProductionRepository = new Mock<IProductionRepository>();
            mockIProductionRepository.Setup(x => x.GetAll()).ReturnsAsync(productions);
            var materialhandler = new MaterialInventoryHandler(mockIProductionRepository.Object);

            return materialhandler;
        }

        private static MaterialInventoryHandler GetMaterialHandler()
        {
            var mockIProductionRepository = new Mock<IProductionRepository>();
            var materialhandler = new MaterialInventoryHandler(mockIProductionRepository.Object);

            return materialhandler;
        }
    }
}