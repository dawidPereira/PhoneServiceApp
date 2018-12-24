using AutoMapper;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Models.Repair;
using PhoneService.Domain;
using PhoneService.Domain.Repository.IUnitOfWork;
using PhoneService.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Services
{
    public class RepairService : IRepairService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly NullCheckMethod _nullCheckMethod;

        public RepairService(IUnitOfWork unitOfWork, NullCheckMethod nullCheckMethod)
        {
            _unitOfWork = unitOfWork;
            _nullCheckMethod = nullCheckMethod;
        }


        public async Task<IEnumerable<RepairResponse>> GetAllRepairsAsync()
        {
            var repairs = await _unitOfWork.Repairs.GetAllRepairsAsync();

            _nullCheckMethod.CheckIfResponseListIsEmpty(repairs);

            var repairsResponse = Mapper.Map<IEnumerable<RepairResponse>>(repairs);

            return repairsResponse;
        }

        public async Task<RepairDetailsResponse> GetRepairByIdAsync(int repairId)
        {
            _nullCheckMethod.CheckIfRequestIsNull(repairId);

            var repair = await _unitOfWork.Repairs.GetRepairItemByIdAsync(repairId);

            _nullCheckMethod.CheckIfResponseIsNull(repair);

            var repairResponse = Mapper.Map<RepairDetailsResponse>(repair);

            return repairResponse;
        }

        public async Task<IEnumerable<RepairResponse>> GetRepairBySearchTermsAsync(RepairSearchRequest searchRequest)
        {
            var searchFilter = Mapper.Map<Repair>(searchRequest);
            var repair = await _unitOfWork.Repairs.GetRepairBySearchTermsAsync(searchFilter);

            _nullCheckMethod.CheckIfResponseListIsEmpty(repair);

            var response = Mapper.Map<IEnumerable<RepairResponse>>(repair);

            return response;
        }

        public async Task AddRepairAsync(RepairAddRequest repairAddRequest)
        {
            _nullCheckMethod.CheckIfRequestIsNull(repairAddRequest);

            var _repair = Mapper.Map<Repair>(repairAddRequest);

            _unitOfWork.Repairs.AddRepair(_repair);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateRepairAsync(RepairUpdateRequest repairUpdateRequest)
        {
            _nullCheckMethod.CheckIfRequestIsNull(repairUpdateRequest);

            var repair = await _unitOfWork.Repairs.GetRepairItemByIdAsync(repairUpdateRequest.RepairId);

            _nullCheckMethod.CheckIfResponseIsNull(repair);

            var _repair = Mapper.Map(repairUpdateRequest, repair);

            await _unitOfWork.CompleteAsync();
        }

        public async Task RemoveRepairAsync(int repairId)
        {
            _nullCheckMethod.CheckIfRequestIsNull(repairId);

            var repair = await _unitOfWork.Repairs.GetRepairItemByIdAsync(repairId);
            var repairItem = await _unitOfWork.RepairItems.GetAllRepairItemByRepairIdAsync(repairId);

            _unitOfWork.RepairItems.RemoveRangeRepairItems(repairItem);
            _unitOfWork.Repairs.RemoveRepair(repair);
            await _unitOfWork.CompleteAsync();
        }
    }
}
