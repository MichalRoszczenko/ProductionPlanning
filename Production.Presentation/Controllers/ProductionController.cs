using Microsoft.AspNetCore.Mvc;
using Production.Application.Production;
using Production.Application.Services;

namespace Production.Presentation.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IProductionService _productionService;

        public ProductionController(IProductionService productionService)
        {
            _productionService = productionService;
        }

        public async Task<IActionResult> Index()
        {
            var production = await _productionService.GetAll();
            return View(production);
        }

        public IActionResult Create()
        {
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
    }
}
