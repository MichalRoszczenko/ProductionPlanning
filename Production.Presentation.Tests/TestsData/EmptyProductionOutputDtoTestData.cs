using Production.Application.Productions;
using System.Collections;

namespace Production.Presentation.Tests.TestsData
{
	public class EmptyProductionOutputDtoTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[]
			{
				new List<ProductionDtoOutput>()
				{
					new ProductionDtoOutput(),
					new ProductionDtoOutput(),
					new ProductionDtoOutput()
				}
			};
		}
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}

