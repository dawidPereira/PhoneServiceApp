using AutoMapper;
using PhoneService.Core.Models;
using PhoneService.Core.Models.Product;
using PhoneService.Core.Models.Repair;
using PhoneService.Core.Models.RepairItem;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using PhoneService.Core.Models.Customer;
using PhoneService.Core.Models.SaparePart;

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
                     StatusId = x.RepairStatus.RepairStatusId,
                     CreateTime = x.CreateDate,
                     CustomerId = x.CustomerId,
                     ProductId = x.ProductId,
                     SapareParts = Mapper.Map<List<SaparePartResponse>>(x.Product.ProductSapareParts),
                     CustomerDetails = Mapper.Map<CustomerDetailsResponse>(x.Customer),
                     Product = Mapper.Map<ProductResponse>(x.Product),
                     RepairItems = Mapper.Map<List<RepairItemResponse>>(x.RepairItems)
                 });

            CreateMap<RepairAddRequest, Repair>()
                .ConvertUsing(x => new Repair
                {
                    Description = x.Description,
                    RepairStatusId = x.StatusId,
                    CreateDate = x.CreateTime,
                    CustomerId = x.CustomerId,
                    ProductId = x.ProductId
                });

            CreateMap<RepairUpdateRequest, Repair>()
                .ConvertUsing(x => new Repair
                {
                    RepairId = x.RepairId,
                    Description = x.Description,
                    RepairStatusId = x.StatusId,
                    CustomerId = x.CustomerId,
                    ProductId = x.ProductId,
                    RepairItems = Mapper.Map<ICollection<RepairItem>>(x.RepairItems)
                });
        }
        public Repair ConvertRepairSearchRequestToRepair(RepairSearchRequest _repairSearchRequest, Repair repair)
        {

            repair.RepairStatus.Name = _repairSearchRequest.StatusName;
            repair.Product.Producer = _repairSearchRequest.ProducerName;
            repair.Product.Model = _repairSearchRequest.ModelName;
            repair.Customer.Name = _repairSearchRequest.CustomerName;
            repair.Customer.LastName = _repairSearchRequest.CustomerLastName;
            repair.Customer.Email = _repairSearchRequest.Email;
            repair.Customer.PhoneNum = _repairSearchRequest.PhoneNumber;

            return repair;
        }

        public Repair ConvertRepairAddRequestToRepair(RepairUpdateRequest repairUpdateRequest, Repair repair)
        {

            repair.RepairId = repairUpdateRequest.RepairId;
            repair.Description = repairUpdateRequest.Description;
            repair.RepairStatusId = repairUpdateRequest.StatusId;
            repair.CustomerId = repairUpdateRequest.CustomerId;
            repair.ProductId = repairUpdateRequest.ProductId;
            repair.RepairItems = Mapper.Map<ICollection<RepairItem>>(repairUpdateRequest.RepairItems);

            return repair;
        }
    }
}
