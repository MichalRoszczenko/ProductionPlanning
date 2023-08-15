using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData.InventoryHandlingTestData
{
    public class ValidUpdateMaterialInformation : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                15,
                0.5M,

                new Domain.Entities.Material()
                {
                     Stock = new MaterialStock()
                     {
                        MaterialInStock = 15,
                        PlannedMaterialDemand = 0
                     }
                }
            };
            yield return new object[]
            {
                25,
                3.1M,

                new Domain.Entities.Material()
                {
                     Stock = new MaterialStock()
                     {
                        MaterialInStock = 25,
                        PlannedMaterialDemand = 0
                     }
                }
            };
            yield return new object[]
            {
                22,
                1.5M,

                new Domain.Entities.Material()
                {
                     Stock = new MaterialStock()
                     {
                        MaterialInStock = 235,
                        PlannedMaterialDemand = 0
                     }
                }
            };
            yield return new object[]
            {
                232,
                23.5M,

                new Domain.Entities.Material()
                {
                     Stock = new MaterialStock()
                     {
                        MaterialInStock = 235,
                        PlannedMaterialDemand = 0
                     }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
