using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Models.Repair;

namespace PhoneService.App.Controllers
{
    [Route("[controller]/[action]")]
    public class RepairController : Controller
    {
        private IRepairService _repairService;

        public RepairController(IRepairService repairService)
        {
            _repairService = repairService;
        }
        [HttpGet]
        public async Task<IActionResult> GetRepairs()
        {
            try
            {
                return Ok(await _repairService.GetAllRepairsAsync());
            }
            catch (ArgumentNullException)
            {
                return NotFound("Repair List is Empty");
            }
        }

        [HttpGet("{repairId}")]
        public async Task<IActionResult> GetRepair(int repairId)
        {
            try
            {
                return Ok(await _repairService.GetRepairByIdAsync(repairId));
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("This Repair does not exist");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRepair([FromBody]RepairAddRequest repairAddRequest)
        {
            try
            {
                await _repairService.AddRepairAsync(repairAddRequest);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (ArgumentException)
            {
                return BadRequest("This Repair already exist");
            }
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