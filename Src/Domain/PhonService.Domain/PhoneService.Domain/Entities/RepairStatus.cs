using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class RepairStatus
    {
        public int RepairStatusId { get; set; }
        public string Name { get; set; }

        public ICollection<Repair> Repairs { get; set; }
    }
}
