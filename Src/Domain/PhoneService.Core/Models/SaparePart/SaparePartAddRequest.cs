using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneService.Core.Models.SaparePart
{
    public class SaparePartAddRequest
    {
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [StringLength(25, ErrorMessage = "Nazwa może mieć maksymalnie 25 znaków")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Numer Referencyjny może mieć maksymalnie 50 znaków")]
        public string ReferenceNumber { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Range(1 , 99999, ErrorMessage ="Cena musi zawierać się w przedziale od 0 do 99999 zł")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Id produktu jest wymagane")]
        public int ProductId { get; set; }
    }
}
