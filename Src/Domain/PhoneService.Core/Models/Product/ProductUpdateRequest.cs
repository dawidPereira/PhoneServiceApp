using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneService.Core.Models.Product
{
    public class ProductUpdateRequest
    {
        [Required(ErrorMessage = "Id jest wymagane")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Producent jest wymagany")]
        [StringLength(25, ErrorMessage = "Nazwa producenta może mieć maksymalnie 25 znaków")]
        public string Producer { get; set; }

        [Required(ErrorMessage = "Model jest wymagany")]
        [StringLength(25, ErrorMessage = "Nazwa modelu może mieć maksymalnie 25 znaków")]
        public string Model { get; set; }

        [StringLength(1000, ErrorMessage = "Opis może mieć maksymalnie może mieć maksymalnie 1000 znaków")]
        public string Description { get; set; }
    }
}
