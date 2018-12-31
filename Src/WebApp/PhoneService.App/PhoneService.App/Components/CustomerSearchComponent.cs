using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.Core.Models.Customer;

namespace PhoneService.App.Components
{
    public class CustomerSearchComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var customerSearch = new CustomerSearchRequest();

            return View("CustomerSearch", customerSearch);
        }
    }
}
