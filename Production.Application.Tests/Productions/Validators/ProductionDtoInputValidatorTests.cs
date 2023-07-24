using FluentValidation.TestHelper;
using Moq;
using Production.Application.Tests.TestsData;
using Production.Domain.Entities;
using Production.Domain.Interfaces;
using Xunit;

namespace Production.Application.Productions.Validators.Tests
{
	public class ProductionDtoInputValidatorTests
	{
        [Theory()]
		[ClassData(typeof(ValidProductionTestData))]
		public void ProductionValidator_ShouldNotHaveValidationError_ForValidData(InjectionMold mold,
			InjectionMoldingMachine machine, ProductionDto productionDto)
		{
			//arrange

			var validator = CreateValidatorWithMockedMoldAndMachine(mold, machine);

			//act

			var result = validator.TestValidate(productionDto);

			//assert

			result.ShouldNotHaveAnyValidationErrors();
		}

		[Theory()]
		[ClassData(typeof(InvalidProductionTestData))]
		public void ProductionValidator_ShouldHaveValidationErrors_ForInvalidtData(InjectionMold mold,
			InjectionMoldingMachine machine, ProductionDto productionDto)
		{
			//arrange

			var validator = CreateValidatorWithMockedMoldAndMachine(mold, machine);

			//act

			var result = validator.TestValidate(productionDto);

			//assert

			result.ShouldHaveAnyValidationError();
		}

		private ProductionDtoValidator CreateValidatorWithMockedMoldAndMachine(InjectionMold mold,
			InjectionMoldingMachine machine)
		{
			var moldRepositoryMock = new Mock<IInjectionMoldRepository>();
			moldRepositoryMock.Setup(a
				=> a.GetById(mold.Id))
				.ReturnsAsync(mold);

			var machineRepositoryMock = new Mock<IInjectionMoldingMachineRepository>();
			machineRepositoryMock.Setup(s
				=> s.GetById(machine.Id))
				.ReturnsAsync(machine);

			var validator = new ProductionDtoValidator(moldRepositoryMock.Object, machineRepositoryMock.Object);

			return validator;
		}
	}
}