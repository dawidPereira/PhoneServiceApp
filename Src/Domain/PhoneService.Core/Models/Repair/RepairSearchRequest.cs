using PhoneService.Core.Models.Customer;
using PhoneService.Core.Models.Healpers;
using PhoneService.Core.Models.Product;
using PhoneService.Core.Models.RepairItem;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PhoneService.Core.Models.Repair
{
    public class RepairSearchRequest
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string StatusName { get; set;}
        public IEnumerable<string> StatusList { get; set; }
        public string ProducerName { get; set; }
        public string ModelName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public RepairSearchRequest()
        {
            StatusList = new List<string>()
            {
                "Przyjeta",
                "Wyceniona",
                "W trakcie realizacji",
                "Zrealizowana",
                "Zakończona",
                "Odrzucona",
                "Zakończona bez naprawy"
            };
        }

    }
}
