using FluentAssertions;
using Production.Domain.Entities;
using Production.Domain.Tests.TestsData;
using Xunit;

namespace Production.Domain.Tests.Entities
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