using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace RoadtripApp.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamRepository repo;

        public TeamsController(ITeamRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Teams()
        {
            var teams = repo.GetAllTeams();

            return View(teams);
        }
    }
}
