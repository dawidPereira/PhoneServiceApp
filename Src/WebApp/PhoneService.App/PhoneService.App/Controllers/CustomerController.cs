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
    public class CustomerController : SecureController
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _customerService.GetAllCustomersAsync());
        }

        [HttpPost]
        [Route("[Controller]/Add")]
        public async Task<IActionResult> Post([FromBody]CustomerRequest customerRequest)
        {
            await _customerService.AddCustomerAsync(customerRequest);
            return Ok();
        }
    }
}