using Microsoft.AspNetCore.Mvc;
using PhoneService.App.Controllers.Inherit;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Models.Product;
using PhoneService.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneService.App.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : SecureController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(ProductSearchRequest productSearch)
        {
            try
            {
                var model = await _productService.GetAllProductAsync();

                if (productSearch != null)
                {
                    model = await _productService.GetCustomerBySearchTermsAsync(productSearch);
                }

                return View(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Details(int productId)
        {
            var model = await _productService.GetProductByIdAsync(productId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(ProductAddRequest productAddRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _productService.AddProductAsync(productAddRequest);
                    return RedirectToAction("Index", "Customer");
                }

                return View(productAddRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UpdateProduct(int? id)
        {
            try
            {
                if (id != null)
                {
                    var product = await _productService.GetProductByIdAsync(id.Value);
                    var model = AutoMapper.Mapper.Map<ProductUpdateRequest>(product);

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
        public async Task<IActionResult> UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _productService.UpdateProductAsync(productUpdateRequest);
                    return RedirectToAction("Index", "Product");
                }

                return View(productUpdateRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> RemoveProduct(int? productId)
        {
            try
            {
                if (productId != null)
                {
                    await _productService.RemoveProductAsync(productId.Value);
                    return RedirectToAction("Index", "Product");
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
