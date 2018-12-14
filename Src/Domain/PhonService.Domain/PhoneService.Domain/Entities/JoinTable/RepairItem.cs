using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class RepairItem
    {
        public int Quantity { get; set; }

        public SaparePart SaparePart { get; set; }
        public int SaparePartId { get; set; }

        public Repair Repair { get; set; }
        public int RepairId { get; set; }

    }
}
