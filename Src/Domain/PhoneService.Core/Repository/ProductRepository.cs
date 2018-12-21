using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneService.Core.Services.Healpers;
using PhoneService.Domain;
using PhoneService.Domain.Repository;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected readonly PhoneServiceDbContext _context;
        protected readonly SearchFilterHealpers _searchFilterHealpers;

        public ProductRepository(PhoneServiceDbContext context, SearchFilterHealpers searchFilterHealpers)
        {
            _context = context;
            _searchFilterHealpers = searchFilterHealpers;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _context.Set<Product>().ToListAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var products = await _context.Set<Product>()
                            .FirstOrDefaultAsync(p => p.ProductId == productId);

            return products;
        }
        public async Task<IEnumerable<Product>> GetProductBySearchTermsAsync(Product product)
        {
            IEnumerable<Product> products = _context.Set<Product>()
                                .AsQueryable();

            var searchResponse = await _searchFilterHealpers.SearchByContains(products, product);
            var response = Mapper.Map<IEnumerable<Product>>(searchResponse);

            return response;
        }

        public async Task<Product> GetProductByModelAsync(string model)
        {
            var products = await _context.Set<Product>()
                            .FirstOrDefaultAsync(p => p.Model == model);

            return products;
        }

        public void AddProduct(Product product) => _context.Add(product);

        public void RemoveProduct(Product product) => _context.Remove(product);

    }
}
