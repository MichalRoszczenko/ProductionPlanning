using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData.InventoryHandlingTestData
{
    public class CheckMaterialDemandTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Stock = new MaterialStock()
                    {
                        MaterialInStock = 0,
                        PlannedMaterialDemand = 100,
                    }
                },

				100
			};            
			yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Stock = new MaterialStock()
                    {
                        MaterialInStock = 50,
                        PlannedMaterialDemand = 1100,
                    }
                },

				1050
			};

            yield return new object[]
            {
				new Domain.Entities.Material()
				{
					Stock = new MaterialStock()
					{
						MaterialInStock = 100,
						PlannedMaterialDemand = 100,
					}
				},
				0
			};      
			
			yield return new object[]
            {
				new Domain.Entities.Material()
				{
					Stock = new MaterialStock()
					{
						MaterialInStock = 1100,
						PlannedMaterialDemand = 1101,
					}
				},
				1
			};

			yield return new object[]
			{
				new Domain.Entities.Material()
				{
					Stock = new MaterialStock()
					{
						MaterialInStock = 200,
						PlannedMaterialDemand = 199,
					}
				},
				0
			};
		}

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
