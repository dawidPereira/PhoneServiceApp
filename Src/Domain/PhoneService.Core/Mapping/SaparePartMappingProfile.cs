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
            CreateMap<SaparePart, SaparePartResponse>();
            CreateMap<SaparePartAddRequest, SaparePart>();
            CreateMap<SaparePartUpdateRequest, SaparePart>();

            CreateMap<ProductSaparePart, SaparePartResponse>()
                .ConstructUsing(x => new SaparePartResponse
                {
                    SaparePartId = x.SaparePartId,
                    Name = x.SaparePart.Name,
                    Price = x.SaparePart.Price,
                    ReferenceNumebr = x.SaparePart.ReferenceNumebr
                });

        }
    }
}
