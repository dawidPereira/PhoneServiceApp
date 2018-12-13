using AutoMapper;
using PhoneService.Core.Models.SaparePart;
using PhoneService.Domain;
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
            CreateMap<SaparePartRequest, SaparePart>();
            CreateMap<SaparePartUpdateRequest, SaparePart>();
        }
    }
}
