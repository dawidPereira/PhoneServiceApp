using System;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.App.Models;
using PhoneService.Persistance;
using System.Threading;
using PhoneService.App.Controllers.Inherit;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Repository;
using PhoneService.Domain;
using PhoneService.Domain.Repository.IUnitOfWork;

namespace PhoneService.App
{

    public class HomeController : SecureController
    {
        private readonly IRepairService _repairService;

        public HomeController(IRepairService repairService)
        {
            _repairService = repairService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var statistics = await _repairService.GetRepairStatusCountAsync();

            return View(statistics);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
