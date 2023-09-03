using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Moq;
using Production.Application.Productions;
using Production.Application.Services;
using Production.Infrastructure.Persistence;
using Production.Presentation.Tests.Controllers.TestsData;
using Production.Presentation.Tests.Extensions;
using System.Net;
using Xunit;

namespace Production.Presentation.Tests.Controllers.ProductionControllerTests
{
    public class ProductionIndexActionTests : IClassFixture<WebApplicationFactory<Program>>
    { 
		private readonly WebApplicationFactory<Program> _factory;

        public ProductionIndexActionTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.CreateInMemoryDatabase();
		}

        [Theory()]
        [ClassData(typeof(ProductionIndexActionTestData))]
        public async Task Index_ReturnsViewWithExpectedData_ForExistingProductions(List<ProductionDto> productionsDto)
        {
            //arrange

            var client = CreateClientWithProductionServiceMock(productionsDto);

            //act 

            var response = await client.GetAsync("/Production/Index");

            //assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            foreach (var production in productionsDto)
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
