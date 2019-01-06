using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Differencing;

namespace PhoneService.App.DTO.Users
{
    public class UserAdminForCreateDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters long")]
        [MaxLength(30, ErrorMessage = "Username cannot be longer than 30 characters")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public Roles RoleName { get; set; }
    }

    public enum Roles
    {
        Appmaster = 1,
        User = 2
    }
}
