using FluentValidation.TestHelper;
using Production.Application.Dtos;
using Production.Application.Tests.TestsData.ValidatorsTestData;
using Xunit;

namespace Production.Application.Validators.Tests
{
    public class InjectionMoldingMachineDtoValidatorTests
    {
        [Theory()]
        [ClassData(typeof(CorrectInjectionMoldingMachineDtoValidatorTestData))]
        public void InjectionMoldingMachineDto_ShouldNotHaveAnyValidationErrors_ForCorrectData(InjectionMoldingMachineDto injectionMoldingMachineDto)
        {
            //arrange

            var validator = new InjectionMoldingMachineDtoValidator();

            //act

            var validationResult = validator.TestValidate(injectionMoldingMachineDto);

            //assert

            validationResult.ShouldNotHaveAnyValidationErrors();
        }

        [Theory()]
        [ClassData(typeof(IncorrectInjectionMoldingMachineDtoValidatorTestData))]
        public void InjectionMoldingMachineDto_ShouldHaveValidationErrors_ForIncorrectData(InjectionMoldingMachineDto injectionMoldingMachineDto)
        {
            //arrange

            var validator = new InjectionMoldingMachineDtoValidator();

            //act

            var validationResult = validator.TestValidate(injectionMoldingMachineDto);

            //assert

            validationResult.ShouldHaveValidationErrorFor(m => m.Name);
            validationResult.ShouldHaveValidationErrorFor(m => m.Tonnage);
            validationResult.ShouldHaveValidationErrorFor(m => m.Size);
        }
    }
}