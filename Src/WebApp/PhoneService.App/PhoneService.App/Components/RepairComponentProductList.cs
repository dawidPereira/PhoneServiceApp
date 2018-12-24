using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Services;

namespace PhoneService.App.Components
{
    public class RepairComponentProductList : ViewComponent
    {
        private readonly IProductService _productService;

        public RepairComponentProductList(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllProductAsync();

            return View("SelectListProducts",products);
        }
    }
}
