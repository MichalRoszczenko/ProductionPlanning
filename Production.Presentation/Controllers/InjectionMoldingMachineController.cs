using Microsoft.AspNetCore.Mvc;
using Production.Application.Dtos;
using Production.Application.Interfaces;

namespace Production.Presentation.Controllers
{
    public class InjectionMoldingMachineController : Controller
    {
        private readonly IDatabaseService<InjectionMoldingMachineDto, int> _machineService;

        public InjectionMoldingMachineController(IDatabaseService<InjectionMoldingMachineDto, int> machineService)
        {
            _machineService = machineService;
        }
        public async Task<IActionResult> Index()
        {
            var machines = await _machineService.GetAll();

            return View(machines);
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

		[Route("InjectionMoldingMachine/{machineId}/Details")]
		public async Task<IActionResult> Details(int machineId)
		{
			var machine = await _machineService.GetById(machineId);

			return View(machine);
		}

		[Route("InjectionMoldingMachine/{machineId}/Remove")]
        public async Task<IActionResult> Remove(int machineId)
        {
            var machine = await _machineService.GetById(machineId);

            return View(machine);
        }

        [HttpPost]
        [Route("InjectionMoldingMachine/{machineId}/Remove")]
        public async Task<IActionResult> RemoveConfirmed(int machineId)
        {
            await _machineService.Remove(machineId);

            return RedirectToAction(nameof(Index));
        }

		[Route("InjectionMoldingMachine/{machineId}/Edit")]
		public async Task<IActionResult> Edit(int machineId)
		{
			var machine = await _machineService.GetById(machineId);

			return View(machine);
		}

		[HttpPost]
		[Route("InjectionMoldingMachine/{machineId}/Edit")]
		public async Task<IActionResult> Edit(int machineId, InjectionMoldingMachineDto machineDto)
		{
			var machine = await _machineService.GetById(machineId);

			if (!ModelState.IsValid)
			{
				return View(machine);
			}

			await _machineService.Update(machineId, machineDto);

			return RedirectToAction(nameof(Index));
		}
	}
}
