using Production.Application.Productions;
using System.Collections;

namespace Production.Presentation.Tests.TestsData
{
	public class ProductionOutputDtoTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[]
			{
				new List<ProductionDtoOutput>()
				{
					new ProductionDtoOutput()
					{
						Start = new DateTime(2023,08,15,15,20,00),
						End = new DateTime(2023,08,15,15,20,00),
						InjectionMoldingMachineName = "TestMachine1",
						InjectionMoldName = "TestMold1"
					},
					new ProductionDtoOutput()
					{
						Start = new DateTime(2023,08,15,15,20,00),
						End = new DateTime(2023,08,15,15,20,00),
						InjectionMoldingMachineName = "TestMachine2",
						InjectionMoldName = "TestMold2"
					},
					new ProductionDtoOutput()
					{
						Start = new DateTime(2023,08,15,15,20,00),
						End = new DateTime(2023,08,15,15,20,00),
						InjectionMoldingMachineName = "TestMachine3",
						InjectionMoldName = "TestMold3"
					}
				}
			};
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
