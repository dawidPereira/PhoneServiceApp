using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Models.Customer
{
    public class CustomerAddRequest
    {
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
