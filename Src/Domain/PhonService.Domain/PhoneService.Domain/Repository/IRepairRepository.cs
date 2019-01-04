using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Domain.Repository
{
    public interface IRepairRepository
    {
        Task<IEnumerable<Repair>> GetAllRepairsAsync();
        Task<Repair> GetRepairItemByIdAsync(int repairId);
        Task<IEnumerable<Repair>> GetRepairBySearchTermsAsync(DateTime dateFrom, DateTime dateTo ,Repair repairRequest);
        void AddRepair(Repair repairItem);
        void UpdateRepair(Repair repairItem);
        void RemoveRepair(Repair repairItem);
    }
}
