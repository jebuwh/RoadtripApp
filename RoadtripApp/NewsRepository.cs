using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public class NewsRepository : INewsRepository
    {
        public IEnumerable<News> GetAllNews()
        {
            var client = new HttpClient();

            var key = System.IO.File.ReadAllText("../RoadtripApp/APIKey.txt");

            var newsAPIURL = $"https://api.sportsdata.io/v3/mlb/scores/json/News?key={key}";

            var response = client.GetStringAsync(newsAPIURL).Result;


            var answer = JArray.Parse(response);

            var leaguenews = new List<News>();


            foreach (var item in answer)
            {
                var news = new News();

                if (IsNullOrEmpty(item["Updated"]))
                {
                    news.DateUpdated = "0";
                }
                else
                {
                   news.DateUpdated = (string)item["Updated"];
                }

                if (IsNullOrEmpty(item["TimeAgo"]))
                {
                    news.TimeAgo = "0";
                }
                else
                {
                    news.TimeAgo = (string)item["TimeAgo"];
                }
                if (IsNullOrEmpty(item["Title"]))
                {
                    news.Title = "0";
                }
                else
                {
                    news.Title = (string)item["Title"];
                }
                if (IsNullOrEmpty(item["Content"]))
                {
                    news.Content = "0";
                }
                else
                {
                    news.Content = (string)item["Content"];
                }

                if (IsNullOrEmpty(item["Url"]))
                {
                    news.NewsURL = "0";
                }
                else
                {
                    news.NewsURL = (string)item["Url"];
                }

                if (IsNullOrEmpty(item["Team"]))
                {
                    news.TeamKey = "0";
                }
                else
                {
                    news.TeamKey = (string)item["Team"];
                }


                leaguenews.Add(news);
            }
            return leaguenews;
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
