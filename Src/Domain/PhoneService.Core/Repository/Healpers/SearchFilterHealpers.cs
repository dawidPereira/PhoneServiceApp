using AutoMapper;
using PhoneService.Core.Models.Customer;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Services.Healpers
{
    public class SearchFilterHealpers
    {
        public IEnumerable<CustomerResponse> CustomerSearchFilter
                            (IEnumerable<Customer> customers, CustomerSearchRequest searchRequest)
        {
            //var searchTerms = Mapper.Map<Customer>(searchRequest);

            if (!String.IsNullOrWhiteSpace(searchRequest.CustomerId.ToString()))
                customers = customers.Where(c => c.CustomerId == searchRequest.CustomerId).ToList();

            if (!String.IsNullOrWhiteSpace(searchRequest.Name))
                customers = customers.Where(c => c.Name == searchRequest.Name).ToList();

            if (!String.IsNullOrWhiteSpace(searchRequest.LastName))
                customers = customers.Where(c => c.LastName == searchRequest.LastName).ToList();

            if (!String.IsNullOrWhiteSpace(searchRequest.PhoneNum))
                customers = customers.Where(c => c.PhoneNum == searchRequest.PhoneNum).ToList();

            if (!String.IsNullOrWhiteSpace(searchRequest.TaxNum))
                customers = customers.Where(c => c.TaxNum == searchRequest.TaxNum).ToList();

            if (!String.IsNullOrWhiteSpace(searchRequest.Adress))
                customers = customers.Where(c => c.Addres.Adress == searchRequest.Adress).ToList();

            if (!String.IsNullOrWhiteSpace(searchRequest.City))
                customers = customers.Where(c => c.Addres.City == searchRequest.City).ToList();

            if (!String.IsNullOrWhiteSpace(searchRequest.PostCode))
                customers = customers.Where(c => c.Addres.PostCode == searchRequest.PostCode).ToList();

            if (!String.IsNullOrWhiteSpace(searchRequest.Name))
                customers = customers.Where(c => c.Name == searchRequest.Name).ToList();

            return Mapper.Map<IEnumerable<CustomerResponse>>(customers);
        }
    }
}
