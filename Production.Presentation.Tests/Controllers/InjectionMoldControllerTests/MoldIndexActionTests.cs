using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Production.Application.InjectionMolds;
using Production.Application.Services;
using System.Net;
using Xunit;

namespace Production.Presentation.Tests.Controllers.InjectionMoldControllerTests
{
    public class MoldIndexActionTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public MoldIndexActionTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Fact()]
        public async Task Index_ReturnsViewWithExpectedData_ForExistingInjectionMolds()
        {
            //arrange

            var moldsDto = new List<InjectionMoldDto>()
            {
                new InjectionMoldDto()
                {
                    Name = "TestMold1",
                    Producer = "TestProducer1"
                },
                new InjectionMoldDto()
                {
                    Name = "TestMold2",
                    Producer = "TestProducer2"
                },
                new InjectionMoldDto()
                {
                    Name = "TestMold3",
                    Producer = "TestProducer3"
                },
            };

            var client = CreateClientWithInjectionMoldServiceMock(moldsDto);

            //act 

            var response = await client.GetAsync("/InjectionMold/Index");

            //assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            foreach (var mold in moldsDto)
            {
                content.Should().Contain(mold.Name)
                    .And.Contain(mold.Producer);
            }
        }

        [Fact()]
        public async Task Index_ReturnsEmptyView_ForNoExistingInjectionMolds()
        {
            //arrange

            var moldsDto = new List<InjectionMoldDto>();


            var client = CreateClientWithInjectionMoldServiceMock(moldsDto);

            //act 

            var response = await client.GetAsync("/InjectionMold/Index");

            //assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().NotContain("Edit\">Edit</a> |")
                .And.NotContain("Details\">Details</a> |")
                .And.NotContain(">Remove</a>");
        }

        private HttpClient CreateClientWithInjectionMoldServiceMock(List<InjectionMoldDto> moldsDto)
        {
            var injectionServiceMock = new Mock<IInjectionMoldService>();

            injectionServiceMock.Setup(e => e.GetAll())
                .ReturnsAsync(moldsDto);

            var client = _factory
                .WithWebHostBuilder(builder
                => builder.ConfigureTestServices(services => services.AddScoped(_ => injectionServiceMock.Object)))
                .CreateClient();

            return client;
        }
    }
}
