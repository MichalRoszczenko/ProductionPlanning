using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Production.Presentation.Tests.Extensions;
using System.Net;
using Xunit;

namespace Production.Presentation.Tests.Controllers.MaterialControllerTests
{
    public class MaterialControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
		private readonly WebApplicationFactory<Program> _factory;

		public MaterialControllerTests(WebApplicationFactory<Program> factory)
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
                    Id = 1,
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
                    Id = 2,
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
                    Id = 3,
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
    }
}