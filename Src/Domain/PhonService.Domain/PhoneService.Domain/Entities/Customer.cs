using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string TaxNum { get; set; }

        public CustomerAddres Addres { get; set; }

        public ICollection<CustomerRepair> CustomerRepairs { get; set; }
    }
}
