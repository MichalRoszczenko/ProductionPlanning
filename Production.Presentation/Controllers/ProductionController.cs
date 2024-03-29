﻿using Microsoft.AspNetCore.Mvc;
using Production.Application.Dtos;
using Production.Application.Interfaces;
using Production.Presentation.Extensions;

namespace Production.Presentation.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IDatabaseCrudService<ProductionDto, int> _productionService;
        private readonly IDatabaseCrudService<InjectionMoldDto, Guid> _moldService;
        private readonly IDatabaseCrudService<InjectionMoldingMachineDto,int> _machineService;

        public ProductionController(IDatabaseCrudService<ProductionDto, int> productionService,
            IDatabaseCrudService<InjectionMoldDto, Guid> moldService,
			IDatabaseCrudService<InjectionMoldingMachineDto, int> machineService)
        {
            _productionService = productionService;
            _moldService = moldService;
            _machineService = machineService;
        }

        public async Task<IActionResult> Index()
        {
            var production = await _productionService.GetAll();
            return View(production);
        }

        public async Task<IActionResult> Create()
        {
            await AddToolsToViewBag();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductionDto productionDto)
        {
            await AddToolsToViewBag();

            if (!ModelState.IsValid)
            {
                return View();
            }

            await _productionService.Create(productionDto);

            return RedirectToAction(nameof(Index));
        }

        [Route("Production/{productionId}/Details")]
        public async Task<IActionResult> Details(int productionId)
        {
            var production = await _productionService.GetById(productionId);

            return View(production);
        }

        [Route("Production/{productionId}/Remove")]
        public async Task<IActionResult> Remove(int productionId)
        {
            var production = await _productionService.GetById(productionId);

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
            await AddToolsToViewBag();

            var production = await _productionService.GetById(productionId);  

            return View(production);
        }

        [HttpPost]
        [Route("Production/{productionId}/Edit")]
        public async Task<IActionResult> Edit(int productionId, ProductionDto productionDto)
        {
            await AddToolsToViewBag();

            var production = await _productionService.GetById(productionId);

            if (!ModelState.IsValid)
            {
                return View(production);
            }

            await _productionService.Update(productionId, productionDto);

            return RedirectToAction(nameof(Index));
        }

        private async Task AddToolsToViewBag()
        {
            var molds = await _moldService.GetAll();

            var machines = await _machineService.GetAll();

            this.CreateViewBagOfTools(machines, molds);
        }
    }
}