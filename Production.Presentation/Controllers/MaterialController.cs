using Microsoft.AspNetCore.Mvc;
using Production.Application.Services;

namespace Production.Presentation.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }
        public async Task<IActionResult> Index()
        {
            var materials = await _materialService.GetAll();
            return View(materials);
        }

        [Route("Material/{materialId}/Details")]
        public async Task<IActionResult> Details(int materialId)
        {
            var material = await _materialService.GetById(materialId);
            return View(material);
        }
    }
}
