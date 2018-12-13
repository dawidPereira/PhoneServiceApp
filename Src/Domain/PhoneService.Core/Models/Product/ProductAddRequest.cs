using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Models.Product
{
    public class ProductAddRequest
    {
        public string Producer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
    }
}

