using PhoneService.Core.Models;
using PhoneService.Core.Models.Repair;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhoneService.Core.Models.Other;

namespace PhoneService.Core.Interfaces
{
    public interface IRepairService
    {
        Task<IEnumerable<RepairResponse>> GetAllRepairsAsync();

        Task<RepairDetailsResponse> GetRepairByIdAsync(int repairID);

        Task<IEnumerable<RepairResponse>> GetRepairBySearchTermsAsync(RepairSearchRequest searchRequest);

        Task UpdateRepairStatusAsync(RepairStatusUpdateRequest repairStatusUpdateRequest);

        Task AddRepairAsync(RepairAddRequest repairAddRequest);

        Task UpdateRepairAsync(RepairUpdateRequest repairUpdateRequest);

        Task RemoveRepairAsync(int repairId);

        Task<Statistics> GetRepairStatusCountAsync();

        Task<Statistics> GetRepairStatusCountBySearchAsync(RepairSearchRequest searchRequest);

    }
}
