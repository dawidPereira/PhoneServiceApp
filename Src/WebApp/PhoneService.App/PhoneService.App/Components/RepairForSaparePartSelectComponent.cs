using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Models.Repair;

namespace PhoneService.App.Components
{
    public class RepairForSaparePartSelectComponent : ViewComponent
    {
        private readonly ISaparePartService _saparePartService;

        public RepairForSaparePartSelectComponent(ISaparePartService saparePartService)
        {
            _saparePartService = saparePartService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var sapareParts = await _saparePartService.GetAllSaparePartByProductIdAsync(productId);

            return View("RepairForSaparePartSelect", sapareParts);
        }
    }
}
