using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class CustomerAddres
    {
        public int CustomerAddresId { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string PostCode { get; set; }

        public Customer Customer { get; set; }

    }
}
