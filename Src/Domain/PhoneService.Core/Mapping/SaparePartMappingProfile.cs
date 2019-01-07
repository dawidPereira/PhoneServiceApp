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
                    ReferenceNumebr = x.SaparePart.ReferenceNumebr,
                    ProductId = x.ProductId
                });

            CreateMap<SaparePartAddRequest, SaparePart>();

            //CreateMap<SaparePartUpdateRequest, SaparePart>()
            //    .ConstructUsing(x => new SaparePart
            //    {
            //        SaparePartId = x.SaparePartId,
            //        Name = x.Name,
            //        Price = x.Price,
            //        ReferenceNumebr = x.ReferenceNumebr,
            //        ProductSapareParts = Mapper.Map<SaparePartUpdateRequest, ProductSaparePart>
            //    });

            CreateMap<ProductSaparePart, SaparePartResponse>()
                .ConstructUsing(x => new SaparePartResponse
                {
                    SaparePartId = x.SaparePartId,
                    Name = x.SaparePart.Name,
                    Price = x.SaparePart.Price,
                    ReferenceNumebr = x.SaparePart.ReferenceNumebr,
                    ProductId = x.ProductId
                    
                });

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
