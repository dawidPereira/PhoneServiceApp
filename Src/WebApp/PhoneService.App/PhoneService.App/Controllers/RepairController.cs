using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.App.Controllers.Inherit;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Models.Repair;
using PhoneService.Core.Services;

namespace PhoneService.App.Controllers
{
    [Route("[controller]/[action]")]
    public class RepairController : SecureController
    {
        private readonly IRepairService _repairService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public RepairController(IRepairService repairService,
            ICustomerService customerService, IProductService productService)
        {
            _repairService = repairService;
            _customerService = customerService;
            _productService = productService;
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
                {
                    model.CustomerId = customerId.Value;
                    model.CustomerDetails = await _customerService.GetCustomerByIdAsync(customerId.Value);
                }

                if (productId != null)
                {
                    model.ProductId = productId.Value;
                    model.Product = await _productService.GetProductByIdAsync(productId.Value);
                }

                return View(model);
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddRepair(RepairAddRequest repairAddRequest)
        {
            if (ModelState.IsValid)
            {
                await _repairService.AddRepairAsync(repairAddRequest);
                return RedirectToAction("Index", "Repair");
            }

            return View(repairAddRequest);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRepair(RepairUpdateRequest repairUpdateRequest)
        {
            if (ModelState.IsValid)
            {
                await _repairService.UpdateRepairAsync(repairUpdateRequest);

                return RedirectToAction("Details", "Repair", new {repairId = repairUpdateRequest.RepairId});
            }

            return BadRequest();

        }

        [HttpPost("{repairId}")]
        public async Task<IActionResult> RemoveRepair(int repairId)
        {
            await _repairService.RemoveRepairAsync(repairId);

            return RedirectToAction("Index", "Repair");
        }

    }
}