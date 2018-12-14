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
        void AddCustomer(RepairItem repairItem);
        void RemoveCustomer(RepairItem repairItem);
        void RemoveRangeCustomer(IEnumerable<RepairItem> repairItems);
    }
}
