using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoadtripApp.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Tickets()
        {
            return View();
        }
    }
}
