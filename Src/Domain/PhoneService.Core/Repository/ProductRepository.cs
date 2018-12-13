using Microsoft.EntityFrameworkCore;
using PhoneService.Domain;
using PhoneService.Domain.Repository;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Repository
{
    public class ProductRepository : IProductRepository
    {

        protected readonly PhoneServiceDbContext _context;

        public ProductRepository(PhoneServiceDbContext context) => _context = context;

        public async Task<IEnumerable<Product>> GetAllCProductsAsync()
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
