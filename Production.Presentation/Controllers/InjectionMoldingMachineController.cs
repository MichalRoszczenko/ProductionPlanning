using Microsoft.AspNetCore.Mvc;
using Production.Application.InjectionMoldMachines;
using Production.Application.Services;

namespace Production.Presentation.Controllers
{
    public class InjectionMoldingMachineController : Controller
    {
        private readonly IInjectionMoldingMachineService _machineService;

        public InjectionMoldingMachineController(IInjectionMoldingMachineService machineService)
        {
            _machineService = machineService;
        }
        public IActionResult Index()
        {
            var machines = _machineService.GetAll().Result;

            return View(machines);
        }

        [Route("InjectionMoldingMachine/{machineId}/Edit")]
        public IActionResult Edit(int machineId) 
        {
            var machine = _machineService.GetById(machineId).Result;

            return View(machine);
        }

        [HttpPost]
        [Route("InjectionMoldingMachine/{machineId}/Edit")]
        public async Task<IActionResult> Edit(int machineId, InjectionMoldingMachineDto machineDto)
        {
            var machine = _machineService.GetById(machineId).Result;

            if(!ModelState.IsValid) 
            {
                return View(machine);
            }

            await _machineService.Update(machineId, machineDto);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InjectionMoldingMachineDto machineDto)
        {
            if(!ModelState.IsValid)
            {
                return View(machineDto);
            }

            await _machineService.Create(machineDto);

            return RedirectToAction(nameof(Index));
        }

        [Route("InjectionMoldingMachine/{machineId}/Remove")]
        public IActionResult Remove(int machineId)
        {
            var machine = _machineService.GetById(machineId).Result;

            return View(machine);
        }

        [HttpPost]
        [Route("InjectionMoldingMachine/{machineId}/Remove")]
        public async Task<IActionResult> RemoveConfirmed(int machineId)
        {
            await _machineService.Remove(machineId);

            return RedirectToAction(nameof(Index));
        }

    }
}
