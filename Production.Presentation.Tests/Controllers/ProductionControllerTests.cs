using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Production.Application.Productions;
using Production.Application.Services;
using Production.Presentation.Tests.TestsData;
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
		[ClassData(typeof(ProductionOutputDtoTestData))]
		public async Task Index_ReturnsViewWithExpectedData_ForExistingProductions(List<ProductionDtoOutput> productionsDto)
		{
            //arrange

            var client = CreateClientWithProductionServiceMock(productionsDto);

            //act 

            var response = await client.GetAsync("/Production/Index");

			//assert

			response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

			var content = await response.Content.ReadAsStringAsync();

			foreach(var production in productionsDto)
			{
				content.Should().Contain(production.InjectionMoldName)
					.And.Contain(production.InjectionMoldingMachineName)
					.And.Contain(production.Start.ToString())
					.And.Contain(production.End.ToString());
			}
		}

		[Theory()]
		[ClassData(typeof(EmptyProductionOutputDtoTestData))]
		public async Task Index_ReturnsEmptyView_ForNoExistingProductions(List<ProductionDtoOutput> productionsDto)
		{
			//arrange

			var client = CreateClientWithProductionServiceMock(productionsDto);

            //act 

            var response = await client.GetAsync("/Production/Index");

			//assert

			response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

			var content = await response.Content.ReadAsStringAsync();

			foreach (var production in productionsDto)
			{
				content.Should().NotContain("Edit\">Edit</a> |")
					.And.NotContain("Details\">Details</a> |")
					.And.NotContain(">Remove</a>");
			}
		}

		private HttpClient CreateClientWithProductionServiceMock(List<ProductionDtoOutput> productionsDto)
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