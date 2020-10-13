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
        private readonly IPlayersRepository _playerRepo;

        public TeamsController(ITeamRepository repo, IPlayersRepository _playerRepo)
        {
            this.repo = repo;
            this._playerRepo = _playerRepo;
        }

        public IActionResult Teams()
        {
            var teams = repo.GetAllTeams();

            var player = _playerRepo.GetAllPlayers();

            return View(teams);
        }
        
    }
}
