using Microsoft.EntityFrameworkCore;
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
    public class SaparePartRepository : ISaparePartRepository
    {
        protected readonly PhoneServiceDbContext _context;

        public SaparePartRepository(PhoneServiceDbContext context) => _context = context;

        public async Task<IEnumerable<SaparePart>> GetAllSaparePartByProductIdAsync(int productId)
        {
            var sapareParts = await _context.Set<SaparePart>()
                                .Include(c => c.ProductSapareParts)
                                .Where(c => c.ProductSapareParts.Any(x => x.ProductId == productId))
                                .ToListAsync();

            return sapareParts;
        }

        public async Task<SaparePart> GetSaparePartByIdAsync(int saparePartId)
        {
            var saparePart = await _context.Set<SaparePart>()
                                .FirstOrDefaultAsync(c => c.SaparePartId == saparePartId);

            return saparePart;
        }

        public async Task<ProductSaparePart> GetProductSaparePartByIdAsync(int saparePartId, int productId)
        {
            var saparePart = await _context.Set<ProductSaparePart>()
                                .Include(c => c.SaparePart)
                                .Where(x => x.SaparePartId == saparePartId
                                && x.ProductId == productId)
                                .FirstOrDefaultAsync();

            return saparePart;
        }

        public async Task<SaparePart> GetLatestSaparePartAsync()
        {
            var saparePart = await _context.Set<SaparePart>()
                                .LastOrDefaultAsync();

            return saparePart;
        }

        public void AddSaparePart(SaparePart saparePart)
        {
            _context.SapareParts.Add(saparePart);
        }

        public void RemoveSaparePart(SaparePart saparePart)
        {
            _context.SapareParts.Remove(saparePart);
        }
    }
}
