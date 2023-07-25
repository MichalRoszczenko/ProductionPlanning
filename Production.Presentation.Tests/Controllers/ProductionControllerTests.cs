using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Production.Application.Productions;
using Production.Application.Services;
using Production.Presentation.Tests.TestsData;
using System.Net;
using Xunit;

namespace Production.Presentation.Controllers.Tests
{
	public class ProductionControllerTests : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly WebApplicationFactory<Program> _factory;

		public ProductionControllerTests(WebApplicationFactory<Program> factory)
        {
			_factory = factory;
		}

        [Theory()]
		[ClassData(typeof(ProductionDtoTestData))]
		public async Task Index_ReturnsViewWithExpectedData_ForExistingProductions(List<ProductionDto> productionsDto)
		{
            //arrange

            var client = CreateClientWithProductionServiceMock(productionsDto);

            //act 

            var response = await client.GetAsync("/Production/Index");

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var content = await response.Content.ReadAsStringAsync();

			foreach(var production in productionsDto)
			{
				content.Should().Contain(production.InjectionMoldName)
					.And.Contain(production.InjectionMoldingMachineName)
					.And.Contain(production.Start.ToString())
					.And.Contain(production.End.ToString());
			}
		}

		[Fact()]
		public async Task Index_ReturnsEmptyView_ForNoExistingProductions()
		{
			//arrange

			var productionsDto = new List<ProductionDto>();

            var client = CreateClientWithProductionServiceMock(productionsDto);

            //act 

            var response = await client.GetAsync("/Production/Index");

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var content = await response.Content.ReadAsStringAsync();


			content.Should().NotContain("Edit\">Edit</a> |")
				.And.NotContain("Details\">Details</a> |")
				.And.NotContain(">Remove</a>");
		}

		[Fact()]
		public async Task Details_ReturnProductionDetailsView_ForExistingProduction()
		{
			//arrange

			var productionDto = new ProductionDto()
			{
				Start = new DateTime(2023, 08, 15, 15, 20, 00),
				End = new DateTime(2023, 08, 15, 15, 20, 00),
				InjectionMoldingMachineName = "TestMachine1",
				InjectionMoldName = "TestMold1"
			};

            var productionServiceMock = new Mock<IProductionService>();

			productionServiceMock.Setup(s => s.GetById(It.IsAny<int>()))
				.ReturnsAsync(productionDto);

			var client = _factory.WithWebHostBuilder(builder 
				=> builder.ConfigureServices(cfg => cfg.AddScoped(_ => productionServiceMock.Object)))
				.CreateClient();

			//act

			var response = await client.GetAsync("/Production/1/Details");

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var content = await response.Content.ReadAsStringAsync();

			content.Should().Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.Start}\r\n        </dd>")
				.And.Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.Start}\r\n        </dd>")
				.And.Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.InjectionMoldingMachineName}\r\n        </dd>")
				.And.Contain($"<dd class = \"col-sm-10\">\r\n            {productionDto.InjectionMoldName}\r\n        </dd>");
        }

        private HttpClient CreateClientWithProductionServiceMock(List<ProductionDto> productionsDto)
		{
            var productionServiceMock = new Mock<IProductionService>();

            productionServiceMock.Setup(e => e.GetAll())
                .ReturnsAsync(productionsDto);

            var client = _factory
                .WithWebHostBuilder(builder
                => builder.ConfigureTestServices(services => services.AddScoped(_ => productionServiceMock.Object)))
                .CreateClient();

			return client;
        }
    }
}