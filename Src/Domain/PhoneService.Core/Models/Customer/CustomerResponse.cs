using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Models.Customer
{
    public class CustomerResponse
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string TaxNum { get; set; }
    }
}
