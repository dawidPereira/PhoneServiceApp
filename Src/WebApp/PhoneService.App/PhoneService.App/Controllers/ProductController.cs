using Microsoft.AspNetCore.Mvc;
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
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                return Ok(await _productService.GetAllProductAsync());
            }
            catch (ArgumentNullException)
            {
                return NotFound("Product List is Empty");
            }
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            try
            {
                return Ok(await _productService.GetProductByIdAsync(productId));
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("This Product does not exist");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]ProductAddRequest productAddRequest)
        {
            try
            {
                await _productService.AddCustomerAsync(productAddRequest);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (ArgumentException)
            {
                return BadRequest("This Product already exist");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody]ProductUpdateRequest productUpdateRequest)
        {
            try
            {
                await _productService.UpdateCustomerAsync(productUpdateRequest);
                return Ok(NoContent());
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("This Product does not exist");
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveCustomer(int productId)
        {
            try
            {
                await _productService.RemoveCustomerAsync(productId);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Request can not be empty");
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("This Product does not exist");
            }
        }
    }
}
