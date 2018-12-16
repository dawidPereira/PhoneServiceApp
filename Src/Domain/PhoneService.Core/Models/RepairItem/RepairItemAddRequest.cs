using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Models.RepairItem
{
    public class RepairItemAddRequest
    {
        public int SaparePartId { get; set; }
        public int RepairId { get; set; }
        public int Quantity { get; set; }
    }
}
