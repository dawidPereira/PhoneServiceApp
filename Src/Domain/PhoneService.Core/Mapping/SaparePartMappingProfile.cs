using AutoMapper;
using PhoneService.Core.Models.SaparePart;
using PhoneService.Domain;
using PhoneService.Domain.Repository.IUnitOfWork;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Mapping
{
    public class SaparePartMappingProfile : Profile
    {
        public SaparePartMappingProfile()
        {
            CreateMap<ProductSaparePart, SaparePartResponse>()
                .ConstructUsing(x => new SaparePartResponse
                {
                    Price = x .SaparePart.Price,
                    Name = x.SaparePart.Name,
                    SaparePartId = x.SaparePartId,
                    ProductId = x.ProductId,
                    ReferenceNumebr = x.SaparePart.ReferenceNumebr
                });

            CreateMap<SaparePart, SaparePartResponse>()
                .ConstructUsing(x => new SaparePartResponse
                {
                    Price = x.Price,
                    Name = x.Name,
                    ReferenceNumebr = x.ReferenceNumebr,
                    SaparePartId = x.SaparePartId,
                    ProductId = 1
                });

            CreateMap<ProductSaparePart, SaparePartResponse>()
                .ConstructUsing(x => new SaparePartResponse
                {
                    Price = x.SaparePart.Price,
                    Name = x.SaparePart.Name,
                    SaparePartId = x.SaparePartId,
                    ReferenceNumebr = x.SaparePart.ReferenceNumebr
                });

            CreateMap<SaparePartAddRequest, SaparePart>();

            CreateMap<SaparePartResponse, SaparePartUpdateRequest>()
                .ConstructUsing(x => new SaparePartUpdateRequest
                {
                    Name = x.Name,
                    Price = x.Price,
                    ProductId = x.ProductId,
                    SaparePartId = x.SaparePartId,
                    ReferenceNumebr = x.ReferenceNumebr
                });

        }
        public ProductSaparePart ConvertSaparePartUpdateRequestToProductSaparePart(SaparePartUpdateRequest saparePartUpdateRequest, ProductSaparePart saparePart)
        {
            saparePart.SaparePart.Name = saparePartUpdateRequest.Name;
            saparePart.SaparePart.Price = saparePartUpdateRequest.Price;
            saparePart.SaparePartId = saparePartUpdateRequest.SaparePartId;
            saparePart.SaparePart.ReferenceNumebr = saparePartUpdateRequest.ReferenceNumebr;

            return saparePart;
        }
    }
}
