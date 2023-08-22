using Production.Application.InventoryHandling;
using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData.InventoryHandlingTestData
{
    public class RemoveMaterialDemandTestData : IEnumerable<object[]>
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
                        PlannedMaterialDemand = 0,
                    }
                },

                new MaterialRequirements(0,0),

				0
			};

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

				new MaterialRequirements(4,25),

				0
			};      
			
			yield return new object[]
            {
				new Domain.Entities.Material()
				{
					Stock = new MaterialStock()
					{
						MaterialInStock = 0,
						PlannedMaterialDemand = 1100,
					}
				},

				new MaterialRequirements(4,25),

				1000
			};

			yield return new object[]
			{
				new Domain.Entities.Material()
				{
					Stock = new MaterialStock()
					{
						MaterialInStock = 200,
						PlannedMaterialDemand = 100,
					}
				},

				new MaterialRequirements(4,25),

				0
			};

			yield return new object[]
			{
				new Domain.Entities.Material()
				{
					Stock = new MaterialStock()
					{
						MaterialInStock = 1200,
						PlannedMaterialDemand = 600,
					}
				},

				new MaterialRequirements(4,25),

				0
			};
		}

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
