using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Domain.Repository
{
    public interface IRepairItemRepository
    {
        Task<IEnumerable<RepairItem>> GetAllRepairItemByRepairIdAsync(int repairId);
        Task<RepairItem> GetRepairItemByIdAsync(int repairId, int saparePartId);
        void AddRepairItem(RepairItem repairItem);
        void AddRangeRepairItem(ICollection<RepairItem> repairItems);
        void RemoveRepairItem(RepairItem repairItem);
        void RemoveRangeRepairItems(IEnumerable<RepairItem> repairItems);
    }
}
