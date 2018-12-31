using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Services;

namespace PhoneService.App.Components
{
    public class RepairComponentCustomerList : ViewComponent
    {
        private readonly ICustomerService _customerService;

        public RepairComponentCustomerList(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();

            return View("SelectListCustomers",customers);
        }
    }
}
