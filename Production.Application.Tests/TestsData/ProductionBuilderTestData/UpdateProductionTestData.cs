using Production.Application.Dtos;
using System.Collections;

namespace Production.Application.Tests.TestsData.ProductionBuilderTestData
{
	public class UpdateProductionTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[]
			{
				new ProductionDto()
				{
					Start = new DateTime(2024, 1, 5, 15, 00, 50),
					End = new DateTime(2024, 2, 6, 15, 00, 50),
					InjectionMoldingMachineId = 1,
					InjectionMoldId = new Guid(),
				},
				new Domain.Entities.Production()
				{
					Start = new DateTime(2023, 12, 5, 15, 00, 50),
					End = new DateTime(2023, 12, 6, 15, 00, 50),
					InjectionMoldingMachineId = 51,
					InjectionMoldId = new Guid(),
				},
			};
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
