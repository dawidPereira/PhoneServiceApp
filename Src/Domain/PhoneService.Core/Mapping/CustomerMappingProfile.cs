using AutoMapper;
using PhoneService.Core.Models;
using PhoneService.Core.Models.Customer;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Mapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerDetailsResponse>()
                .ConvertUsing(x => new CustomerDetailsResponse
                 {
                     CustomerId = x.CustomerId,
                     Name = x.Name,
                     LastName = x.LastName,
                     Email = x.Email,
                     TaxNum = x.TaxNum,
                     PhoneNum = x.PhoneNum,
                     City = x.Addres.City,
                     Adress = x.Addres.Adress,
                     PostCode = x.Addres.PostCode
                 });

            CreateMap<Customer, CustomerResponse>();

            CreateMap<CustomerAddRequest, Customer>()
                .ConvertUsing(x => new Customer
                {
                    Name = x.Name,
                    LastName = x.LastName,
                    Email = x.Email,
                    TaxNum = x.TaxNum,
                    PhoneNum = x.PhoneNum,
                    Addres = new CustomerAddres()
                    {
                        City = x.City,
                        Adress = x.Adress,
                        PostCode = x.PostCode
                    }
                });

            CreateMap<CustomerUpdateRequest, Customer>()
                .ConvertUsing(x => new Customer
                {
                    Name = x.Name,
                    LastName = x.LastName,
                    Email = x.Email,
                    TaxNum = x.TaxNum,
                    PhoneNum = x.PhoneNum,
                    Addres = new CustomerAddres()
                    {
                        City = x.City,
                        Adress = x.Adress,
                        PostCode = x.PostCode
                    }
                });
        }
    }
}
