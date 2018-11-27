using MediatR;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core
{
    public class CreateCustomerCommand :IRequest
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string TaxNum { get; set; }
        public CustomerAddres Addres { get; set; }

    }
}
