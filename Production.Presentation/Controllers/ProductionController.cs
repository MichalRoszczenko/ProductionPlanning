using Microsoft.AspNetCore.Mvc;
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
    }
}
