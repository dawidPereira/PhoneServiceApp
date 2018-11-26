using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class PhoneNumber : ValueObject
    {
        public string PhoneNum { get; set; }
    }
}
