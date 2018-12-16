using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneService.App.DTO.Account
{
    public class UserForCreateDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters long")]
        [MaxLength(30, ErrorMessage = "Username cannot be longer than 30 characters")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
