using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Web_App.Models;
using TPS.Service;

namespace MVC_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly CityService _svcCity;
        public HomeController(CityService svcCity)
        {
            _svcCity = svcCity;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAttraction()
        {
            var ca = _svcCity.AddAttraction("A good place", "Nothing to see here", 1036074917);
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
