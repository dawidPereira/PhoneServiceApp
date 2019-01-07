using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.App.Controllers.Inherit;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Mapping;
using PhoneService.Core.Models.SaparePart;

namespace PhoneService.App.Controllers
{
    [Route("[controller]/[action]")]
    public class SaparePartController : SecureController
    {
        private ISaparePartService _saparePartService;
        private readonly SaparePartMappingProfile _saparePartMappingProfile;

        public SaparePartController(ISaparePartService saparePartService, SaparePartMappingProfile saparePartMappingProfile)
        {
            _saparePartService = saparePartService;
            _saparePartMappingProfile = saparePartMappingProfile;
        }



        [HttpGet("{productId}")]
        public async Task<IActionResult> AddSaparePart(int productId)
        {
            try
            {
                var model = new SaparePartAddRequest()
                {
                    ProductId = productId
                };

                return View(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSaparePart(SaparePartAddRequest saparePartAddRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _saparePartService.AddSaparePartAsync(saparePartAddRequest);
                    return RedirectToAction("Details", "Product", new { productId = saparePartAddRequest.ProductId });
                }

                return View(saparePartAddRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{saparePartId}/{productId}")]
        public async Task<IActionResult> UpdateSaparePart(int saparePartId, int productId)
        {
            try
            {
                var part = await _saparePartService.GetProductSaparePartByIdAsync(saparePartId, productId);
                var model = AutoMapper.Mapper.Map<SaparePartUpdateRequest>(part);

                if (model != null)
                {
                    return View(model);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSaparePart(SaparePartUpdateRequest saparePartUpdateRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _saparePartService.UpdateSaparePartAsync(saparePartUpdateRequest);
                    return RedirectToAction("Details", "Product", new { productId = saparePartUpdateRequest.ProductId });
                }

                return View(saparePartUpdateRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("{saparePartId}/{productId}")]
        public async Task<IActionResult> RemoveSaparePart(int? saparePartId, int? productId)
        {
            try
            {
                if (saparePartId != null && productId != null)
                {
                    await _saparePartService.RemoveSaparePartAsync(saparePartId.Value);
                    return RedirectToAction("Details", "Product", new { productId = productId.Value });
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}