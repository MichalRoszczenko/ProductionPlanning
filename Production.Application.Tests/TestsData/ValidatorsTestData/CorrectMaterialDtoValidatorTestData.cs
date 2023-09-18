using Production.Application.Dtos;
using System.Collections;

namespace Production.Application.Tests.TestsData.ValidatorsTestData
{
	public class CorrectMaterialDtoValidatorTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[]
			{
				new MaterialDto()
				{
					Name = "Na",
					Type = "ty",
					Description = "D",
					Cost = 111.11M,
					MaterialInStock = 0
				}
			};			
			
			yield return new object[]
			{
				new MaterialDto()
				{
					Name = "Na3",
					Type = "ty3",
					Description = "D3",
					Cost = 11.11M,
					MaterialInStock = 1
				}
			};			
			
			yield return new object[]
			{
				new MaterialDto()
				{
					Name = "TestTestTest123",
					Type = "TestTestTest123",
					Description = "TestTestTest123TestTestTest12322",
					Cost = 0.01M,
					MaterialInStock = 5
				}
			};			
			
			yield return new object[]
			{
				new MaterialDto()
				{
					Name = "TestTestTest12",
					Type = "TestTestTest12",
					Description = "TestTestTest123TestTestTest1232",
					Cost = 999.99M,
					MaterialInStock = 5
				}
			};
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
