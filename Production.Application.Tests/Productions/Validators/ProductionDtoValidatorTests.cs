using FluentValidation.TestHelper;
using Moq;
using Production.Application.Productions;
using Production.Application.Productions.Validators;
using Production.Application.Tests.TestsData.ProductionsValidatorsTestData;
using Production.Domain.Entities;
using Production.Domain.Interfaces;
using Xunit;

namespace Production.Application.Tests.Productions.Validators
{
    public class ProductionDtoValidatorTests
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
        [ClassData(typeof(NoValidProductionTestData))]
        public void ProductionValidator_ShouldHaveValidationErrors_ForNoValidData(InjectionMold mold,
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
            moldRepositoryMock.Setup(a => a.GetById(mold.Id, It.IsAny<bool>()))
                .ReturnsAsync(mold);

            var machineRepositoryMock = new Mock<IInjectionMoldingMachineRepository>();
            machineRepositoryMock.Setup(s
                => s.GetById(machine.Id, It.IsAny<bool>()))
                .ReturnsAsync(machine);

            var validator = new ProductionDtoValidator(moldRepositoryMock.Object, machineRepositoryMock.Object);

            return validator;
        }
    }
}