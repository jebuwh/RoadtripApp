using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;


namespace RoadtripApp.Controllers
{
    public class BoxScoresController : Controller
    {
        private readonly IBoxScoresRepository repo;

        public BoxScoresController(IBoxScoresRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult BoxScores()
        {
            var bs = repo.GetAllBoxScores();

            return View(bs);
        }
    }
}
