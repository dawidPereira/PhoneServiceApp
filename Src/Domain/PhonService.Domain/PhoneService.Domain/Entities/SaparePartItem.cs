using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class SaparePartItem
    {
        public int SaparePartItemId { get; set; }
        public int Quantity { get; set; }

        public ICollection<SaparePartSaparePartItem> SaparePartSaparePartItems { get; set; }
        public Repair Repair { get; set; }

    }
}
