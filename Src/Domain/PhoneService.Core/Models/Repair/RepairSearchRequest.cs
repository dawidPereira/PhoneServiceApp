using PhoneService.Core.Models.Customer;
using PhoneService.Core.Models.Healpers;
using PhoneService.Core.Models.Product;
using PhoneService.Core.Models.RepairItem;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PhoneService.Core.Models.Repair
{
    public class RepairSearchRequest
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string StatusName { get; set;}
        public IEnumerable<string> StatusList { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string ProducerName { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string ModelName { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string CustomerName { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string CustomerLastName { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string Email { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
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
