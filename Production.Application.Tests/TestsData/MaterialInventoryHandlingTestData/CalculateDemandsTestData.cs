using System.Collections;

namespace Production.Application.Tests.TestsData.InventoryHandlingTestData
{
    public class CalculateDemandsTestData : IEnumerable<object[]>
    {
        private List<Domain.Entities.Production> CreateProduction()
        {
            var prodList = new List<Domain.Entities.Production>();

			for (int i = 0; i<4;i++)
            {
				var prod = new Domain.Entities.Production()
				{
					Start = DateTime.Now,
					End = DateTime.Now.AddHours(3),
					InjectionMold = new Domain.Entities.InjectionMold()
					{
						MaterialId = 1,
						Consumption = 25
					},
					MaterialStatus = new Domain.Entities.MaterialStatus()
					{
						MaterialIsAvailable = false,
					}
				};
				prodList.Add(prod);
            }

            return prodList;
		}

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 400,
                        PlannedMaterialDemand = 400
                    }
                },
                CreateProduction()
,
                new bool[] {true,true,true,true}
            };

            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 300,
                        PlannedMaterialDemand = 400
                    }
                },
                CreateProduction(),

				new bool[] {true,true,true,false}
            };

            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 0,
                        PlannedMaterialDemand = 400
                    }
                },
                CreateProduction(),
                new bool[] { false, false, false, false}
            };

            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 299,
                        PlannedMaterialDemand = 400
                    }
                },
				CreateProduction(),
				new bool[] { true, true, false, false}
            };

            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 301,
                        PlannedMaterialDemand = 400
                    }
                },
				CreateProduction(),
				new bool[] { true, true, true, false}
            };

            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 99,
                        PlannedMaterialDemand = 400
                    }
                },
				CreateProduction(),
				new bool[] { false, false, false, false}
            };

            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 399,
                        PlannedMaterialDemand = 400
                    }
                },
				CreateProduction(),
				new bool[] { true, true, true, false}
            };

            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 401,
                        PlannedMaterialDemand = 400
                    }
                },
				CreateProduction(),
				new bool[] { true, true, true, true}
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
