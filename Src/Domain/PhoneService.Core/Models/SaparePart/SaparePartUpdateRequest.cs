using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Models.SaparePart
{
    public class SaparePartUpdateRequest
    {
        public int SaparePartId { get; set; }
        public string Name { get; set; }
        public string ReferenceNumebr { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
    }
}
