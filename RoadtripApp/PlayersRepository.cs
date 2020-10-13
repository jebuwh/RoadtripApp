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



            var boxscoreURL = $"https://api.sportsdata.io/v3/mlb/scores/json/Players/LAD?key=ab95e23a65c14b37bc7dea6950da78ec";

            Console.WriteLine(boxscoreURL);

            var response = client.GetStringAsync(boxscoreURL).Result;


            var answer = JArray.Parse(response);

            var players = new List<Players>();

            foreach (var item in answer)
            {
                var player = new Players();

                if (IsNullOrEmpty(item["Status"]))
                {
                    player.Status = "0";
                }
                else
                {
                    player.Status = (string)item["Status"];
                }
                if (IsNullOrEmpty(item["Jersey"]))
                {
                    player.Jersey = 0;
                }
                else
                {
                    player.Jersey = (int)item["Jersey"];
                }
                if (IsNullOrEmpty(item["Position"]))
                {
                    player.Position = "0";
                }
                else
                {
                    player.Position = (string)item["Position"];
                }
                if (IsNullOrEmpty(item["FirstName"]))
                {
                    player.FirstName = "0";
                }
                else
                {
                    player.FirstName = (string)item["FirstName"];
                }
                if (IsNullOrEmpty(item["LastName"]))
                {
                    player.LastName = "0";
                }
                else
                {
                    player.LastName = (string)item["LastName"];
                }
                if (IsNullOrEmpty(item["BatHand"]))
                {
                    player.BatHand = "0";
                }
                else
                {
                    player.BatHand = (string)item["BatHand"];
                }
                if (IsNullOrEmpty(item["ThrowHand"]))
                {
                    player.ThrowHand = "0";
                }
                else
                {
                    player.ThrowHand = (string)item["ThrowHand"];
                }
                if (IsNullOrEmpty(item["PhotoUrl"]))
                {
                    player.Photo = "0";
                }
                else
                {
                    player.Photo = (string)item["PhotoUrl"];
                }

                players.Add(player);

            }

            return players;
        }

        public static bool IsNullOrEmpty(JToken token)
        {
            return (token == null) ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.String && token.ToString() == String.Empty) ||
                   (token.Type == JTokenType.Null);
        }
    }
}
    
