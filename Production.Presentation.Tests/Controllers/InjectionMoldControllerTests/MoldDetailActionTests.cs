using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Production.Application.InjectionMolds;
using Production.Application.Productions;
using Production.Application.Services;
using System.Net;
using Xunit;

namespace Production.Presentation.Tests.Controllers.InjectionMoldControllerTests
{
    public class MoldDetailActionTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public MoldDetailActionTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public async Task Details_ReturnInjectionMoldDetailsView_ForExistingInjectionMold()
        {
            //arrange

            var injectionMoldDto = new InjectionMoldDto()
            {
                Name = "TestMold",
                Size = "TestSize",
                Producer = "TestProducer",
                PlannedProductions = new List<PlannedProductionDto>()
                {
                    new PlannedProductionDto()
                    {
                        StartProduction = new DateTime(5,2,5,13,34,44),
                        EndProduction = new DateTime(5,2,5,19,34,44),
                        ProductionId = 7
                    }
                }
            };

            var client = CreateClientWithInjectionMoldServiceMock(injectionMoldDto);

            //act

            var response = await client.GetAsync("/InjectionMold/1/Details");

            //assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain($"<dd class = \"col-sm-10\">\r\n            {injectionMoldDto.Name}\r\n        </dd>")
                .And.Contain($"<dd class = \"col-sm-10\">\r\n            {injectionMoldDto.Size}\r\n        </dd>")
                .And.Contain($"<dd class = \"col-sm-10\">\r\n            {injectionMoldDto.Producer}\r\n        </dd>");
        }

        [Fact()]
        public async Task Details_ReturnPlannedProductionsView_ForExistingPlannedProductions()
        {
            //arrange

            var injectionMoldDto = new InjectionMoldDto()
            {

                PlannedProductions = new List<PlannedProductionDto>()
                {
                    new PlannedProductionDto()
                    {
                        StartProduction = new DateTime(5,2,5,13,34,44),
                        EndProduction = new DateTime(5,2,5,19,34,44),
                        ProductionId = 7
                    },
                    new PlannedProductionDto()
                    {
                        StartProduction = new DateTime(2003,2,5,0,0,0),
                        EndProduction = new DateTime(2003,2,25,0,0,0),
                        ProductionId = 7
                    }
                }
            };

            var client = CreateClientWithInjectionMoldServiceMock(injectionMoldDto);

            //act

            var response = await client.GetAsync("/InjectionMold/1/Details");

            //assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            foreach (var plannedProduction in injectionMoldDto.PlannedProductions)
            {
                content.Should().Contain($"<th scope=\"row\">{plannedProduction.ProductionId}</th>")
                    .And.Contain($"<td>{plannedProduction.StartProduction}</td>")
                    .And.Contain($"<td>{plannedProduction.EndProduction}</td>");
            }
        }

        [Fact()]
        public async Task Details_ReturnEmptyPlannedProductionsView_ForNoExistingPlannedProductions()
        {
            //arrange

            var injectionMoldDto = new InjectionMoldDto()
            {

                PlannedProductions = new List<PlannedProductionDto>()
            };

            var client = CreateClientWithInjectionMoldServiceMock(injectionMoldDto);

            //act

            var response = await client.GetAsync("/InjectionMold/1/Details");

            //assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().NotContain($"<th scope=\"row\">");
        }

        private HttpClient CreateClientWithInjectionMoldServiceMock(InjectionMoldDto injectionMoldDto)
        {
            var injectionServiceMock = new Mock<IInjectionMoldService>();

            injectionServiceMock.Setup(s => s.GetById(It.IsAny<Guid>(), true))
                .ReturnsAsync(injectionMoldDto);

            var client = _factory.WithWebHostBuilder(builder
                => builder.ConfigureServices(cfg => cfg.AddScoped(_ => injectionServiceMock.Object)))
                .CreateClient();

            return client;
        }
    }
}
