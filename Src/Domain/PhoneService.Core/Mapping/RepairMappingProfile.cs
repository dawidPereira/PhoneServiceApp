using AutoMapper;
using PhoneService.Core.Models.Repair;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Mapping
{
    public class RepairMappingProfile : Profile
    {
        public RepairMappingProfile()
        {
            CreateMap<Repair, RepairResponse>();
            CreateMap<Repair, RepairDetailsResponse>();
            CreateMap<RepairAddRequest, Repair>();
            CreateMap<RepairUpdateRequest, Repair>();

        }
    }
}
