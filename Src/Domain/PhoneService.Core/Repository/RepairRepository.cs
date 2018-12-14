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
    public class RepairRepository : IRepairRepository
    {
        protected readonly PhoneServiceDbContext _context;

        public RepairRepository(PhoneServiceDbContext context) => _context = context;


        public async Task<IEnumerable<Repair>> GetAllRepairsAsync()
        {
            var repairs = await _context.Set<Repair>()
                            .Include(c => c.Product)
                            .Include(c => c.RepairItems)
                            .Include(c => c.RepairStatus)
                            .ToListAsync();

            return repairs;
        }

        public async Task<Repair> GetRepairItemByIdAsync(int repairId)
        {
            var repair = await _context.Set<Repair>()
                            .FirstOrDefaultAsync(c => c.RepairId == repairId);

            return repair;
        }

        public void AddRepair(Repair repairItem) => _context.Add(repairItem);

        public void RemoveRepair(Repair repairItem) => _context.Remove(repairItem);
    }
}
