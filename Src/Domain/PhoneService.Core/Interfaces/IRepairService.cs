using PhoneService.Core.Models;
using PhoneService.Core.Models.Repair;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Interfaces
{
    public interface IRepairService
    {
        Task<IEnumerable<RepairResponse>> GetAllRepairsAsync();

        Task<RepairDetailsResponse> GetRepairByIdAsync(int repairID);

        Task AddRepairAsync(RepairAddRequest repairAddRequest);

        Task UpdateRepairAsync(RepairUpdateRequest repairUpdateRequest);

        Task RemoveRepairAsync(int repairId);
    }
}
