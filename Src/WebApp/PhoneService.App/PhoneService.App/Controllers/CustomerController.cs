using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.App.Controllers.Inherit;
using PhoneService.Core.Models.Customer;
using PhoneService.Core.Services;

namespace PhoneService.App.Controllers
{

    [Route("[controller]/[action]")]
    public class CustomerController : SecureController
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                return Ok(await _customerService.GetAllCustomersAsync());
            }
            catch (ArgumentNullException)
            {
                return NotFound("Customer List is Empty");
            }
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            try
            {
                return Ok(await _customerService.GetCustomerByIdAsync(customerId));
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("This Customer does not exist");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody]CustomerAddRequest customerRequest)
        {
            try
            {
                await _customerService.AddCustomerAsync(customerRequest);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (ArgumentException)
            {
                return BadRequest("This Customer already exist");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody]CustomerUpdateRequest customerRequest)
        {
            try
            {
                await _customerService.UpdateCustomerAsync(customerRequest);
                return Ok(NoContent());
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("This Customer does not exist");
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> RemoveCustomer(int customerId)
        {
            try
            {
                await _customerService.RemoveCustomerAsync(customerId);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("This Customer does not exist");
            }
        }
    }
}