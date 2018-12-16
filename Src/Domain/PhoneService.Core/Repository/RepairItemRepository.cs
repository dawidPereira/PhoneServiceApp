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
    public class RepairItemRepository : IRepairItemRepository
    {
        protected readonly PhoneServiceDbContext _context;

        public RepairItemRepository(PhoneServiceDbContext context) => _context = context;

        public async Task<IEnumerable<RepairItem>> GetAllRepairItemByRepairIdAsync(int repairId)
        {
            var repairItems = await _context.Set<RepairItem>()
                                .Where(c => c.RepairId == repairId)
                                .ToListAsync();
            return repairItems;
        }

        public async Task<RepairItem> GetRepairItemByIdAsync(int repairId, int saparePartId)
        {
            var repairItem = await _context.Set<RepairItem>()
                                .FirstOrDefaultAsync(
                                c => c.RepairId == repairId 
                                && c.SaparePartId == saparePartId);

            return repairItem;
        }

        public void AddRepairItem(RepairItem repairItem) => _context.Add(repairItem);

        public void AddRangeRepairItem(ICollection<RepairItem> repairItems) => _context.AddRange(repairItems);

        public void RemoveRepairItem(RepairItem repairItem) => _context.Remove(repairItem);

        public void RemoveRangeRepairItems(IEnumerable<RepairItem> repairItems) => _context.RemoveRange(repairItems);
    }
}
