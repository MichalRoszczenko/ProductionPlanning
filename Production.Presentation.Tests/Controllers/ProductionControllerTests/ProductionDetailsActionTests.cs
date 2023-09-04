using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Production.Application.Productions;
using Production.Presentation.Tests.Extensions;
using System.Net;
using Xunit;

namespace Production.Presentation.Tests.Controllers.ProductionControllerTests
{
	public class ProductionDetailsActionTests : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly WebApplicationFactory<Program> _factory;

		public ProductionDetailsActionTests(WebApplicationFactory<Program> factory)
		{
			_factory = factory.CreateInMemoryDatabase();
		}

		[Fact()]
		public async Task Details_ReturnProductionDetailsView_ForExistingProduction()
		{
			//arrange

			var production = new Domain.Entities.Production()
			{
				Id = 4,
				Start = new DateTime(2023, 08, 15, 15, 20, 00),
				End = new DateTime(2023, 08, 15, 15, 20, 00),
				InjectionMoldingMachine = new Domain.Entities.InjectionMoldingMachine()
				{
					Id = 7,
					Name = "TestMachine1",
					Size = "TestSize1"
				},
				InjectionMold = new Domain.Entities.InjectionMold()
				{
					Name = "TestMold1",
					Producer = "TestProducer1",
					Size = "TestSize1"
				},
				MaterialStatus = new Domain.Entities.MaterialStatus()
				{
					MaterialUsage = 1000,
					MaterialIsAvailable = false
				}
			};			
			
			var productionDto = new ProductionDto()
			{
				Start = new DateTime(2023, 08, 15, 15, 20, 00),
				End = new DateTime(2023, 08, 15, 15, 20, 00),
				InjectionMoldingMachineName = "TestMachine1",
				InjectionMoldName = "TestMold1",
				MaterialIsAvailable = false,
				MaterialUsage = 1000
			};

			await _factory.AddElementToDb(production);

			var client = _factory.CreateClient();

			//act

			var response = await client.GetAsync("/Production/4/Details");

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var content = await response.Content.ReadAsStringAsync();

			content.Should().Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.Start}\r\n        </dd>")
				.And.Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.Start}\r\n        </dd>")
				.And.Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.InjectionMoldingMachineName}\r\n        </dd>")
				.And.Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.InjectionMoldName}\r\n        </dd>")
				.And.Contain(productionDto.MaterialIsAvailable ? "checked=\"checked\" class=\"check-box\" disabled=\"disabled\""
					: "class=\"check-box\" disabled=\"disabled\"")
				.And.Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.MaterialUsage}\r\n        </dd>");
		}
	}
}
