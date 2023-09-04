using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Production.Application.Productions;
using Production.Application.Services;
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

        [Fact()]
        public async Task Index_ReturnsViewWithExpectedData_ForExistingProductions()
        {
            //arrange

            var productions = new List<Domain.Entities.Production>()
            {
                new Domain.Entities.Production()
                {
                    Id=1,
                    Start = new DateTime(2023,08,15,15,20,00),
                    End = new DateTime(2023,08,15,15,20,00),
                    InjectionMoldingMachine = new Domain.Entities.InjectionMoldingMachine()
                    {
                        Name ="TestMachine1",
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
                        MaterialIsAvailable = true
                    }
                },
                new Domain.Entities.Production()
                {
                    Id = 2,
                    Start = new DateTime(2023,08,15,15,20,00),
                    End = new DateTime(2023,08,15,15,20,00),
					InjectionMoldingMachine = new Domain.Entities.InjectionMoldingMachine()
					{
						Name ="TestMachine2",
						Size = "TestSize2"
					},
					InjectionMold = new Domain.Entities.InjectionMold()
					{
						Name = "TestMold2",
						Producer = "TestProducer2",
						Size = "TestSize2"
					},
					MaterialStatus = new Domain.Entities.MaterialStatus()
					{
						MaterialIsAvailable = false
					}
				},
                new Domain.Entities.Production()
                {
					Id = 3,
					Start = new DateTime(2023,08,15,15,20,00),
                    End = new DateTime(2023,08,15,15,20,00),
					InjectionMoldingMachine = new Domain.Entities.InjectionMoldingMachine()
					{
						Name = "TestMachine3",
						Size = "TestSize3"
					},
					InjectionMold = new Domain.Entities.InjectionMold()
					{
						Name = "TestMold3",
						Producer = "TestProducer3",
						Size = "TestSize3"
					},
					MaterialStatus = new Domain.Entities.MaterialStatus()
					{
						MaterialIsAvailable = true
					}
				}
            };

            var productionsDto = new List<ProductionDto>()
                {
                    new ProductionDto()
                    {
                        Start = new DateTime(2023,08,15,15,20,00),
                        End = new DateTime(2023,08,15,15,20,00),
                        InjectionMoldingMachineName = "TestMachine1",
                        InjectionMoldName = "TestMold1",
                        MaterialIsAvailable = true,
                    },
                    new ProductionDto()
                    {
                        Start = new DateTime(2023,08,15,15,20,00),
                        End = new DateTime(2023,08,15,15,20,00),
                        InjectionMoldingMachineName = "TestMachine2",
                        InjectionMoldName = "TestMold2",
                        MaterialIsAvailable = false,
                    },
                    new ProductionDto()
                    {
                        Start = new DateTime(2023,08,15,15,20,00),
                        End = new DateTime(2023,08,15,15,20,00),
                        InjectionMoldingMachineName = "TestMachine3",
                        InjectionMoldName = "TestMold3",
                        MaterialIsAvailable = true
                    }
                };

			await _factory.AddElementsToDb(productions);

            var client = _factory.CreateClient();

            //act 

            var response = await client.GetAsync("/Production/Index");

			var content = await response.Content.ReadAsStringAsync();

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);


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
