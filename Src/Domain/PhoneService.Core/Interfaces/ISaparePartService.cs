using PhoneService.Core.Models.SaparePart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Interfaces
{
    public interface ISaparePartService
    {
        Task<IEnumerable<SaparePartResponse>> GetAllSaparePartByProductIdAsync(int productId);

        Task<SaparePartResponse> GetSaparePartByIdAsync(int saparePartId);

        Task AddSaparePartAsync(SaparePartRequest saparePartRequest);

        Task UpdateSaparePartAsync(SaparePartUpdateRequest saparePartRequest);

        Task RemoveSaparePartAsync(int saparePartId);
    }
}
