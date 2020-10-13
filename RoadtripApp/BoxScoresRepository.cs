using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public class BoxScoresRepository : IBoxScoresRepository
    {
        public IEnumerable<BoxScores> GetAllBoxScores()
        {
            var client = new HttpClient();

            var today = DateTime.Now.ToString("yyyy-MMM-dd");


            var boxscoreURL = $"https://api.sportsdata.io/v3/mlb/scores/json/GamesByDate/{today}?key=ab95e23a65c14b37bc7dea6950da78ec";

            Console.WriteLine(boxscoreURL);

            var response = client.GetStringAsync(boxscoreURL).Result;

            var answer = JArray.Parse(response);
           
            var boxscores = new List<BoxScores>();

            foreach (var item in answer)
            {
                Console.WriteLine(item);
                
                var boxscore = new BoxScores();

                if (IsNullOrEmpty(item["Status"]))
                {
                    boxscore.Status = "0";
                }
                else
                {
                    boxscore.Status = (string)item["Status"];
                }
                if (IsNullOrEmpty(item["AwayTeam"]))
                {
                    boxscore.AwayTeam = "Away";
                }
                else
                {
                    boxscore.AwayTeam = (string)item["AwayTeam"];
                }
                if (IsNullOrEmpty(item["HomeTeam"]))
                {
                    boxscore.HomeTeam = "Home";
                }
                else
                {
                    boxscore.HomeTeam = (string)item["HomeTeam"];
                }
                if (IsNullOrEmpty(item["InningHalf"]))
                {
                    boxscore.InningHalf = "0";
                }
                else
                {
                    boxscore.InningHalf = (string)item["InningHalf"];
                }

                if (IsNullOrEmpty(item["Inning"]))
                {
                    boxscore.Inning = 0;
                }
                else
                {
                    boxscore.Inning = (int)item["Inning"];
                }

                if (IsNullOrEmpty(item["Outs"]))
                {
                    boxscore.Outs = 0;
                }
                else
                {
                    boxscore.Outs = (int)item["Outs"];
                }
                if (IsNullOrEmpty(item["Balls"]))
                {
                    boxscore.Balls = 0;
                }
                else
                {
                    boxscore.Balls = (int)item["Balls"];
                }
                if (IsNullOrEmpty(item["Strikes"]))
                {
                    boxscore.Strikes = 0;
                }
                else
                {
                    boxscore.Strikes = (int)item["Strikes"];
                }
                if (IsNullOrEmpty(item["AwayTeamRuns"]))
                {
                    boxscore.AwayTeamRuns = 0;
                }
                else
                {
                    boxscore.AwayTeamRuns = (int)item["AwayTeamRuns"];
                }
                if (IsNullOrEmpty(item["HomeTeamRuns"]))
                {
                    boxscore.HomeTeamRuns = 0;
                }
                else
                {
                    boxscore.HomeTeamRuns = (int)item["HomeTeamRuns"];
                }
                if (IsNullOrEmpty(item["AwayTeamHits"]))
                {
                    boxscore.AwayTeamHits = 0;
                }
                else
                {
                    boxscore.AwayTeamHits = (int)item["AwayTeamHits"];
                }
                if (IsNullOrEmpty(item["HomeTeamHits"]))
                {
                    boxscore.HomeTeamHits = 0;
                }
                else
                {
                    boxscore.HomeTeamHits = (int)item["HomeTeamHits"];
                }
                if (IsNullOrEmpty(item["AwayTeamErrors"]))
                {
                    boxscore.AwayTeamErrors = 0;
                }
                else
                {
                    boxscore.AwayTeamErrors = (int)item["AwayTeamErrors"];
                }
                if (IsNullOrEmpty(item["HomeTeamErrors"]))
                {
                    boxscore.HomeTeamErrors = 0;
                }
                else
                {
                    boxscore.HomeTeamErrors = (int)item["HomeTeamErrors"];
                }
                if (IsNullOrEmpty(item["RunnerOnFirst"]))
                {
                    boxscore.RunnerOnFirst = false;
                }
                else
                {
                    boxscore.RunnerOnFirst = (bool)item["RunnerOnFirst"];
                }
                if (IsNullOrEmpty(item["RunnerOnSecond"]))
                {
                    boxscore.RunnerOnSecond = false;
                }
                else
                {
                    boxscore.RunnerOnSecond = (bool)item["RunnerOnSecond"];
                }
                if (IsNullOrEmpty(item["RunnerOnThird"]))
                {
                    boxscore.RunnerOnThird = false;
                }
                else
                {
                    boxscore.RunnerOnThird = (bool)item["RunnerOnThird"];
                }

                boxscores.Add(boxscore);
                
            }
            
            return boxscores;

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
