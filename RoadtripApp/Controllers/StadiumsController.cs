using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;


namespace RoadtripApp.Controllers
{
    public class StadiumsController : Controller
    {
        private readonly IStadiumRepository repo;

        public StadiumsController(IStadiumRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Stadiums()
        {
            var stadiums = repo.GetAllStadiums();

            return View(stadiums);
        }
        
    }
}
