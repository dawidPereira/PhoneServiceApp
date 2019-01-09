using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class SaparePart
    {
        public int SaparePartId { get; set; }
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal Price { get; set; }

        public ICollection<ProductSaparePart> ProductSapareParts { get; set; }
        public ICollection<RepairItem> RepairItems { get; set; }
    }
}
