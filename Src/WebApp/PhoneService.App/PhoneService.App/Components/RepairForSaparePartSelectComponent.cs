using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

            var partsToDisplay = sapareParts.ToList();

            var str = HttpContext.Session.GetString("repairUpdateRequest");

            if (str != null)
            {
                var data = JsonConvert.DeserializeObject<RepairUpdateRequest>(str);

                var items = data.RepairItems.Select(x => x);

                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        partsToDisplay.RemoveAll(x => x.SaparePartId == item.SaparePartId);
                    }
                }
            }

            return View("RepairForSaparePartSelect", partsToDisplay);
        }
    }
}
