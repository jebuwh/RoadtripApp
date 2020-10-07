using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoadtripApp.Models;

namespace RoadtripApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStadiumRepository repo;

        public HomeController(IStadiumRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            ViewBag.Stadiums = repo.GetAllStadiums();
            var stadiums = repo.GetAllStadiums();

            return View(stadiums);
        }

        public IActionResult Stats()
        {
            return View();
        }

        public IActionResult Stadiums()
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
