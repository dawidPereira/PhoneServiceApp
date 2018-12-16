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
    public class RepairRepository : IRepairRepository
    {
        protected readonly PhoneServiceDbContext _context;

        public RepairRepository(PhoneServiceDbContext context) => _context = context;


        public async Task<IEnumerable<Repair>> GetAllRepairsAsync()
        {
            var repairs = await _context.Set<Repair>()
                            .Include(c => c.Product)
                            .Include(c => c.RepairStatus)
                            .Include(c => c.Customer)
                            .ToListAsync();

            return repairs;
        }

        public async Task<Repair> GetRepairItemByIdAsync(int repairId)
        {
            var repair = await _context.Set<Repair>()
                            .Include(c => c.Customer)
                                    .ThenInclude(c => c.Addres)
                            .Include(c => c.Product)
                                    .ThenInclude(c => c.ProductSapareParts)
                            .Include(c => c.RepairItems)
                                    .ThenInclude(c => c.Join(_context.SapareParts,
                                                (b => b.SaparePart.SaparePartId),
                                                (cc => cc.SaparePartId),
                                                (b, cl) => new { RepairItem = b, SaparePart = cl }))
                            .Include(c => c.RepairStatus)
                            
                            .FirstOrDefaultAsync(c => c.RepairId == repairId);

            return repair;


                                //            .Join(_context.ProductSapareParts,
                                //                (b => b.ProductId),
                                //                (cc => cc.ProductId),
                                //                (b, cl) => new { Product = b, ProductSaparePart = cl })
                                //.Join(_context.SapareParts,
                                //                (b => b.ProductSaparePart.SaparePartId),
                                //                (cc => cc.SaparePartId),
                                //                (b, cl) => new { ProductSaparePart = b, SaparePart = cl })
        }

        public void AddRepair(Repair repairItem) => _context.Add(repairItem);

        public void RemoveRepair(Repair repairItem) => _context.Remove(repairItem);
    }
}
