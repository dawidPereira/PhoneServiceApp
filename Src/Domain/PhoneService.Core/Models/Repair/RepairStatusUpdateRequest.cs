using PhoneService.Core.Models.Healpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneService.Core.Models.Repair
{
    public class RepairStatusUpdateRequest
    {
        [Required(ErrorMessage = "Id naprawy jest wymagane")]
        public int RepairId { get; set; }

        [Required(ErrorMessage = "Id statusu jest wymagane")]
        public int RepairStatusId { get; set; }

        public CustomerDecisionLink Links { get; set; }
    }
}
