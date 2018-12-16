using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace PhoneService.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            Id = Guid.NewGuid();
            SecurityStamp = Guid.NewGuid().ToString();
        }
    }
}
