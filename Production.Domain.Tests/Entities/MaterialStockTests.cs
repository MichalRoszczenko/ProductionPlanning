using FluentAssertions;
using Production.Domain.Tests.TestsData;
using Xunit;

namespace Production.Domain.Entities.Tests
{
    public class MaterialStockTests
    {
        [Theory()]
        [ClassData(typeof(ValidCountMaterialToOrderTestData))]
        public void CountMaterialToOrder_ReturnMaterialToOrder_ForValidProperties(MaterialStock materialStock, int materialToOrder)
        {
            //act

            materialStock.CountMaterialToOrder();

            //assert

            materialStock.MaterialToOrder.Should().Be(materialToOrder);
        }
    }
}