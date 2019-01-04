using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneService.Core.Models.RepairItem
{
    public class RepairItemAddRequest
    {
        [Required(ErrorMessage = "Id części zamiennej jest wymagane")]
        public int SaparePartId { get; set; }

        [Required(ErrorMessage = "Id naprawy jest wymagane")]
        public int RepairId { get; set; }

        [Required(ErrorMessage = "Ilość jest wymagana")]
        public int Quantity { get; set; }
    }
}
