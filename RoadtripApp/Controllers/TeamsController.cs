using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

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

             return View(teams);
        }
        public IActionResult ViewPlayers()
        {
            var players = _playerRepo.GetAllPlayers();
            return View(players);
        }
        
    }
}
