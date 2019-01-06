using PhoneService.Core.Models.Product;
using PhoneService.Core.Models.RepairItem;
using System;
using System.Collections.Generic;
using System.Text;
using PhoneService.Core.Models.Customer;
using System.ComponentModel.DataAnnotations;

namespace PhoneService.Core.Models.Repair
{
    public class RepairAddRequest
    {
        public string Description { get; set; }

        public DateTime? CreateTime { get; set; }
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Id klienta jest wymagane")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Id produktu jest wymagane")]
        public int ProductId { get; set; }

        public CustomerDetailsResponse CustomerDetails { get; set; }
        public ProductResponse Product { get; set; }

        public RepairAddRequest()
        {
            CreateTime = DateTime.Now;
            StatusId = 1;
        }
    }
}
