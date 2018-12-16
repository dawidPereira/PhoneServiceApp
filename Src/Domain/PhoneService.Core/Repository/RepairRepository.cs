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
                                    .ThenInclude(c => c.SaparePart)
                            .Include(c => c.RepairStatus)
                                .FirstOrDefaultAsync(c => c.RepairId == repairId);

            return repair;
        }

        public void AddRepair(Repair repairItem) => _context.Add(repairItem);

        public void RemoveRepair(Repair repairItem) => _context.Remove(repairItem);
    }
}
