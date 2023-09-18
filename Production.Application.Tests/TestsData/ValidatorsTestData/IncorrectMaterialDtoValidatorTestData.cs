using Production.Application.Dtos;
using System.Collections;

namespace Production.Application.Tests.TestsData.ValidatorsTestData
{
	public class IncorrectMaterialDtoValidatorTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[]
			{
				new MaterialDto()
				{
					Name = "N",
					Type = "t",
					Description = "",
					Cost = 11.111M,
					MaterialInStock = -1
				}
			};

			yield return new object[]
			{
				new MaterialDto()
				{
					Name = null!,
					Type = null!,
					Description = null!,
					Cost = default,
					MaterialInStock = -1
				}
			};			
			
			yield return new object[]
			{
				new MaterialDto()
				{
					Name = "TestTestTest1234",
					Type = "TestTestTest1234",
					Description = "TestTestTest123TestTestTest123222",
					Cost = 1000,
					MaterialInStock = -5
				}
			};				
			
			yield return new object[]
			{
				new MaterialDto()
				{
					Name = "",
					Type = "",
					Description = "",
					Cost = 9999.11M,
					MaterialInStock = -1
				}
			};			
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
