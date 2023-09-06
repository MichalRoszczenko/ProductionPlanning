using Production.Application.Dtos;
using System.Collections;

namespace Production.Application.Tests.TestsData.ValidatorsTestData
{
    public class IncorrectInjectionMoldingMachineDtoValidatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new InjectionMoldingMachineDto()
                {
                    Name = "T",
                    Tonnage = 0,
                    Size = ""
                }
            };            
            
            yield return new object[]
            {
                new InjectionMoldingMachineDto()
                {
                    Name = null!,
                    Size = null!,
                }
            };

            yield return new object[]
            {
                new InjectionMoldingMachineDto()
                {
                    Name = "TestTestTest1234",
                    Tonnage = 4000,
                    Size = null!
                }
            };

            yield return new object[]
            {
                new InjectionMoldingMachineDto()
                {
                    Name = "",
                    Tonnage = -1,
                    Size = ""
                }
            };            
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
