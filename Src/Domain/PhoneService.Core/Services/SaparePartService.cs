using AutoMapper;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Mapping;
using PhoneService.Core.Models.SaparePart;
using PhoneService.Domain;
using PhoneService.Domain.Repository.IUnitOfWork;
using PhoneService.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Services
{
    public class SaparePartService : ISaparePartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly NullCheckMethod _nullCheckMethod;
        private readonly SaparePartMappingProfile _saparePartMappingProfile;

        public SaparePartService(IUnitOfWork unitOfWork, NullCheckMethod nullCheckMethod, SaparePartMappingProfile saparePartMappingProfile)
        {
            _unitOfWork = unitOfWork;
            _nullCheckMethod = nullCheckMethod;
            _saparePartMappingProfile = saparePartMappingProfile;
        }

        public async Task<IEnumerable<SaparePartResponse>> GetAllSaparePartByProductIdAsync(int productId)
        {
            _nullCheckMethod.CheckIfRequestIsNull(productId);

            var sapareParts = await _unitOfWork.SapareParts.GetAllSaparePartByProductIdAsync(productId);

            _nullCheckMethod.CheckIfResponseIsNull(sapareParts);

            var _sapareParts = Mapper.Map<IEnumerable<SaparePartResponse>>(sapareParts);

            return _sapareParts;
        }

        public async Task<SaparePartResponse> GetSaparePartByIdAsync(int saparePartId)
        {
            _nullCheckMethod.CheckIfRequestIsNull(saparePartId);

            var sapareParts = await _unitOfWork.SapareParts.GetSaparePartByIdAsync(saparePartId);

            _nullCheckMethod.CheckIfResponseIsNull(sapareParts);

            var _sapareParts = Mapper.Map<SaparePartResponse>(sapareParts);

            return _sapareParts;
        }
        public async Task<SaparePartResponse> GetProductSaparePartByIdAsync(int saparePartId, int productId)
        {
            _nullCheckMethod.CheckIfRequestIsNull(saparePartId);

            var sapareParts = await _unitOfWork.SapareParts.GetProductSaparePartByIdAsync(saparePartId, productId);

            _nullCheckMethod.CheckIfResponseIsNull(sapareParts);

            var _sapareParts = Mapper.Map<SaparePartResponse>(sapareParts);

            return _sapareParts;
        }

        public async Task AddSaparePartAsync(SaparePartAddRequest saparePartRequest)
        {
            _nullCheckMethod.CheckIfRequestIsNull(saparePartRequest);

            var saparePart = Mapper.Map<SaparePart>(saparePartRequest);

            _unitOfWork.SapareParts.AddSaparePart(saparePart);
            await _unitOfWork.CompleteAsync();

            var productSaparePart = new ProductSaparePart()
            {
                ProductId = saparePartRequest.ProductId,
                SaparePartId = saparePart.SaparePartId
            };

            _unitOfWork.ProductSaparePart.AddProductSaparePart(productSaparePart);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateSaparePartAsync(SaparePartUpdateRequest saparePartRequest)
        {
            _nullCheckMethod.CheckIfRequestIsNull(saparePartRequest);

            var saparePart = await _unitOfWork.SapareParts.GetProductSaparePartByIdAsync(saparePartRequest.SaparePartId, saparePartRequest.ProductId);

            _nullCheckMethod.CheckIfResponseIsNull(saparePartRequest);

            _saparePartMappingProfile.ConvertSaparePartUpdateRequestToProductSaparePart(saparePartRequest, saparePart);
            //Mapper.Map(saparePartRequest, saparePart);

            await _unitOfWork.CompleteAsync();
        }

        public async Task RemoveSaparePartAsync(int saparePartId)
        {
            _nullCheckMethod.CheckIfRequestIsNull(saparePartId);

            var saparePart = await _unitOfWork.SapareParts.GetSaparePartByIdAsync(saparePartId);

            _nullCheckMethod.CheckIfResponseIsNull(saparePart);

            var productSaparePart = new ProductSaparePart()
            {
                SaparePartId = saparePart.SaparePartId
            };

            _unitOfWork.SapareParts.RemoveSaparePart(saparePart);
            await _unitOfWork.CompleteAsync();
        }
    }
}
