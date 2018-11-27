using System;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneService.App.Models;
using PhoneService.Core;

namespace PhoneService.App
{

    public class HomeController : BaseController
    {

        //public IActionResult Index()
        //{
        //    return View();
        //}
        public async Task<ActionResult<CustomersListViewModel>> Index()
        {
            return Ok(await Mediator.Send(new GetCustomersListQuery()));
        }

        public IActionResult About()    
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
