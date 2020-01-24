using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TpAspNet.Models;
using App.Data.Services;


namespace TpAspNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RestaurantsServices _services;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _services = new RestaurantsServices();

        }

        public IActionResult Index()
        {
            return View(_services.TopFive());
        }

        public IActionResult Privacy()        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
