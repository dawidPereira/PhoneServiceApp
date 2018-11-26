using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class SaparePart
    {
        public int SaparePartId { get; set; }
        public string Name { get; set; }
        public ReferenceNumber ReferenceNumebr { get; set; }
        public decimal Price { get; set; }

        public ICollection<Product> ProductsList { get; set; }
        public ICollection<SaparePartItem> SaparePartItems { get; set; }
    }
}
