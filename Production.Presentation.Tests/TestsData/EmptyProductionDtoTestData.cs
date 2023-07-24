using Production.Application.Productions;
using System.Collections;

namespace Production.Presentation.Tests.TestsData
{
	public class EmptyProductionDtoTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[]
			{
				new List<ProductionDto>()
				{
					new ProductionDto(),
					new ProductionDto(),
					new ProductionDto()
				}
			};
		}
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}

