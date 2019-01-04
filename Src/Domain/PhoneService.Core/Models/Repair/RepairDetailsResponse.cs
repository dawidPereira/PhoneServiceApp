using PhoneService.Core.Models.Product;
using PhoneService.Core.Models.RepairItem;
using System;
using System.Collections.Generic;
using System.Text;
using PhoneService.Core.Models.Customer;
using PhoneService.Core.Models.SaparePart;

namespace PhoneService.Core.Models.Repair
{
    public class RepairDetailsResponse
    {
        public int RepairId { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string StatusName { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int StatusId { get; set; }

        public CustomerDetailsResponse CustomerDetails { get; set; }
        public ProductResponse Product { get; set; }

        public List<SaparePartResponse> SapareParts { get; set; }
        public List<RepairItemResponse> RepairItems { get; set; }
    }
}
