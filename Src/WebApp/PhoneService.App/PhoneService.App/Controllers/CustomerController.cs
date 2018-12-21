using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneService.App.Controllers.Inherit;
using PhoneService.Core.Models.Customer;
using PhoneService.Core.Services;

namespace PhoneService.App.Controllers
{
    [AllowAnonymous]
    [Route("[controller]/[action]")]
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
            try
            {
                var model = await _customerService.GetAllCustomersAsync();

                return View(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Searching([FromBody] CustomerSearchRequest searchRequest)
        {
            var model = await _customerService.GetCustomerBySearchTermsAsync(searchRequest);

            return Ok(model);
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

        [HttpGet]
        public async Task<IActionResult> AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCustomer(CustomerAddRequest customerRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _customerService.AddCustomerAsync(customerRequest);
                    return RedirectToAction("Index", "Customer");
                }

                return View(customerRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UpdateCustomer(int? id)
        {
            try
            {
                if (id != null)
                {
                    var customer = await _customerService.GetCustomerByIdAsync(id.Value);
                    var model = AutoMapper.Mapper.Map<CustomerUpdateRequest>(customer);

                    if (model != null)
                    {
                        return View(model);
                    }
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
        public async Task<IActionResult> UpdateCustomer(CustomerUpdateRequest customerRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _customerService.UpdateCustomerAsync(customerRequest);
                    return RedirectToAction("Index", "Customer");
                }

                return View(customerRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("{customerId}")]
        public async Task<IActionResult> RemoveCustomer(int? customerId)
        {
            try
            {
                if (customerId != null)
                {
                    await _customerService.RemoveCustomerAsync(customerId.Value);
                    return RedirectToAction("Index", "Customer");
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