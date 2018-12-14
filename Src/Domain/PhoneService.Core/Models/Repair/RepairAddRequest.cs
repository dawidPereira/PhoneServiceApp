using PhoneService.Core.Models.Product;
using PhoneService.Core.Models.RepairItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Models.Repair
{
    public class RepairAddRequest
    {
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string StatusName { get; set; }

        public CustomerDetailsResponse Customer { get; set; }
        public ProductResponse Product { get; set; }

        public List<RepairItemResponse> RepairItems { get; set; }
    }
}
