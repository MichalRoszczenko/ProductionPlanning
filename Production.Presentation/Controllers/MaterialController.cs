using Microsoft.AspNetCore.Mvc;
using Production.Application.Material;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MaterialDto materialDto)
        {
            if(!ModelState.IsValid)
            {
                return View(materialDto);
            }

            await _materialService.Create(materialDto);

            return RedirectToAction(nameof(Index));
        }

        [Route("Material/{materialId}/Edit")]
        public async Task<IActionResult> Edit(int materialId)
        {
            var material = await _materialService.GetById(materialId);

            return View(material);
        }

        [HttpPost]
        [Route("Material/{materialId}/Edit")]
        public async Task<IActionResult> Edit(int materialId, MaterialDto materialDto)
        {
            if(!ModelState.IsValid)
            {
                return View(materialDto);
            }

            await _materialService.Update(materialId, materialDto);

            return RedirectToAction(nameof(Index));
        }
    }
}
