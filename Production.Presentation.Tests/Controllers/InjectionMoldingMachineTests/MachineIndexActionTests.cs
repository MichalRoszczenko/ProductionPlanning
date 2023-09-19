using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Domain.Entities;
using Production.Presentation.Tests.Extensions;
using System.Net;
using Xunit;

namespace Production.Presentation.Tests.Controllers.InjectionMoldingMachineTests
{
    public class MachineIndexActionTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public MachineIndexActionTests(WebApplicationFactory<Program> factory)
        {
			_factory = factory.CreateInMemoryDatabase();
		}

        [Fact()]
        public async Task Index_ReturnsViewWithExpectedData_ForExistingInjectionMachines()
        {
            //arrange

            var machines = new List<InjectionMoldingMachine>()
            {
                new InjectionMoldingMachine()
                {
					Name = "TestMachine1",
                    Online = false,
                    Size = "TestSize1",
                    Tonnage = 3001
                },
                new InjectionMoldingMachine()
                {
					Name = "TestMachine2",
                    Online = true,
                    Size = "TestSize2",
                    Tonnage = 3002
                },
                new InjectionMoldingMachine()
                {
					Name = "TestMachine3",
					Online = true,
					Size = "TestSize3",
					Tonnage = 3003
				},
			};

			var machinesDto = new List<InjectionMoldingMachineDto>()
            {
                new InjectionMoldingMachineDto()
                {
                    Name = "TestMachine1",
                    Online = false,
                    Size = "TestSize1",
                    Tonnage = 3001
                },
                new InjectionMoldingMachineDto()
                {
                    Name = "TestMachine2",
                    Online = true,
                    Size = "TestSize2",
                    Tonnage = 3002
                },
                new InjectionMoldingMachineDto()
                {
                    Name = "TestMachine3",
                    Online = true,
                    Size = "TestSize3",
                    Tonnage = 3003
                },
            };

            await _factory.AddElementsToDb(machines);

			var client = _factory.CreateClient();

			//act 

			var response = await client.GetAsync("/InjectionMoldingMachine/Index");

            //assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            foreach (var machine in machinesDto)
            {
                content.Should().Contain(machine.Name)
                    .And.Contain(machine.Size)
                    .And.Contain(machine.Tonnage.ToString())
                    .And.Contain(machine.Online ? "<input checked=\"checked\" class=\"check-box\"" : "<input class=\"check-box\"");
            }
		}

        [Fact()]
        public async Task Index_ReturnsEmptyView_ForNoExistingInjectionMachines()
        {
            //arrange

            var machinesDto = new List<InjectionMoldingMachineDto>();

            var client = CreateClientWithInjectionMachineServiceMock(machinesDto);

            //act 

            var response = await client.GetAsync("/InjectionMoldingMachine/Index");

            //assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();


            content.Should().NotContain("Edit\">Edit</a> |")
                .And.NotContain("Details\">Details</a> |")
                .And.NotContain(">Remove</a>");
		}

        private HttpClient CreateClientWithInjectionMachineServiceMock(List<InjectionMoldingMachineDto> machinesDto)
        {
            var machineServiceMock = new Mock<IDatabaseService<InjectionMoldingMachineDto,int>>();

            machineServiceMock.Setup(e => e.GetAll())
                .ReturnsAsync(machinesDto);

            var client = _factory
                .WithWebHostBuilder(builder
                => builder.ConfigureTestServices(services => services.AddScoped(_ => machineServiceMock.Object)))
                .CreateClient();

            return client;
        }
    }
}
