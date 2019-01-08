using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneService.Core.Models.Product
{
    public class ProductSearchRequest
    {
        public int ProductId { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string Producer { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string Model { get; set; }
        public string Description { get; set; }
    }
}
