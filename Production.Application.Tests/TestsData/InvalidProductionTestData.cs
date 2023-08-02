﻿using Production.Application.Productions;
using Production.Domain.Entities;
using System.Collections;

namespace Production.Application.Tests.TestsData
{
	public class InvalidProductionTestData : IEnumerable<object[]>
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
					End = DateTime.Now.AddMinutes(59), //invalid end time
					InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
					InjectionMoldingMachineId = 1
				}
			};

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
					End = DateTime.Now,
					InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c1"), //id doesn't match
					InjectionMoldingMachineId = 4 //id doesn't match
				}
			};

			yield return new object[]
			{
				new InjectionMold(),	//nulls
				new InjectionMoldingMachine(),
				new ProductionDto()
			};

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
							Id=3,
                            InjectionMoldId = new Guid(),
							Start = new DateTime(2002,2,2,14,30,00),
							End = new DateTime(2002,2,2,22,30,00) 
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
					Id=1,
                    Start = new DateTime(2002,2,2,14,30,00), // mold scheduled for another production
                    End = new DateTime(2002,2,2,22,30,00),
                    InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                    InjectionMoldingMachineId = 1
                }
            };

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
                            Id=3,
                            Start = new DateTime(2002,2,2,14,30,00),
                            End = new DateTime(2002,2,2,22,30,00)
                        }
                    }
                },
                new ProductionDto()
                {
                    Id=1,
                    Start = new DateTime(2002,2,2,14,30,00), // machine scheduled for another production
                    End = new DateTime(2002,2,2,22,30,00),
                    InjectionMoldId = new Guid("2e5a5182-3999-4a4c-ec3f-18db7f8126c4"),
                    InjectionMoldingMachineId = 1
                }
            };
        }
			IEnumerator IEnumerable.GetEnumerator () => GetEnumerator();
	}
}

