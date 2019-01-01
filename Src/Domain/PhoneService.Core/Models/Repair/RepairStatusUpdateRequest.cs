using PhoneService.Core.Models.Healpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Models.Repair
{
    public class RepairStatusUpdateRequest
    {
        public int RepairId { get; set; }
        public int RepairStatusId { get; set; }
        public CustomerDecisionLink Links { get; set; }
    }
}
