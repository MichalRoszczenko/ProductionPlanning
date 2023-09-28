using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData.ProductionBuilderTestData
{
	public class RemoveMaterialDemandsTestData : IEnumerable<object[]>
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
						PlannedMaterialDemand = 500
					}
				},
				20
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
						MaterialInStock = 2500,
						PlannedMaterialDemand = 2501
					}
				},
				2001
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
						PlannedMaterialDemand = 500
					}
				},
				0
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
						PlannedMaterialDemand = 481
					}
				},
				1
			};
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
