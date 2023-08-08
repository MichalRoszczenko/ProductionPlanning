using Production.Application.Productions;
using System.Collections;

namespace Production.Presentation.Tests.Controllers.ProductionControllerTests.TestsData
{
    public class ProductionDtoTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<ProductionDto>()
                {
                    new ProductionDto()
                    {
                        Start = new DateTime(2023,08,15,15,20,00),
                        End = new DateTime(2023,08,15,15,20,00),
                        InjectionMoldingMachineName = "TestMachine1",
                        InjectionMoldName = "TestMold1"
                    },
                    new ProductionDto()
                    {
                        Start = new DateTime(2023,08,15,15,20,00),
                        End = new DateTime(2023,08,15,15,20,00),
                        InjectionMoldingMachineName = "TestMachine2",
                        InjectionMoldName = "TestMold2"
                    },
                    new ProductionDto()
                    {
                        Start = new DateTime(2023,08,15,15,20,00),
                        End = new DateTime(2023,08,15,15,20,00),
                        InjectionMoldingMachineName = "TestMachine3",
                        InjectionMoldName = "TestMold3"
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
