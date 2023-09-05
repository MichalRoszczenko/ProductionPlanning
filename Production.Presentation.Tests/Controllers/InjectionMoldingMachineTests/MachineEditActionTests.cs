using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Production.Domain.Entities;
using Production.Presentation.Tests.Extensions;
using System.Net;
using Xunit;

namespace Production.Presentation.Tests.Controllers.InjectionMoldingMachineTests
{
	public class MachineEditActionTests : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly WebApplicationFactory<Program> _factory;

		public MachineEditActionTests(WebApplicationFactory<Program> factory)
        {
			_factory = factory.CreateInMemoryDatabase();
		}

		[Fact()]
		public async Task Edit_ReturnInjectionMachineEditView_ForExistingInjectionMachine()
		{
			//arrange

			var machine = new InjectionMoldingMachine()
			{
				Name = "TestMachine1",
				Online = true,
				Size = "TestSize1",
				Tonnage = 3001
			};

			await _factory.AddElementToDb(machine);

			var client = _factory.CreateClient();

			//act

			var response = await client.GetAsync($"/InjectionMoldingMachine/{machine.Id}/Edit");

			var content = await response.Content.ReadAsStringAsync();

			//assert

			response.StatusCode.Should().Be(HttpStatusCode.OK);
			content.Should().Contain(machine.Name)
				.And.Contain(machine.Online ? "checked=\"checked\""
					: "type=\"checkbox\" data-val=\"true\"")
				.And.Contain(machine.Size)
				.And.Contain(machine.Tonnage.ToString());
		}
	}
}
