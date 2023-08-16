using FluentAssertions;
using Production.Application.Tests.TestsData.InventoryHandlingTestData;
using Xunit;

namespace Production.Application.InventoryHandling.Tests
{
    public class MaterialInventoryHandlerTests
    {
        [Theory()]
        [ClassData(typeof(ValidGetMaterialInformation))]
        public void GetMaterialInformation_ReturnCorrectMaterialInfoDto_ForValidArguments(int productionTime, Domain.Entities.Material material)
        {
            //arrange

            var materialhandler = new MaterialInventoryHandler();

            //act

            var materialInformationDto = materialhandler.GetMaterialInformation(productionTime, material);

            //assert

            materialInformationDto.Usage.Should().Be((int)Math.Ceiling(material.InjectionMold!.Consumption * productionTime));
            materialInformationDto.Consumption.Should().Be(material.InjectionMold.Consumption);
            materialInformationDto.ProductionTime.Should().Be(productionTime);
        }

        [Theory()]
        [ClassData(typeof(NoValidGetMaterialInformation))]
        public void GetMaterialInformation_ThrowException_ForNoValidArguments(int productionTime, Domain.Entities.Material material)
        {
            //arrange

            var materialhandler = new MaterialInventoryHandler();

            //act

            var action = () => materialhandler.GetMaterialInformation(productionTime, material);

            //assert

            action.Should().Throw<ArgumentException>();
        }

        [Theory()]
        [ClassData(typeof(ValidMaterialDemand))]
        public void AddMaterialDemand_ReturnCorrectMaterial_ForValidArguments(int productionTime, decimal consumption , Domain.Entities.Material material)
        {
            //arrange

            material.Stock.CountMaterialToOrder();
            var startedMaterialToOrder = material.Stock.MaterialToOrder;
            var startedMaterialInStock= material.Stock.MaterialInStock;
            var startedMaterialDemand = material.Stock.PlannedMaterialDemand;

            var materialhandler = new MaterialInventoryHandler();

            var materialInformationDto = new MaterialInformationDto(productionTime, consumption);

            //act

            materialhandler.AddMaterialDemand(material, materialInformationDto);

            //assert

            material.Stock.PlannedMaterialDemand.Should().Be(startedMaterialDemand + materialInformationDto.Usage);
            material.Stock.MaterialToOrder.Should()
                .Be(startedMaterialInStock < material.Stock.PlannedMaterialDemand 
                ? material.Stock.PlannedMaterialDemand - startedMaterialInStock 
                : startedMaterialToOrder);
        }

        [Theory()]
        [ClassData(typeof(ValidMaterialDemand))]
        public void RemoveMaterialDemand_ReturnCorrectMaterial_ForValidArguments(int productionTime, decimal consumption, Domain.Entities.Material material)
        {
            //arrange

            material.Stock.CountMaterialToOrder();
            var startedMaterialToOrder = material.Stock.MaterialToOrder;
            var startedMaterialInStock = material.Stock.MaterialInStock;
            var startedMaterialDemand = material.Stock.PlannedMaterialDemand;

            var materialhandler = new MaterialInventoryHandler();

            var materialInformationDto = new MaterialInformationDto(productionTime, consumption);

            //act

            materialhandler.RemoveMaterialDemand(material, materialInformationDto);

            //assert

            material.Stock.PlannedMaterialDemand.Should().Be(startedMaterialDemand - materialInformationDto.Usage);
            material.Stock.MaterialToOrder.Should()
                .Be(startedMaterialInStock <= material.Stock.PlannedMaterialDemand
                ? material.Stock.PlannedMaterialDemand - startedMaterialInStock
                : startedMaterialToOrder);
        }

        [Theory()]
        [ClassData(typeof(NoValidRemoveMaterialDemand))]
        public void RemoveMaterialDemand_ThrowException_ForNoValidArguments(int productionTime, decimal consumption, Domain.Entities.Material material)
        {
            //arrange

            var startedMaterialToOrder = material.Stock.MaterialToOrder;
            var startedMaterialInStock = material.Stock.MaterialInStock;
            var startedMaterialDemand = material.Stock.PlannedMaterialDemand;

            var materialhandler = new MaterialInventoryHandler();

            var materialInformationDto = new MaterialInformationDto(productionTime, consumption);

            //act

            Action action = () => materialhandler.RemoveMaterialDemand(material, materialInformationDto);

            //assert

            action.Should().Throw<ArgumentException>();
        }
    }
}