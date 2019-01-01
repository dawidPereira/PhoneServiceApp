using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.Core.Models.Customer;
using PhoneService.Core.Models.Product;

namespace PhoneService.App.Components
{
    public class ProductSearchComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productSearch = new ProductSearchRequest();

            return View("ProductSearch", productSearch);
        }
    }
}
