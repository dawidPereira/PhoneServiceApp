using PhoneService.Core.Models.SaparePart;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Models.RepairItem
{
    public class RepairItemResponse
    {
        public SaparePartResponse SaparePart { get; set; }
        public int Quantity { get; set; }
    }
}
