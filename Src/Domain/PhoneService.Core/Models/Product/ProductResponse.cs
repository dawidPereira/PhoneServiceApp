﻿using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Models.Product
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
    }
}