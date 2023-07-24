using Production.Application.Productions;
using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData
{
	public class InvalidProductionTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[]
			{
				new InjectionMold()
				{
					Id = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
					Name = "Test",
					Size = "medium",
					Producer = "GxTry"
				},
				new InjectionMoldingMachine()
				{
					Id = 1,
					Name = "Test",
					Size = "medium",
					Tonnage = 2000
				},
				new ProductionDto()
				{
					Start = DateTime.Now,
					End = DateTime.Now.AddMinutes(59), //invalid end time
					InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
					InjectionMoldingMachineId = 1
				}
			};
			yield return new object[]
			{
				new InjectionMold()
				{
					Id = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
					Name = "Test",
					Size = "medium",
					Producer = "GxTry"
				},
				new InjectionMoldingMachine()
				{
					Id = 1,
					Name = "Test",
					Size = "medium",
					Tonnage = 2000
				},
				new ProductionDto()
				{
					Start = DateTime.Now,
					End = DateTime.Now,
					InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c1"), //id doesn't match
					InjectionMoldingMachineId = 4 //id doesn't match
				}
			};
			yield return new object[]
			{
				new InjectionMold(),	//nulls
				new InjectionMoldingMachine(),
				new ProductionDto()
			};

		}
			IEnumerator IEnumerable.GetEnumerator () => GetEnumerator();
	}
}

