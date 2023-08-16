using Production.Domain.Entities;
using System.Collections;

namespace Production.Domain.Tests.TestsData
{
    public class ValidCountMaterialToOrderTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new MaterialStock()
                {
                    MaterialInStock = 0,
                    PlannedMaterialDemand = 0
                },
                0
            };             
            
            yield return new object[]
            {
                new MaterialStock()
                {
                    MaterialInStock = 550,
                    PlannedMaterialDemand = 0
                },
                0
            };          
            
            yield return new object[]
            {
                new MaterialStock()
                {
                    MaterialInStock = 0,
                    PlannedMaterialDemand = 100
                },
                100
            };        
            
            yield return new object[]
            {
                new MaterialStock()
                {
                    MaterialInStock = 550,
                    PlannedMaterialDemand = 750
                },
                200
            };  
            
            yield return new object[]
            {
                new MaterialStock()
                {
                    MaterialInStock = 550,
                    PlannedMaterialDemand = 550
                },
                0
            }; 
            
            yield return new object[]
            {
                new MaterialStock()
                {
                    MaterialInStock = 250,
                    PlannedMaterialDemand = 251
                },
                1
            }; 
                        
            yield return new object[]
            {
                new MaterialStock()
                {
                    MaterialInStock = 300,
                    PlannedMaterialDemand = 299
                },
                0
            };
            
            yield return new object[]
            {
                new MaterialStock()
                {
                    MaterialInStock = 300,
                    PlannedMaterialDemand = 155
                },
                0
            };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
