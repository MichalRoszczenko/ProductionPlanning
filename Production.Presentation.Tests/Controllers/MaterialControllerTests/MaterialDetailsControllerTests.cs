using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Production.Presentation.Tests.Extensions;
using System.Net;
using Xunit;

namespace Production.Presentation.Tests.Controllers.MaterialControllerTests
{
	public class MaterialDetailsControllerTests : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly WebApplicationFactory<Program> _factory;

		public MaterialDetailsControllerTests(WebApplicationFactory<Program> factory)
		{
			_factory = factory.CreateInMemoryDatabase();
		}

		[Fact()]
		public async Task Details_ReturnsViewWithExpectedData_ForExistingMaterials()
		{
			//arrange

			var material = new Domain.Entities.Material()
			{
				Name = "TestMat1",
				Description = "TestDescription1",
				Type = "TestType1",
				Cost = 15,
				Stock = new Domain.Entities.MaterialStock()
				{
					MaterialInStock = 444,
					PlannedMaterialDemand = 125
				}
			};

			await _factory.AddElementToDb(material);

			var client = _factory.CreateClient();

			//act

			var response = await client.GetAsync($"/Material/{material.Id}/Details");

			var content = await response.Content.ReadAsStringAsync();

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			content.Should()
				.Contain(material.Id.ToString())
				.And.Contain(material.Name)
				.And.Contain(material.Type)
				.And.Contain(material.Description)
				.And.Contain(material.Cost.ToString())
				.And.Contain(material.Stock.MaterialInStock.ToString())
				.And.Contain(material.Stock.PlannedMaterialDemand.ToString());
		}
	}
}
