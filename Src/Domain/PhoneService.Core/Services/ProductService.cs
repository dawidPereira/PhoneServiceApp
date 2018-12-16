using AutoMapper;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Models.Product;
using PhoneService.Domain;
using PhoneService.Domain.Repository.IUnitOfWork;
using PhoneService.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly NullCheckMethod _nullCheckMethod;

        public ProductService(IUnitOfWork unitOfWork, NullCheckMethod nullCheckMethod)
        {
            _unitOfWork = unitOfWork;
            _nullCheckMethod = nullCheckMethod;
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProductAsync()
        {
             var products = await _unitOfWork.Products.GetAllProductsAsync();

            _nullCheckMethod.CheckIfResponseListIsEmpty(products);

            var customersResponse = Mapper.Map<IEnumerable<ProductResponse>>(products);
            return customersResponse;
        }

        public async Task<ProductResponse> GetProductByIdAsync(int productId)
        {
            _nullCheckMethod.CheckIfRequestIsNull(productId);

            var product = await _unitOfWork.Products.GetProductByIdAsync(productId);

            _nullCheckMethod.CheckIfResponseIsNull(product);

            var productResponse = Mapper.Map<ProductResponse> (product);
            return productResponse;
        }
        public async Task AddCustomerAsync(ProductAddRequest customerRequest)
        {
            _nullCheckMethod.CheckIfRequestIsNull(customerRequest);

            var product = await _unitOfWork.Products.GetProductByModelAsync(customerRequest.Model);

            _nullCheckMethod.CheckIfResponseIsNull(product);

            var _product = Mapper.Map<Product>(customerRequest);

            _unitOfWork.Products.AddProduct(_product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateCustomerAsync(ProductUpdateRequest customerRequest)
        {
            _nullCheckMethod.CheckIfRequestIsNull(customerRequest);

            var product = await _unitOfWork.Products.GetProductByIdAsync(customerRequest.ProductId);

            _nullCheckMethod.CheckIfResponseIsNull(product);

            var _product = Mapper.Map(customerRequest, product);
            await _unitOfWork.CompleteAsync();

        }

        public async Task RemoveCustomerAsync(int productId)
        {
            _nullCheckMethod.CheckIfRequestIsNull(productId);

            var product = await _unitOfWork.Products.GetProductByIdAsync(productId);

            _nullCheckMethod.CheckIfResponseIsNull(product);

            _unitOfWork.Products.RemoveProduct(product);
            await _unitOfWork.CompleteAsync();
        }


    }
}
