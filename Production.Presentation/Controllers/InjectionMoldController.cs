using Microsoft.AspNetCore.Mvc;
using Production.Application.InjectionMolds;
using Production.Application.Services;

namespace Production.Presentation.Controllers
{
    public class InjectionMoldController : Controller
    {
        private readonly IInjectionMoldService _moldService;

        public InjectionMoldController(IInjectionMoldService moldService)
        {
            _moldService = moldService;
        }

        public IActionResult Index()
        {
            var molds = _moldService.GetAll().Result;

            return View(molds);
        }

        public IActionResult Create()
        {
            return View();
        }

        [Route("InjectionMold/{moldId}/Details")]
        public IActionResult Details(Guid moldId)
        {
            var mold = _moldService.GetById(moldId,true).Result;

            return View(mold);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InjectionMoldDto injectionMold)
        {
            if(!ModelState.IsValid)
            {
                return View(injectionMold);
            }
            await _moldService.Create(injectionMold);

            return RedirectToAction(nameof(Index));
        }

        [Route("InjectionMold/{moldId}/Edit")]
        public IActionResult Edit(Guid moldId)
        {
            var mold = _moldService.GetById(moldId).Result;

            return View(mold);
        }

        [HttpPost]
        [Route("InjectionMold/{moldId}/Edit")]
        public async Task<IActionResult> Edit(Guid moldId, InjectionMoldDto moldDto)
        {
            if (!ModelState.IsValid)
            {
                return View(moldDto);
            }

            await _moldService.Update(moldId, moldDto);

            return RedirectToAction(nameof(Index));
        }

        [Route("InjectionMold/{moldId}/Remove")]
        public IActionResult Remove(Guid moldId)
        {
            var mold = _moldService.GetById(moldId).Result;

            return View(mold);
        }

        [HttpPost]
        [Route("InjectionMold/{moldId}/Remove")]
        public async Task<IActionResult> RemoveConfirmed(Guid moldId)
        {
            await _moldService.Remove(moldId);

            return RedirectToAction(nameof(Index));
        }
    }
}
