using AutoMapper;
using PhoneService.Core.Models;
using PhoneService.Core.Models.Product;
using PhoneService.Core.Models.Repair;
using PhoneService.Core.Models.RepairItem;
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
            CreateMap<Repair, RepairResponse>()
                 .ConvertUsing(x => new RepairResponse
                 {

                     RepairId = x.RepairId,
                     CustomerName = x.Customer.Name,
                     LastName = x.Customer.LastName,
                     CustomerId = x.CustomerId,
                     CreateDate = x.CreateDate,
                     Product = x.Product.Producer,
                     Model = x.Product.Model,
                     RepairStatusName = x.RepairStatus.Name
                 });

            CreateMap<Repair, RepairDetailsResponse>()
                 .ConvertUsing(x => new RepairDetailsResponse
                 {
                     RepairId = x.RepairId,
                     Description = x.Description,
                     StatusName = x.RepairStatus.Name,
                     CreateTime = x.CreateDate,
                     CustomerDetails = Mapper.Map<CustomerDetailsResponse>(x.Customer),
                     Product = Mapper.Map<ProductResponse>(x.Product),
                     RepairItems = Mapper.Map<IEnumerable<RepairItemResponse>>(x.RepairItems)
                 });


            
            CreateMap<RepairAddRequest, Repair>()
                .ConvertUsing(x => new Repair
                {
                    Description = x.Description,
                    RepairStatusId = x.StatusId,
                    CreateDate = x.CreateTime,
                    CustomerId = x.CustomerId,
                    ProductId = x.ProductId,
                    RepairItems = Mapper.Map<ICollection<RepairItem>>(x.RepairItems)
                });
            CreateMap<RepairUpdateRequest, Repair>();

        }
    }
}
