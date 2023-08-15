using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData.InventoryHandlingTestData
{
    public class ValidGetMaterialInformation : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                15,
                new Domain.Entities.Material()
                {
                    InjectionMold = new InjectionMold()
                    {
                        Consumption = 10
                    }
                }
            };
            yield return new object[]
            {
                25,
                new Domain.Entities.Material()
                {
                    InjectionMold = new InjectionMold()
                    {
                        Consumption = 40
                    }
                }
            };
            yield return new object[]
            {
                115,
                new Domain.Entities.Material()
                {
                    InjectionMold = new InjectionMold()
                    {
                        Consumption = 50
                    }
                }
            };
            yield return new object[]
            {
                85,
                new Domain.Entities.Material()
                {
                    InjectionMold = new InjectionMold()
                    {
                        Consumption = 101
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
