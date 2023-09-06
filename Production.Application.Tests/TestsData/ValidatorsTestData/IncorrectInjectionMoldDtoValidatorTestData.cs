using Production.Application.Dtos;
using System.Collections;

namespace Production.Application.Tests.TestsData.ValidatorsTestData
{
    public class IncorrectInjectionMoldDtoValidatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new InjectionMoldDto
                {
                    Name = "T",
                    Size = "",
                    Producer = "T",
                    Consumption = 00.00M,
                }
            };            
            
            yield return new object[]
            {
                new InjectionMoldDto
                {
                    Name = "",
                    Size = "",
                    Producer = "",
                    Consumption = -00.01M,
                }
            };                   
            
            yield return new object[]
            {
                new InjectionMoldDto
                {
                    Name = null!,
                    Size = null!,
                    Producer = null!,
                    Consumption = 00.00M,
                }
            };            
            
            yield return new object[]
            {
                new InjectionMoldDto
                {
                    Name = "TestTestTest1231",
                    Size = "",
                    Producer = "TestTestTest1231",
                    Consumption = 100.99M,
                }
            };                
            
            yield return new object[]
            {
                new InjectionMoldDto
                {
                    Name = "TestTestTest1231",
                    Size = "",
                    Producer = "TestTestTest1231",
                    Consumption = 99.999M,
                }
            };            
            
            yield return new object[]
            {
                new InjectionMoldDto
                {
                    Name = "TestTestTest1234",
                    Size = "",
                    Producer = "TestTestTest1234",
                    Consumption = 111.111M,
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
