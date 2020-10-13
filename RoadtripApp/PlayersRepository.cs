using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public class PlayersRepository : IPlayersRepository
    {
        public IEnumerable<Players> GetAllPlayers()
        {
            var client = new HttpClient();

            Team team = new Team();

            var key = team.Key;

            var boxscoreURL = $"https://api.sportsdata.io/v3/mlb/scores/json/Players/{key}?key=ab95e23a65c14b37bc7dea6950da78ec";

            var response = client.GetStringAsync(boxscoreURL).Result;


            var answer = JArray.Parse(response);

            var players = new List<Players>();

            return players;
        }
    }
}
