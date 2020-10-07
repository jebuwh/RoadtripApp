using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public class TeamRepository : ITeamRepository
    {
        public IEnumerable<Team> GetAllTeams()
        {
            var client = new HttpClient();

            var teamURL = "https://api.sportsdata.io/v3/mlb/scores/json/teams?key=ab95e23a65c14b37bc7dea6950da78ec";

            var response = client.GetStringAsync(teamURL).Result;


            var answer = JArray.Parse(response);

            var teams = new List<Team>();


            foreach (var item in answer)
            {
                var team = new Team();

                if (IsNullOrEmpty(item["TeamID"]))
                {
                    team.TeamID = 0;
                }
                else
                {
                    team.TeamID = (int)item["TeamID"];
                }

                if (IsNullOrEmpty(item["Key"]))
                {
                    team.Key = "0";
                }
                else
                {
                    team.Key = (string)item["Key"];
                }
                if (IsNullOrEmpty(item["City"]))
                {
                     team.City = "0";
                }
                else
                {
                    team.City = (string)item["City"];
                }
                if (IsNullOrEmpty(item["Name"]))
                {
                    team.Name = "0";
                }
                else
                {
                    team.Name = (string)item["Name"];
                }

                if (IsNullOrEmpty(item["League"]))
                {
                    team.League = "0";
                }
                else
                {
                    team.League = (string)item["League"];
                }

                if (IsNullOrEmpty(item["Division"]))
                {
                    team.Division = "0";
                }
                else
                {
                    team.Division = (string)item["Division"];
                }


                if (IsNullOrEmpty(item["WikipediaLogoUrl"]))
                {
                    team.Logo = "0";
                }
                else
                {
                    team.Logo = (string)item["WikipediaLogoUrl"];
                }

                if (IsNullOrEmpty(item["StadiumID"]))
                {
                    team.StadiumID = 0;
                }
                else
                {
                    team.StadiumID = (int)item["StadiumID"];
                }
                if (IsNullOrEmpty(item["PrimaryColor"]))
                {
                    team.PrimaryColor = "0";
                }
                else
                {
                    team.PrimaryColor = (string)item["PrimaryColor"];
                }




                teams.Add(team);
            }
            return teams;
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
