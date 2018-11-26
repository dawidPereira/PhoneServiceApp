using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class Repair
    {
        public int RepairId { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
        public ICollection<SaparePartItem> SaparePartItem { get; set; }
        public RepairStatus RepairStatus { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<SaparePart> SapareParts { get; set; }

        public Customer Customer { get; set; }

    }
}
