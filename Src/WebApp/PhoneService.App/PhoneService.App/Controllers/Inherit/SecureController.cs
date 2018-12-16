using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PhoneService.App.Controllers.Inherit
{
    [Authorize]
    public abstract class SecureController : Controller
    {
        //All secure controllers should inherit from this controller
    }
}
