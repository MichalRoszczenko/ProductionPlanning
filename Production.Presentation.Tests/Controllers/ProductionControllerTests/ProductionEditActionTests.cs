using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Production.Domain.Entities;
using Production.Presentation.Tests.Extensions;
using Xunit;

namespace Production.Presentation.Tests.Controllers.ProductionControllerTests
{
    public class ProductionEditActionTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public ProductionEditActionTests(WebApplicationFactory<Program> factory)
        {
			_factory = factory.CreateInMemoryDatabase();

			_client = _factory.CreateClient();//test Commit
        }

        [Fact]
        public async Task Edit_ReturnEditedProductionView_ForExistingProduction()
        {
            //arrange

            var molds = new List<InjectionMold>()
            {
                new InjectionMold()
                {
                    Name = "TestMold1",
                    Producer = "TestProducer1",
                    Size = "TestSize1",
                    Consumption = 1
                },
                new InjectionMold()
                {
                    Name = "TestMold2",
                    Producer = "TestProducer2",
                    Size = "TestSize2",
                    Consumption = 2
                },
                new InjectionMold()
                {
                    Name = "TestMold3",
                    Producer = "TestProducer3",
                    Size = "TestSize3",
                    Consumption = 3
                }
            };

            var machines = new List<InjectionMoldingMachine>()
            {
                new InjectionMoldingMachine()
                {
                    Name = "TestMachine1",
                    Size = "TestSize1",
                    Online = true,
                    Tonnage = 1000
                },
                new InjectionMoldingMachine()
                {
					Name = "TestMachine2",
                    Size = "TestSize2",
                    Online = true,
                    Tonnage = 2000
                },
                new InjectionMoldingMachine()
                {
					Name = "TestMachine3",
                    Size = "TestSize3",
                    Online = true,
                    Tonnage = 3000
                }
            };

            await _factory.AddElementsToDb(machines,molds);

            //act

            var response = await _client.GetAsync("Production/99/Edit");
            var content = await response.Content.ReadAsStringAsync();

            //assert

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            for (int i = 0; i < molds.Count; i++)
            {
                content.Should().Contain($"<option value=\"{molds[i].Id}\">{molds[i].Name}</option>")
                    .And.Contain($"<option value=\"{machines[i].Id}\">{machines[i].Name}</option>");
            }
		}
    }
}
