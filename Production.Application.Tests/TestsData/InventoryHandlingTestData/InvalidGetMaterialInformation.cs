using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData.InventoryHandlingTestData
{
    public class InvalidGetMaterialInformation : IEnumerable<object[]>
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
                        Consumption = -210
                    }
                }
            };
            yield return new object[]
            {
                -25,
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
                -115,
                new Domain.Entities.Material()
                {
                    InjectionMold = new InjectionMold()
                    {
                        Consumption = -50
                    }
                }
            };
            yield return new object[]
            {
                null,
                new Domain.Entities.Material()
                {
                    InjectionMold = new InjectionMold()
                    {
                        Consumption = 101
                    }
                }
            };
            yield return new object[]
            {
                11,
                new Domain.Entities.Material()
                {
                    InjectionMold = new InjectionMold()
                    {
                    }
                }
            };
            yield return new object[]
            {
                1,
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
