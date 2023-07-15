using Microsoft.AspNetCore.Mvc;
using Production.Application.Production;
using Production.Application.Services;
using Production.Domain.Interfaces;

namespace Production.Presentation.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IProductionService _productionService;

        public ProductionController(IProductionService productionService)
        {
            _productionService = productionService;
            _injectionMoldRepository = injectionMoldRepository;
        }

        public async Task<IActionResult> Index()
        {
            var production = await _productionService.GetAll();
            return View(production);
        }

        public IActionResult Create()
        {
            var molds = _injectionMoldRepository.GetAll().Result;

            ViewBag.Molds = molds;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductionDtoInput productionDto)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            await _productionService.Create(productionDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int productionId)
        {
            await _productionService.Remove(productionId);

            return RedirectToAction(nameof(Index));
        }

        [Route("Production/{productionId}/Edit")]
        public async Task<IActionResult> Edit(int productionId)
        {
            var production = await _productionService.GetById(productionId);

            return View(production);
        }

        [HttpPost]
        [Route("Production/{productionId}/Edit")]
        public async Task<IActionResult> Edit(int productionId, ProductionDtoInput productionDto)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            await _productionService.Update(productionId, productionDto);

            return RedirectToAction(nameof(Index));
        }
    }
}
