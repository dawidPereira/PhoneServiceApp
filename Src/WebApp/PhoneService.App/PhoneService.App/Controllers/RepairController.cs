using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhoneService.App.AppData;
using PhoneService.App.Controllers.Inherit;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Models.Repair;
using PhoneService.Core.Models.RepairItem;
using PhoneService.Core.Services;

namespace PhoneService.App.Controllers
{
    [Route("[controller]/[action]")]
    public class RepairController : SecureController
    {
        private readonly IRepairService _repairService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly ISaparePartService _saparePartService;

        public RepairController(IRepairService repairService,
            ICustomerService customerService, IProductService productService,
            ISaparePartService saparePartService)
        {
            _repairService = repairService;
            _customerService = customerService;
            _productService = productService;
            _saparePartService = saparePartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(RepairSearchRequest repairSearch)
        {
            var model = await _repairService.GetAllRepairsAsync();

            try
            {
                if (ControllerHelperMethods.ArePropertiesNotNull(repairSearch))
                {
                    model = await _repairService.GetRepairBySearchTermsAsync(repairSearch);
                }
                return View(model);
            }
            catch (ArgumentNullException)
            {
                var emptyList = new List<RepairResponse>();
                return View(emptyList);
            }
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


        [HttpGet("{repairId?}")]
        [HttpGet("{quantity?}/{saparePartId?}")]
        public async Task<IActionResult> UpdateRepair(int? repairId, int? saparepartId, int? quantity)
        {
            RepairDetailsResponse repair = new RepairDetailsResponse();
            if (repairId != null)
            {
                repair = await _repairService.GetRepairByIdAsync(repairId.Value);
            }

            RepairUpdateRequest model = new RepairUpdateRequest();

            var str = HttpContext.Session.GetString("repairUpdateRequest");

            if (str != null)
            {
                var data = JsonConvert.DeserializeObject<RepairUpdateRequest>(str);
                model = data;
            }
            else
            {
                model.Links = new Core.Models.Healpers.CustomerDecisionLink();
                var host = HttpContext.Request.Host.Host;
                var port = HttpContext.Request.Host.Port;
                var apiUri = host + ":" + port;
                if (port == null)
                {
                    apiUri = host;
                }
                model.Links.DecisionLink = Url.Action("CustomerDecision", "Repair", new { repairId = repair.RepairId }, "https", apiUri);

                model.CustomerId = repair.CustomerId;
                model.Description = repair.Description;
                model.RepairId = repair.RepairId;
                model.StatusId = repair.StatusId;
                model.ProductId = repair.ProductId;

                if (repair.RepairItems.Any() && repair.StatusId != 1)
                {
                    model.RepairItems = new List<RepairItemAddRequest>();

                    foreach (var item in repair.RepairItems)
                    {
                        RepairItemAddRequest req = new RepairItemAddRequest()
                        {
                            Quantity = item.Quantity,
                            RepairId = repair.RepairId,
                            SaparePartId = item.SaparePart.SaparePartId
                        };

                        model.RepairItems.Add(req);
                    }
                }
                else
                {
                    model.RepairItems = new List<RepairItemAddRequest>();
                }

                var key = "repairUpdateRequest";
                var data = model;
                HttpContext.Session.SetString(key, JsonConvert.SerializeObject(data));
            }

            if (saparepartId != null && quantity != null)
            {
                var newRepairItem = new RepairItemAddRequest()
                {
                    RepairId = model.RepairId,
                    SaparePartId = saparepartId.Value,
                    Quantity = quantity.Value
                };

                if (model.RepairItems != null)
                {
                    model.RepairItems.Add(newRepairItem);

                    var key = "repairUpdateRequest";
                    var data = model;
                    HttpContext.Session.SetString(key, JsonConvert.SerializeObject(data));
                }

            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRepair(RepairUpdateRequest repairUpdateRequest)
        {
            if (ModelState.IsValid)
            {
                if (repairUpdateRequest.StatusId == 2)
                {
                    foreach (var item in repairUpdateRequest.RepairItems)
                    {
                        item.RepairId = repairUpdateRequest.RepairId;
                    }
                }

                await _repairService.UpdateRepairAsync(repairUpdateRequest);
                HttpContext.Session.Clear();
                return RedirectToAction("Details", "Repair", new { repairId = repairUpdateRequest.RepairId });
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRepairStatus(int repairId, int statusId)
        {
            var repair = await _repairService.GetRepairByIdAsync(repairId);

            if (repair != null)
            {
                RepairUpdateRequest model = new RepairUpdateRequest();

                model.CustomerId = repair.CustomerId;
                model.Description = repair.Description;
                model.RepairId = repair.RepairId;
                model.StatusId = statusId;
                model.ProductId = repair.ProductId;

                var host = HttpContext.Request.Host.Host;
                var port = HttpContext.Request.Host.Port;
                var apiUri = host + ":" + port;
                if (port == null)
                {
                    apiUri = host;
                }

                model.Links = new Core.Models.Healpers.CustomerDecisionLink();
                model.Links.DecisionLink = Url.Action("DecisionTaken", "Repair", new { repairId = model.RepairId }, "https", apiUri);

                model.RepairItems = new List<RepairItemAddRequest>();

                foreach (var item in repair.RepairItems)
                {
                    RepairItemAddRequest req = new RepairItemAddRequest()
                    {
                        Quantity = item.Quantity,
                        RepairId = repair.RepairId,
                        SaparePartId = item.SaparePart.SaparePartId
                    };

                    model.RepairItems.Add(req);
                }

                return await UpdateRepair(model);
            }

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet("{repairId}")]
        public async Task<IActionResult> CustomerDecision(int repairId)
        {
            var repairModel = await _repairService.GetRepairByIdAsync(repairId);

            if (repairModel == null)
            {
                return BadRequest("Repair does not exists");
            }

            if (repairModel.StatusId != 2)
            {
                return RedirectToAction("DecisionTaken", "Repair", new { repairId = repairModel.RepairId });
            }

            return View(repairModel);
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomerConfirmOrDenyRepair(int repairId, int statusId)
        {
            var repair = await _repairService.GetRepairByIdAsync(repairId);

            if (repair != null && repair.StatusId == 2)
            {
                if (statusId == 3 || statusId == 6)
                {
                    return await UpdateRepairStatusCustomer(repairId, statusId);
                }
            }

            return BadRequest();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRepairStatusCustomer(int repairId, int statusId)
        {
            var repair = await _repairService.GetRepairByIdAsync(repairId);

            if (repair != null)
            {
                RepairUpdateRequest model = new RepairUpdateRequest();

                model.CustomerId = repair.CustomerId;
                model.Description = repair.Description;
                model.RepairId = repair.RepairId;
                model.StatusId = statusId;
                model.ProductId = repair.ProductId;

                model.RepairItems = new List<RepairItemAddRequest>();

                foreach (var item in repair.RepairItems)
                {
                    RepairItemAddRequest req = new RepairItemAddRequest()
                    {
                        Quantity = item.Quantity,
                        RepairId = repair.RepairId,
                        SaparePartId = item.SaparePart.SaparePartId
                    };

                    model.RepairItems.Add(req);
                }

                return await UpdateRepairClient(model);
            }

            return BadRequest();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRepairClient(RepairUpdateRequest repairUpdateRequest)
        {
            if (ModelState.IsValid)
            {
                await _repairService.UpdateRepairAsync(repairUpdateRequest);
                HttpContext.Session.Clear();
                return RedirectToAction("DecisionTaken", "Repair", new { repairId = repairUpdateRequest.RepairId });
            }

            return BadRequest(ModelState);
        }

        [AllowAnonymous]
        [HttpGet("{repairId}")]
        public async Task<IActionResult> DecisionTaken(int repairId)
        {
            var repairModel = await _repairService.GetRepairByIdAsync(repairId);

            if (repairModel == null)
            {
                return BadRequest("Repair does not exists");
            }

            if (repairModel.StatusId == 2)
            {
                return RedirectToAction("CustomerDecision", "Repair", new { repairId = repairModel.RepairId });
            }

            return View(repairModel);
        }


        [HttpPost("{repairId}")]
        public async Task<IActionResult> RemoveRepair(int repairId)
        {
            await _repairService.RemoveRepairAsync(repairId);

            return RedirectToAction("Index", "Repair");
        }

    }
}