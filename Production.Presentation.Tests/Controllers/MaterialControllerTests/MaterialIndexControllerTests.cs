using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Presentation.Tests.Extensions;
using System.Net;
using Xunit;

namespace Production.Presentation.Tests.Controllers.MaterialControllerTests
{
    public class MaterialIndexControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
		private readonly WebApplicationFactory<Program> _factory;

		public MaterialIndexControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.CreateInMemoryDatabase();
        }

        [Fact()]
        public async Task Index_ReturnsViewWithExpectedData_ForExistingMaterials()
        {
            //arrange

            var materials = new List<Domain.Entities.Material>()
            {
                new Domain.Entities.Material()
                {
                    Name = "TestMat1",
                    Description = "TestDescription1",
                    Type = "TestType1",
                    Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 444
                    }
                },
                new Domain.Entities.Material()
                {
                    Name = "TestMat2",
					Description = "TestDescription1",
					Type = "TestType1",
					Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 555
                    }
                },
                new Domain.Entities.Material()
                {
                    Name = "TestMat1",
					Description = "TestDescription1",
					Type = "TestType1",
					Stock = new Domain.Entities.MaterialStock()
                    {
                        MaterialInStock = 333
                    }
                }
            };

            await _factory.AddElementsToDb(materials);

            var client = _factory.CreateClient();

            //act

            var response = await client.GetAsync("/Material/Index");

			var content = await response.Content.ReadAsStringAsync();

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

            foreach ( var material in materials )
            {
                content.Should()
                    .Contain(material.Id.ToString())
                    .And.Contain(material.Name)
                    .And.Contain(material.Stock.MaterialInStock.ToString());
            }
        }

		[Fact()]
		public async Task Index_ReturnsEmptyView_ForNoExistingMaterials()
		{
            //arrange

            var materialsDto = new List<MaterialDto>();

            var client = CreateMaterialServiceMockClient(materialsDto);

			//act

			var response = await client.GetAsync("/Material/Index");

			var content = await response.Content.ReadAsStringAsync();

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			content.Should().NotContain("Edit\">Edit</a> |")
				.And.NotContain("Details\">Details</a> |")
				.And.NotContain(">Remove</a>");
		}

        private HttpClient CreateMaterialServiceMockClient(List<MaterialDto> materialsDto)
        {
			var materialServiceMock = new Mock<IDatabaseService<MaterialDto,int>>();

			materialServiceMock.Setup(e => e.GetAll()).ReturnsAsync(materialsDto);

			var client = _factory.WithWebHostBuilder(builder
				=> builder.ConfigureTestServices(services
				=> services.AddScoped(_ => materialServiceMock.Object)))
				.CreateClient();

            return client;
		}
	}
}