using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneService.Core.Models.Product
{
    public class ProductAddRequest
    {

        [Required(ErrorMessage = "Producent jest wymagany")]
        [StringLength(25, ErrorMessage = "Nazwa producenta może mieć maksymalnie 25 znaków")]
        public string Producer { get; set; }

        [Required(ErrorMessage = "Model jest wymagany")]
        [StringLength(25, ErrorMessage = "Nazwa modelu może mieć maksymalnie 25 znaków")]
        public string Model { get; set; }

        public string Description { get; set; }
    }
}

