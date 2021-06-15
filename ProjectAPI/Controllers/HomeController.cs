using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectAPI.Models;
using ProjectAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHomeRepository homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            this.homeRepository = homeRepository;
        }

        public IActionResult Index()
        {
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

        public IActionResult Homepage()
        {
            List<Distribuitor> distribuitors = new List<Distribuitor>();
            distribuitors = homeRepository.GetDistribuitors();
            return View(distribuitors);
        }
    }
}
