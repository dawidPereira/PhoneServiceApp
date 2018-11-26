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

        public EmailAddres Email { get; set; }
        public PhoneNumber PhoneNum { get; set; }
        public TaxNumber TaxNum { get; set; }

        public CustomerAddres Addres { get; set; }

        public ICollection<Repair> RepairsList { get; set; }
    }
}
