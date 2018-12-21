using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.App.Controllers.Inherit;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Models.Repair;

namespace PhoneService.App.Controllers
{
    [Route("[controller]/[action]")]
    public class RepairController : SecureController
    {
        private IRepairService _repairService;

        public RepairController(IRepairService repairService)
        {
            _repairService = repairService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _repairService.GetAllRepairsAsync();

            return View(model);
        }

        [HttpGet("{repairId}")]
        public async Task<IActionResult> Details(int repairId)
        {
            var model = await _repairService.GetRepairByIdAsync(repairId);

            return View(model);
        }


        [HttpGet("{customerId?}/{productId?}")]
        public async Task<IActionResult> AddRepair(int? customerId, int? productId)
        {
            RepairAddRequest model = new RepairAddRequest();

            if (customerId != null || productId != null || model.ProductId != 0 || model.CustomerId != 0)
            {
                if (customerId != null)
                    model.CustomerId = customerId.Value;

                if (productId != null)
                    model.ProductId = productId.Value;

                return View(model);
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddRepair([FromBody]RepairAddRequest repairAddRequest)
        {
            if (ModelState.IsValid)
            {
                await _repairService.AddRepairAsync(repairAddRequest);
                return RedirectToAction("Index", "Repair");
            }

            return View(repairAddRequest);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody]RepairUpdateRequest repairUpdateRequest)
        {
            try
            {
                await _repairService.UpdateRepairAsync(repairUpdateRequest);
                return Ok(NoContent());
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("This Repair does not exist");
            }
        }

        [HttpDelete("{repairId}")]
        public async Task<IActionResult> RemoveRepair(int repairId)
        {
            try
            {
                await _repairService.RemoveRepairAsync(repairId);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("This Repair does not exist");
            }
        }
    }
}