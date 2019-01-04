using PhoneService.Core.Models.Product;
using PhoneService.Core.Models.RepairItem;
using System;
using System.Collections.Generic;
using System.Text;
using PhoneService.Core.Models.Customer;
using PhoneService.Core.Models.Healpers;
using System.ComponentModel.DataAnnotations;

namespace PhoneService.Core.Models.Repair
{
    public class RepairUpdateRequest
    {
        [Required(ErrorMessage = "Id naprawy jest wymagane")]
        public int RepairId { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Id statusu jest wymagane")]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Id klienta jest wymagane")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Id produktu jest wymagane")]
        public int ProductId { get; set; }

        public CustomerDecisionLink Links { get; set; }

        public List<RepairItemAddRequest> RepairItems { get; set; }
    }
}
