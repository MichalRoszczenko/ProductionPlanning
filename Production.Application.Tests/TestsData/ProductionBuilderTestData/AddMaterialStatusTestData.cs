using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData.ProductionBuilderTestData
{
	public class AddMaterialStatusTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[]
			{
				new Domain.Entities.Production()
				{
					Start = new DateTime(2023, 12, 5, 15, 00, 50),
					End = new DateTime(2023, 12, 6, 15, 00, 50),
				},

				new InjectionMold()
				{
					Consumption = 20
				},

				new Material()
				{
					Stock = new MaterialStock()
					{
						MaterialInStock = 500,
						PlannedMaterialDemand = 19
					}
				},
				true,
				480
			};

			yield return new object[]
			{
				new Domain.Entities.Production()
				{
					Start = new DateTime(2023, 12, 5, 15, 00, 50),
					End = new DateTime(2023, 12, 6, 15, 00, 51),
				},

				new InjectionMold()
				{
					Consumption = 20
				},

				new Material()
				{
					Stock = new MaterialStock()
					{
						MaterialInStock = 500,
						PlannedMaterialDemand = 0
					}
				},
				true,
				500
			};

			yield return new object[]
			{
				new Domain.Entities.Production()
				{
					Start = new DateTime(2023, 12, 5, 15, 00, 50),
					End = new DateTime(2023, 12, 6, 15, 00, 51),
				},

				new InjectionMold()
				{
					Consumption = 20
				},

				new Material()
				{
					Stock = new MaterialStock()
					{
						MaterialInStock = 500,
						PlannedMaterialDemand = 1
					}
				},
				false,
				500
			};

			yield return new object[]
			{
				new Domain.Entities.Production()
				{
					Start = new DateTime(2023, 12, 5, 15, 00, 50),
					End = new DateTime(2023, 12, 6, 15, 00, 49),
				},

				new InjectionMold()
				{
					Consumption = 20
				},

				new Material()
				{
					Stock = new MaterialStock()
					{
						MaterialInStock = 500,
						PlannedMaterialDemand = 0
					}
				},
				true,
				480
			};
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
