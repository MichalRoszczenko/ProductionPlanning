using Production.Application.Dtos;
using System.Collections;

namespace Production.Application.Tests.TestsData.ValidatorsTestData
{
    public class CorrectInjectionMoldDtoValidatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new InjectionMoldDto
                {
                    Name = "Te",
                    Size = "Test",
                    Producer = "Te",
                    Consumption = 00.01M,
                }
            };            
            
            yield return new object[]
            {
                new InjectionMoldDto
                {
                    Name = "Tes",
                    Size = "Test1",
                    Producer = "Tes",
                    Consumption = 00.02M,
                }
            };            
            
            yield return new object[]
            {
                new InjectionMoldDto
                {
                    Name = "TestTestTest123",
                    Size = "TestTestTest123",
                    Producer = "TestTestTest123",
                    Consumption = 99.99M,
                }
            };            
            
            yield return new object[]
            {
                new InjectionMoldDto
                {
                    Name = "TestTestTest123",
                    Size = "TestTestTest123",
                    Producer = "TestTestTest123",
                    Consumption = 99.98M,
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
