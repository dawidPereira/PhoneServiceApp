using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PhoneService.Domain;


namespace PhoneService.Core.Models.Customer
{
    public class CustomerUpdateRequest
    {
        [Required(ErrorMessage = "Id jest wymagane")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Id jest wymagane")]
        public int CustomerAddresId { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [StringLength(25, ErrorMessage = "Imię może mieć maksymalnie 25 znaków")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [StringLength(25, ErrorMessage = "Nazwisko może mieć maksymalnie 25 znaków")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [StringLength(25, ErrorMessage = "Email może mieć maksymalnie 25 znaków")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [StringLength(25, ErrorMessage = "Numer Telefonu może mieć maksymalnie 12 znaków")]
        public string PhoneNum { get; set; }

        public string TaxNum { get; set; }

        [Required(ErrorMessage = "Miasto jest wymagane")]
        [StringLength(25, ErrorMessage = "Nazwa miasta może mieć maksymalnie 25 znaków")]
        public string City { get; set; }

        public string Adress { get; set; }

        [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
        [StringLength(25, ErrorMessage = "Kod pocztowy może mieć maksymalnie 25 znaków")]
        public string PostCode { get; set; }
    }
}
