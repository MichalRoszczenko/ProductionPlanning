using Microsoft.AspNetCore.Mvc;
using Production.Application.InjectionMolds;
using Production.Application.Productions;
using Production.Application.Services;
using Production.Domain.Interfaces;
using Production.Presentation.Models;

namespace Production.Presentation.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IProductionService _productionService;
        private readonly IInjectionMoldService _moldService;
        private readonly IInjectionMoldingMachineRepository _machineRepository; //ToDo

        public ProductionController(IProductionService productionService,IInjectionMoldService moldService,
            IInjectionMoldingMachineRepository machineRepository)
        {
            _productionService = productionService;
            _moldService = moldService;
            _machineRepository = machineRepository;
        }

        public async Task<IActionResult> Index()
        {
            var production = await _productionService.GetAll();
            return View(production);
        }

        public IActionResult Create()
        {
            AddToolsToViewBag();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductionDtoInput productionDto)
        {
            AddToolsToViewBag();

            if (!ModelState.IsValid)
            {
                return View();
            }

            await _productionService.Create(productionDto);

            return RedirectToAction(nameof(Index));
        }

        [Route("Production/{productionId}/Remove")]
        public IActionResult Remove(int productionId)
        {
            var production = _productionService.GetById(productionId).Result;

            return View(production);
        }

        [HttpPost]
        [Route("Production/{productionId}/Remove")]
        public async Task<IActionResult> RemoveConfirmed(int productionId)
        {
            await _productionService.Remove(productionId);

            return RedirectToAction(nameof(Index));
        }

        [Route("Production/{productionId}/Edit")]
        public async Task<IActionResult> Edit(int productionId)
        {
            AddToolsToViewBag();

            var production = await _productionService.GetById(productionId);  

            return View(production);
        }

        [HttpPost]
        [Route("Production/{productionId}/Edit")]
        public async Task<IActionResult> Edit(int productionId, ProductionDtoInput productionDto)
        {
            AddToolsToViewBag();

            var production = await _productionService.GetById(productionId);

            if (!ModelState.IsValid)
            {
                return View(production);
            }

            await _productionService.Update(productionId, productionDto);

            return RedirectToAction(nameof(Index));
        }

        private void AddToolsToViewBag()
        {
            IEnumerable<InjectionMoldDto>? molds = _moldService.GetAll().Result;

            IEnumerable<Domain.Entities.InjectionMoldingMachine> machines = _machineRepository.GetAll().Result;

            this.CreateViewBagOfTools(machines, molds!);
        }
    }
}
