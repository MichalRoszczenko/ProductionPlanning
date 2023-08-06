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
        public IActionResult Index()
        {
            var materials = _materialService.GetAll().Result;
            return View(materials);
        }

        [Route("Material/{materialId}/Details")]
        public IActionResult Details(int materialId)
        {
            var material = _materialService.GetById(materialId).Result;
            return View(material);
        }
    }
}
