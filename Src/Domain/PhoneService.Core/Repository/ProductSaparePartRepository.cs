using PhoneService.Domain;
using PhoneService.Domain.Repository;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Repository
{
    public class ProductSaparePartRepository : IProductSaparePartRepository
    {
        protected readonly PhoneServiceDbContext _context;

        public ProductSaparePartRepository(PhoneServiceDbContext context)
        {
            _context = context;
        }
        public void AddProductSaparePart(ProductSaparePart productSapare) => _context.Add(productSapare);
        public void RemoveProductSaparePart(ProductSaparePart productSapare) => _context.Add(productSapare);

    }
}
