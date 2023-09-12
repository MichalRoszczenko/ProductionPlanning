using System.Collections;

namespace Production.Application.Tests.TestsData.InventoryHandlingTestData
{
    public class CalculateDemandsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 400,
                        PlannedMaterialDemand = 400
                    }
                },
                new List<Domain.Entities.Production>()
                {
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {   
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    }
                },
                new bool[] {true,true,true,true}
            }; 
            
            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 300,
                        PlannedMaterialDemand = 400
                    }
                },
                new List<Domain.Entities.Production>()
                {
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {   
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    }
                },
                new bool[] {true,true,true,false}
            };

            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 0,
                        PlannedMaterialDemand = 400
                    }
                },
                new List<Domain.Entities.Production>()
                {
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {   
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    }
                },
                new bool[] { false, false, false, false}
            };            
            
            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 299,
                        PlannedMaterialDemand = 400
                    }
                },
                new List<Domain.Entities.Production>()
                {
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {   
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    }
                },
                new bool[] { true, true, false, false}
            };         
            
            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 301,
                        PlannedMaterialDemand = 400
                    }
                },
                new List<Domain.Entities.Production>()
                {
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {   
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    }
                },
                new bool[] { true, true, true, false}
            };

            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 99,
                        PlannedMaterialDemand = 400
                    }
                },
                new List<Domain.Entities.Production>()
                {
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {   
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    }
                },
                new bool[] { false, false, false, false}
            }; 
            
            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 399,
                        PlannedMaterialDemand = 400
                    }
                },
                new List<Domain.Entities.Production>()
                {
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {   
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    }
                },
                new bool[] { true, true, true, false}
            };            
                     
            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 401,
                        PlannedMaterialDemand = 400
                    }
                },
                new List<Domain.Entities.Production>()
                {
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {   
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialUsage = 100,
                            MaterialIsAvailable = false,
                        }
                    }
                },
                new bool[] { true, true, true, true}
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
