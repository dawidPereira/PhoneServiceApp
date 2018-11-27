using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class RepairProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int RepairId { get; set; }
        public Repair Repair { get; set; }
    }
}
