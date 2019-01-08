using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneService.Core.Models.Customer
{

    public class CustomerSearchRequest
    {
        [Range(1, 9999999999999999, ErrorMessage = "Maksymalne Id to 9999999999999999")]
        public int CustomerId { get; set; }
        [StringLength(25, ErrorMessage ="Maksymalna długość zapytania to 25 znaków")]
        public string Name { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string LastName { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string Email { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string PhoneNum { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string TaxNum { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string City { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string Adress { get; set; }
        [StringLength(25, ErrorMessage = "Maksymalna długość zapytania to 25 znaków")]
        public string PostCode { get; set; }
    }
}
