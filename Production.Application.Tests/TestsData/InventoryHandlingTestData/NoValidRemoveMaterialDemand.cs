using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData.InventoryHandlingTestData
{
    public class NoValidRemoveMaterialDemand : IEnumerable<object[]>
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
                        MaterialInStock = 0,
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
                        MaterialInStock = 500,
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
                        MaterialInStock = 550,
                        PlannedMaterialDemand = 750
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
                        MaterialInStock = 550,
                        PlannedMaterialDemand = 550
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
                        MaterialInStock = 250,
                        PlannedMaterialDemand = 251
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
                        MaterialInStock = 300,
                        PlannedMaterialDemand = 299
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
                        MaterialInStock = 300,
                        PlannedMaterialDemand = 155
                     }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
