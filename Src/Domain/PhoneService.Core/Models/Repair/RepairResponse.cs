using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Models.Repair
{
    public class RepairResponse
    {
        public int RepairId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Product { get; set; }
        public string Model { get; set; }
        public string RepairStatusName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string LastName { get; set; }
    }
}
