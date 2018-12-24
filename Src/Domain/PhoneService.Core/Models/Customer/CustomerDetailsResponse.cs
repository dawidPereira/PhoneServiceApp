using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneService.Core.Models.Customer
{
    public class CustomerDetailsResponse
    {
        public int CustomerId { get; set; }
        public int CustomerAddresId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string TaxNum { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string PostCode { get; set; }
    }
}
