using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneService.Core.Models.Repair;

namespace PhoneService.App.Components
{
    public class RepairSearchStatisticsComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var repairSearch = new RepairSearchRequest();

            return View("RepairSearchStatistics", repairSearch);
        }
    }
}
