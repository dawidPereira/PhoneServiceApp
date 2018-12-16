using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Models.SaparePart;

namespace PhoneService.App.Controllers
{
    [Route("[controller]/[action]")]
    public class SaparePartController : Controller
    {
        private ISaparePartService _saparePartService;

        public SaparePartController(ISaparePartService saparePartService)
        {
            _saparePartService = saparePartService;
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetSapareParts(int productId)
        {
            try
            {
                return Ok(await _saparePartService.GetAllSaparePartByProductIdAsync(productId));
            }
            catch (ArgumentNullException)
            {
                return NotFound("This product dont't have sapare part ore this product does not exist");
            }
        }

        [HttpGet("{saparePartId}")]
        public async Task<IActionResult> GetSaparePart(int saparePartId)
        {
            try
            {
                return Ok(await _saparePartService.GetSaparePartByIdAsync(saparePartId));
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("This Sapare Part does not exist");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSaparePart([FromBody]SaparePartAddRequest saparePartAddRequest)
        {
            try
            {
                await _saparePartService.AddSaparePartAsync(saparePartAddRequest);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (ArgumentException)
            {
                return BadRequest("This Sapare Part already exist");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSaparePart([FromBody]SaparePartUpdateRequest saparePartUpdateRequest)
        {
            try
            {
                await _saparePartService.UpdateSaparePartAsync(saparePartUpdateRequest);
                return Ok(NoContent());
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("This Sapare Part does not exist");
            }
        }

        [HttpDelete("{saparePartId}")]
        public async Task<IActionResult> RemoveSaparePart(int saparePartId)
        {
            try
            {
                await _saparePartService.RemoveSaparePartAsync(saparePartId);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("This Sapare Part does not exist");
            }
        }
    }
}