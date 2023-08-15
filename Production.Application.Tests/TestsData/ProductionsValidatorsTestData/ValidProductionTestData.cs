using Production.Application.Productions;
using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData.ProductionsValidatorsTestData
{
    public class ValidProductionTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new InjectionMold()
                {
                    Id = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                    Name = "Test",
                    Size = "medium",
                    Producer = "GxTry",
                    Productions = new List<Domain.Entities.Production>()
                    {
                        new Domain.Entities.Production()
                        {
                            InjectionMoldId = new Guid()
                        }
                    }
                },
                new InjectionMoldingMachine()
                {
                    Id = 1,
                    Name = "Test",
                    Size = "medium",
                    Tonnage = 2000,
                    Productions = new List<Domain.Entities.Production>()
                    {
                        new Domain.Entities.Production()
                        {
                            InjectionMoldId = new Guid()
                        }
                    }
                },
                new ProductionDto()
                {
                    Start = DateTime.Now,
                    End = DateTime.Now.AddMinutes(60),
                    InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                    InjectionMoldingMachineId = 1
                }
            };

            yield return new object[]
            {
                new InjectionMold()
                {
                    Id = new Guid("2e5a5182-3939-4a4c-ec3f-18db7f8126c4"),
                    Name = "Te",
                    Size = "medium",
                    Producer = "GxTry",
                    Productions = new List<Domain.Entities.Production>()
                    {
                        new Domain.Entities.Production()
                        {
                            InjectionMoldId = new Guid()
                        }
                    }
                },
                new InjectionMoldingMachine()
                {
                    Id = 1,
                    Name = "Te",
                    Size = "medium",
                    Tonnage = 2000,
                    Productions = new List<Domain.Entities.Production>()
                    {
                        new Domain.Entities.Production()
                        {
                            InjectionMoldId = new Guid()
                        }
                    }
                },
                new ProductionDto()
                {
                    Start = DateTime.Now,
                    End = DateTime.Now.AddHours(1),
                    InjectionMoldId = new Guid("2e5a5182-3939-4a4c-ec3f-18db7f8126c4"),
                    InjectionMoldingMachineId = 1
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

