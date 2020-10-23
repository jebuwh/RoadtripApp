using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public class PlayersRepository : IPlayersRepository
    {

        public IEnumerable<Players> GetAllPlayers()
        {
            var players = new List<Players>();

            foreach (var item in TeamRepository.GetKeys())
            {
                var key = item.Key;

                var client = new HttpClient();

                var keyapi = System.IO.File.ReadAllText("../RoadtripApp/APIKey.txt");

                var boxscoreURL = $"https://api.sportsdata.io/v3/mlb/scores/json/Players/{key}?key={keyapi}";

                Console.WriteLine(boxscoreURL);

                var response = client.GetStringAsync(boxscoreURL).Result;


                var answer = JArray.Parse(response);

                

                foreach (var it in answer)
                {
                    var player = new Players();

                    if (IsNullOrEmpty(it["Status"]))
                    {
                        player.Status = "0";
                    }
                    else
                    {
                        player.Status = (string)it["Status"];
                    }
                    if (IsNullOrEmpty(it["Jersey"]))
                    {
                        player.Jersey = 0;
                    }
                    else
                    {
                        player.Jersey = (int)it["Jersey"];
                    }
                    if (IsNullOrEmpty(it["Position"]))
                    {
                        player.Position = "0";
                    }
                    else
                    {
                        player.Position = (string)it["Position"];
                    }
                    if (IsNullOrEmpty(it["FirstName"]))
                    {
                        player.FirstName = "0";
                    }
                    else
                    {
                        player.FirstName = (string)it["FirstName"];
                    }
                    if (IsNullOrEmpty(it["LastName"]))
                    {
                        player.LastName = "0";
                    }
                    else
                    {
                        player.LastName = (string)it["LastName"];
                    }
                    if (IsNullOrEmpty(it["BatHand"]))
                    {
                        player.BatHand = "0";
                    }
                    else
                    {
                        player.BatHand = (string)it["BatHand"];
                    }
                    if (IsNullOrEmpty(it["ThrowHand"]))
                    {
                        player.ThrowHand = "0";
                    }
                    else
                    {
                        player.ThrowHand = (string)it["ThrowHand"];
                    }
                    if (IsNullOrEmpty(it["PhotoUrl"]))
                    {
                        player.Photo = "0";
                    }
                    else
                    {
                        player.Photo = (string)it["PhotoUrl"];
                    }

                    players.Add(player);

                }

                
            }
            Console.WriteLine(players);
            return players;
        }
            /*var client = new HttpClient();

            var boxscoreURL = $"https://api.sportsdata.io/v3/mlb/scores/json/Players/{item}?key=ab95e23a65c14b37bc7dea6950da78ec";

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
        }*/

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
    
