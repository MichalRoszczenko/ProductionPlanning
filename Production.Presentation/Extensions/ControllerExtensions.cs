using Microsoft.AspNetCore.Mvc;
using Production.Application.Dtos;

namespace Production.Presentation.Extensions
{
    public static class ControllerExtensions
    {
        public static void CreateViewBagOfTools(this Controller controller, IEnumerable<InjectionMoldingMachineDto> machine,
            IEnumerable<InjectionMoldDto> mold)
        {
            controller.ViewBag.Molds = mold;
            controller.ViewBag.Machines = machine;
        }
    }
}