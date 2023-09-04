using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Production.Application.InjectionMoldMachines;
using Production.Application.Productions;
using Production.Application.Services;
using Production.Domain.Entities;
using Production.Presentation.Tests.Extensions;
using System.Net;
using Xunit;

namespace Production.Presentation.Tests.Controllers.InjectionMoldingMachineTests
{
    public class MachineDetailActionTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public MachineDetailActionTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.CreateInMemoryDatabase();
        }

        [Fact()]
        public async Task Details_ReturnInjectionMachineDetailsView_ForExistingInjectionMachine()
        {
			//arrange

			var machine = new InjectionMoldingMachine()
			{
                Id = 14,
				Name = "TestMachine1",
				Online = true,
				Size = "TestSize1",
				Tonnage = 3001
			};

			var machineDto = new InjectionMoldingMachineDto()
            {
                Name = "TestMachine1",
                Online = true,
                Size = "TestSize1",
                Tonnage = 3001
            };

            await _factory.AddElementToDb(machine);

            var client = _factory.CreateClient();

            //act

            var response = await client.GetAsync("/InjectionMoldingMachine/14/Details");

            //assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain($"<dd class = \"col-sm-10\">\r\n            {machineDto.Name}\r\n        </dd>")
                .And.Contain($"<dd class = \"col-sm-10\">\r\n            {machineDto.Size}\r\n        </dd>")
                .And.Contain($"<dd class = \"col-sm-10\">\r\n            {machineDto.Tonnage}\r\n        </dd>")
                .And.Contain(machineDto.Online ? "<input checked=\"checked\" class=\"check-box\"" : "<input class=\"check-box\"");
		}

        [Fact()]
        public async Task Details_ReturnPlannedProductionsView_ForExistingPlannedProductions()
        {
            //arrange

            var machineDto = new InjectionMoldingMachineDto()
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

            var client = CreateClientWithInjectionMachineServiceMock(machineDto);

            //act

            var response = await client.GetAsync("/InjectionMoldingMachine/1/Details");

            //assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            foreach (var plannedProduction in machineDto.PlannedProductions)
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

            var machineDto = new InjectionMoldingMachineDto()
            {
                PlannedProductions = new List<PlannedProductionDto>()
            };

            var client = CreateClientWithInjectionMachineServiceMock(machineDto);

            //act

            var response = await client.GetAsync("/InjectionMoldingMachine/1/Details");

            //assert
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().NotContain($"<th scope=\"row\">");
		}

        private HttpClient CreateClientWithInjectionMachineServiceMock(InjectionMoldingMachineDto machinesDto)
        {
            var machineServiceMock = new Mock<IInjectionMoldingMachineService>();

            machineServiceMock.Setup(e=>e.GetById(It.IsAny<int>(),true))
                .ReturnsAsync(machinesDto);

            var client = _factory.WithWebHostBuilder(builder =>
                builder.ConfigureServices(cfg => cfg.AddScoped(_ => machineServiceMock.Object)))
                .CreateClient();

            return client;
        }
    }
}
