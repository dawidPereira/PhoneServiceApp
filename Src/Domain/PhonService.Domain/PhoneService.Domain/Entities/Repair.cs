using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class Repair
    {
        public int RepairId { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }

        public RepairStatus RepairStatus { get; set; }
        public int RepairStatusId { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public ICollection<RepairItem> RepairItems { get; set; }



    }
}
