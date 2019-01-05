using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneService.App.DTO.Users
{
    public class UserAdminForEditDto
    {
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Old Password is required")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string RoleName { get; set; }
    }
}
