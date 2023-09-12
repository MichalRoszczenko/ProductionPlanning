using System.Collections;

namespace Production.Application.Tests.TestsData.InventoryHandlingTestData
{
    public class RemoveMaterialFromProductionTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                },
                new List<Domain.Entities.Production>()
                {
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    },
                    new Domain.Entities.Production()
                    {   
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 2 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 3 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    }
                },
                new bool[] {false,true,true,false}
            };            
            
            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 1,
                },
                new List<Domain.Entities.Production>()
                {
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 5 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    },
                    new Domain.Entities.Production()
                    {   
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 2 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 3 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 1 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
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
                },
                new List<Domain.Entities.Production>()
                {
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 7 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    },
                    new Domain.Entities.Production()
                    {   
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 2 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 3 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 4 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    }
                },
                new bool[] { true, true,true, true }
            };            
            
            yield return new object[]
            {
                new Domain.Entities.Material()
                {
                    Id = 11,
                },
                new List<Domain.Entities.Production>()
                {
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 11 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    },
                    new Domain.Entities.Production()
                    {   
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 11 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 11 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    },
                    new Domain.Entities.Production()
                    {
                        InjectionMold = new Domain.Entities.InjectionMold() { MaterialId = 11 },
                        MaterialStatus = new Domain.Entities.MaterialStatus()
                        {
                            MaterialIsAvailable = true,
                        }
                    }
                },
                new bool[] { false, false, false, false }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
