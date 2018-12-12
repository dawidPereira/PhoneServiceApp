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
            CreateMap<Tuple<Customer, CustomerAddres>, CustomerDetailsResponse>()
                .ConvertUsing(x => new CustomerDetailsResponse
                {
                    CustomerId = x.Item1.CustomerId,
                    Name = x.Item1.Name,
                    LastName = x.Item1.LastName,
                    Email = x.Item1.Email,
                    TaxNum = x.Item1.TaxNum,
                    PhoneNum = x.Item1.PhoneNum,
                    City = x.Item2.City,
                    Adress = x.Item2.Adress,
                    PostCode = x.Item2.PostCode
                });

            CreateMap<Customer, CustomerResponse>();

            CreateMap<CustomerRequest, Customer>()
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
