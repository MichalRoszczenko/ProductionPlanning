using FluentAssertions;
using Xunit;

namespace Production.Domain.Entities.Tests
{
	public class ProductionTests
	{
		[Theory()]
		[InlineData("2023-07-15 15-00", "2023-07-16 17-00", 26)]
		[InlineData("2023-07-15 15-10", "2023-07-16 17-00", 26)]
		[InlineData("2023-07-15 14-50", "2023-07-16 17-00", 27)]
		[InlineData("2023-01-07 05-00", "2023-01-16 17-00", 228)]
		[InlineData("2023-01-07 05-00", "2023-01-16 17-10", 229)]
		[InlineData("2023-01-07 05-00", "2023-01-16 17-50", 229)]
		[InlineData("2023-01-07 05-00", "2023-01-16 16-50", 228)]
		public void ProductionTimeCalculationTest_ShouldSetProductionTimeInHours_ForCorrectDates(string startDate, 
			string endDate, int expectedHours)
		{
			//arrange 

			var start = DateTime.ParseExact(startDate, "yyyy-MM-dd HH-mm", System.Globalization.CultureInfo.InvariantCulture);
			var end = DateTime.ParseExact(endDate, "yyyy-MM-dd HH-mm", System.Globalization.CultureInfo.InvariantCulture);

			var production = new Production()
			{
				Start = start,
				End = end
			};

			//act

			production.ProductionTimeCalculation();

			//assert

			production.ProductionTimeInHours.Should().Be(expectedHours);
		}

		[Theory()]
		[InlineData("2023-07-16 17-00", "2023-07-15 15-00")]
		[InlineData("2023-07-16 17-00", "2023-07-15 15-10")]
		[InlineData("2023-07-16 17-00", "2023-07-15 14-50")]
		public void ProductionTimeCalculationTest_ShouldSetProductionTimeInHours_ForNotValidDates(string startDate,
			string endDate)
		{
			//arrange 

			var start = DateTime.ParseExact(startDate, "yyyy-MM-dd HH-mm", System.Globalization.CultureInfo.InvariantCulture);
			var end = DateTime.ParseExact(endDate, "yyyy-MM-dd HH-mm", System.Globalization.CultureInfo.InvariantCulture);

			var production = new Production()
			{
				Start = start,
				End = end
			};

			//act

			Action action = () => production.ProductionTimeCalculation();

			//assert

			action.Should().Throw<ArgumentException>();
		}
	}
}