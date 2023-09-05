using Microsoft.AspNetCore.Mvc;
using Production.Application.Dtos;
using Production.Application.Interfaces;

namespace Production.Presentation.Controllers
{
    public class InjectionMoldController : Controller
    {
        private readonly IInjectionMoldService _moldService;
        private readonly IMaterialService _materialService;

        public InjectionMoldController(IInjectionMoldService moldService, IMaterialService materialService)
        {
            _moldService = moldService;
            _materialService = materialService;
        }

        public async Task<IActionResult> Index()
        {
            var molds = await _moldService.GetAll();

            return View(molds);
        }

        public async Task<IActionResult> Create()
        {
            this.ViewBag.Materials = await GetNotAssignedMaterials();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InjectionMoldDto injectionMold)
        {
            this.ViewBag.Materials = await GetNotAssignedMaterials();

            if (!ModelState.IsValid)
            {
                return View(injectionMold);
            }

            await _moldService.Create(injectionMold);

            return RedirectToAction(nameof(Index));
        }

        [Route("InjectionMold/{moldId}/Details")]
        public async Task<ActionResult> Details(Guid moldId)
        {
            var mold = await _moldService.GetById(moldId, true);

            return View(mold);
        }

        [Route("InjectionMold/{moldId}/Remove")]
        public async Task<IActionResult> Remove(Guid moldId)
        {
            var mold = await _moldService.GetById(moldId);

            return View(mold);
        }

        [HttpPost]
        [Route("InjectionMold/{moldId}/Remove")]
        public async Task<IActionResult> RemoveConfirmed(Guid moldId)
        {
            await _moldService.Remove(moldId);

            return RedirectToAction(nameof(Index));
        }

		[Route("InjectionMold/{moldId}/Edit")]
		public async Task<IActionResult> Edit(Guid moldId)
		{
			this.ViewBag.Materials = await GetNotAssignedMaterials();

			var mold = await _moldService.GetById(moldId);

			return View(mold);
		}

		[HttpPost]
		[Route("InjectionMold/{moldId}/Edit")]
		public async Task<IActionResult> Edit(Guid moldId, InjectionMoldDto moldDto)
		{
			this.ViewBag.Materials = await GetNotAssignedMaterials();

			if (!ModelState.IsValid)
			{
				return View(moldDto);
			}

			await _moldService.Update(moldId, moldDto);

			return RedirectToAction(nameof(Index));
		}

		private async Task<IEnumerable<MaterialDto>> GetNotAssignedMaterials()
        {
            var materials = await _materialService.GetAll();
            var notAssignedMaterials = materials.Where(x => x.IsAssigned == false);

            return notAssignedMaterials;
        }
    }
}
