using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class Repair
    {
        public int RepairId { get; set; }
        public string Description { get; set; }
        public RepairStatus RepairStatus { get; set; }
        public Customer Customer { get; set; }


        public ICollection<CustomerRepair> CustomerRepairs { get; set; }
        public ICollection<RepairProduct> RepairProducts { get; set; }
        public ICollection<SaparePartItem> SaparePartItems { get; set; }



    }
}
