﻿using Microsoft.AspNetCore.Mvc;
using Production.Application.InjectionMolds;
using Production.Domain.Entities;

namespace Production.Presentation.Models
{
    public static class ControllerExtensions
    {
        public static void CreateViewBagOfTools(this Controller controller, IEnumerable<InjectionMoldingMachine> machine, 
            IEnumerable<InjectionMoldDto> mold)
        {
            controller.ViewBag.Molds = mold;
            controller.ViewBag.Machines = machine;
        }
    }
}