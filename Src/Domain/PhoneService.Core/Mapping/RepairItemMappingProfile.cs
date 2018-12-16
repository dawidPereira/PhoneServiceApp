using AutoMapper;
using PhoneService.Core.Models.RepairItem;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Mapping
{
    public class RepairItemMappingProfile : Profile
    {
        public RepairItemMappingProfile()
        {
            CreateMap<RepairItem, RepairItemResponse>();
        }
    }
}
