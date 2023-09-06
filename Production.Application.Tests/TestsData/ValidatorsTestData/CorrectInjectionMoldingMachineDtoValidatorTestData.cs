using Production.Application.Dtos;
using System.Collections;

namespace Production.Application.Tests.TestsData.ValidatorsTestData
{
    public class CorrectInjectionMoldingMachineDtoValidatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new InjectionMoldingMachineDto()
                {
                    Name = "Te",
                    Tonnage = 1,
                    Size = "small"
                }
            };            
            
            yield return new object[]
            {
                new InjectionMoldingMachineDto()
                {
                    Name = "Tes",
                    Tonnage = 2,
                    Size = "small"
                }
            };
                        
            yield return new object[]
            {
                new InjectionMoldingMachineDto()
                {
                    Name = "TestTestTest123",
                    Tonnage = 3999,
                    Size = "small"
                }
            };

            yield return new object[]
            {
                new InjectionMoldingMachineDto()
                {
                    Name = "TestTestTest12",
                    Tonnage = 3998,
                    Size = "small"
                }
            };            
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
