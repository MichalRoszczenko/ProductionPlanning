using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData.InventoryHandlingTestData
{
    public class ValidMaterialDemand : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                0,
                0,

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
                        PlannedMaterialDemand = 79
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
                        MaterialInStock = 0,
                        PlannedMaterialDemand = 100
                     }
                }
            };

            yield return new object[]
            {
                0,
                0,

                new Domain.Entities.Material()
                {
                     Stock = new MaterialStock()
                     {
                        MaterialInStock = 550,
                        PlannedMaterialDemand = 750,
                     }
                }
            };

            yield return new object[]
            {
                110,
                5,

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
                110,
                5,

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
                10,
                2,

                new Domain.Entities.Material()
                {
                     Stock = new MaterialStock()
                     {
                        MaterialInStock = 5,
                        PlannedMaterialDemand = 25
                     }
                }
            };            
            yield return new object[]
            {
                1,
                1,

                new Domain.Entities.Material()
                {
                     Stock = new MaterialStock()
                     {
                        MaterialInStock = 5,
                        PlannedMaterialDemand = 25
                     }
                }
            };
            
            yield return new object[]
            {
                0,
                0,

                new Domain.Entities.Material()
                {
                     Stock = new MaterialStock()
                     {
                        MaterialInStock = 5,
                        PlannedMaterialDemand = 25
                     }
                }
            };            
            
            yield return new object[]
            {
                5,
                2,

                new Domain.Entities.Material()
                {
                     Stock = new MaterialStock()
                     {
                        MaterialInStock = 5,
                        PlannedMaterialDemand = 25
                     }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
