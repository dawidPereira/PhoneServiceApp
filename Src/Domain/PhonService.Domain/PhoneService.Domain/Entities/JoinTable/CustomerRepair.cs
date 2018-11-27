using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class CustomerRepair
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int RepairId { get; set; }
        public Repair Repair { get; set; }
    }
}
