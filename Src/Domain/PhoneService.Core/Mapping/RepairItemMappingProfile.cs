using AutoMapper;
using PhoneService.Core.Models.RepairItem;
using PhoneService.Core.Models.SaparePart;
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
            CreateMap<RepairItem, RepairItemResponse>()
                .ConstructUsing(x => new RepairItemResponse
                {
                    SaparePart = Mapper.Map<SaparePartResponse>(x.SaparePart),
                    Quantity = x.Quantity
                    
                });
            CreateMap<RepairItemAddRequest, RepairItem>();
        }
    }
}
