using Production.Application.Dtos;
using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData.ValidatorsTestData
{
    sealed class IncorrectProductionDtoValidatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new InjectionMold()
                {
                    Id = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                    Productions = new List<Domain.Entities.Production>()
                    {
                        new Domain.Entities.Production()
                        {
                            Id=3,
                            InjectionMoldId = new Guid(),
                            Start = new DateTime(2002,2,2,12,30,00),
                            End = new DateTime(2002,2,2,14,30,00)
                        },
                        new Domain.Entities.Production()
                        {
                            Id=3,
                            InjectionMoldId = new Guid(),
                            Start = new DateTime(2002,2,2,15,29,59),
                            End = new DateTime(2002,2,2,22,30,00)
                        }
                    },

                    MaterialId = 1
                },
                new InjectionMoldingMachine()
                {
                    Id = 1,                    
                    Productions = new List<Domain.Entities.Production>()
                    {                        
                        new Domain.Entities.Production()
                        {
                            Id=3,
                            InjectionMoldId = new Guid(),
                            Start = new DateTime(2002,2,2,12,30,00),
                            End = new DateTime(2002,2,2,14,30,00)
                        },
                        new Domain.Entities.Production()
                        {
                            Id=3,
                            InjectionMoldId = new Guid(),
                            Start = new DateTime(2002,2,2,15,29,59),
                            End = new DateTime(2002,2,2,22,30,00)
                        }
                    },
                },
                new ProductionDto()
                {
                    Start = new DateTime(2002,2,2,14,30,01),
                    End = new DateTime(2002,2,2,15,30,00),
					InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                    InjectionMoldingMachineId = 1
                }
            };  
            
            yield return new object[]
            {
                new InjectionMold()
                {
                    Id = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                    Productions = new List<Domain.Entities.Production>()
                    {
                        new Domain.Entities.Production()
                        {
                            Id=3,
                            InjectionMoldId = new Guid(),
                            Start = new DateTime(2002,2,2,12,30,00),
                            End = new DateTime(2002,2,2,14,30,02)
                        },
                        new Domain.Entities.Production()
                        {
                            Id=3,
                            InjectionMoldId = new Guid(),
                            Start = new DateTime(2002,2,2,15,30,00),
                            End = new DateTime(2002,2,2,22,30,00)
                        }
                    },

                    MaterialId = 1
                },
                new InjectionMoldingMachine()
                {
                    Id = 1,                    
                    Productions = new List<Domain.Entities.Production>()
                    {                        
                        new Domain.Entities.Production()
                        {
                            Id=3,
                            InjectionMoldId = new Guid(),
                            Start = new DateTime(2002,2,2,12,30,00),
                            End = new DateTime(2002,2,2,14,30,02)
                        },
                        new Domain.Entities.Production()
                        {
                            Id=3,
                            InjectionMoldId = new Guid(),
                            Start = new DateTime(2002,2,2,15,30,00),
                            End = new DateTime(2002,2,2,22,30,00)
                        }
                    },
                },
                new ProductionDto()
                {
                    Start = new DateTime(2002,2,2,14,30,01),
                    End = new DateTime(2002,2,2,15,30,00),
					InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                    InjectionMoldingMachineId = 1
                }
            };                
            
            yield return new object[]
            {
                new InjectionMold()
                {
                    Id = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                    Productions = new List<Domain.Entities.Production>()
                    {
                        new Domain.Entities.Production()
                        {
                            Id=3,
                            InjectionMoldId = new Guid(),
                            Start = new DateTime(2002,2,2,12,30,00),
                            End = new DateTime(2002,2,2,14,30,02)
                        },
                        new Domain.Entities.Production()
                        {
                            Id=3,
                            InjectionMoldId = new Guid(),
                            Start = new DateTime(2002,2,2,15,29,59),
                            End = new DateTime(2002,2,2,22,30,00)
                        }
                    },

                    MaterialId = 1
                },
                new InjectionMoldingMachine()
                {
                    Id = 1,                    
                    Productions = new List<Domain.Entities.Production>()
                    {                        
                        new Domain.Entities.Production()
                        {
                            Id=3,
                            InjectionMoldId = new Guid(),
                            Start = new DateTime(2002,2,2,12,30,00),
                            End = new DateTime(2002,2,2,14,30,02)
                        },
                        new Domain.Entities.Production()
                        {
                            Id=3,
                            InjectionMoldId = new Guid(),
                            Start = new DateTime(2002,2,2,15,29,59),
                            End = new DateTime(2002,2,2,22,30,00)
                        }
                    },
                },
                new ProductionDto()
                {
                    Start = new DateTime(2002,2,2,14,30,01),
                    End = new DateTime(2002,2,2,15,30,00),
					InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                    InjectionMoldingMachineId = 1
                }
            };

            yield return new object[]
            {
                new InjectionMold(),
                new InjectionMoldingMachine(),
                new ProductionDto()
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
