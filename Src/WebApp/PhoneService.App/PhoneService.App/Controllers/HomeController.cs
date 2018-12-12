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
using PhoneService.Core.Repository;
using PhoneService.Domain.Repository.IUnitOfWork;

namespace PhoneService.App
{

    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _unitOfWork.Customers.GetAllCustomersAsync());
        }

        [HttpGet("Customer/{id}")]
        public async Task<IActionResult> GetCustomerDetails(int id)
        {
            return Ok(await _unitOfWork.Customers.GetCustomerByIdAsync(id));
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
