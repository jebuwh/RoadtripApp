using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public class StadiumRepository : IStadiumRepository
    {

        
        public IEnumerable<Stadium> GetAllStadiums()
        {
            var client = new HttpClient();

            var stadiumURL = "https://api.sportsdata.io/v3/mlb/scores/json/Stadiums?key=ab95e23a65c14b37bc7dea6950da78ec";

            var response = client.GetStringAsync(stadiumURL).Result;


            var answer = JArray.Parse(response);

            var stadiums = new List<Stadium>();


            foreach (var item in answer)
            {
                var stadium = new Stadium();

                if (IsNullOrEmpty(item["Capacity"]))
                {
                    stadium.Capacity = 0;
                }
                else
                {
                    stadium.Capacity = (int)item["Capacity"];
                }

                if (IsNullOrEmpty(item["HomePlateDirection"]))
                {
                    stadium.HomePlateDirection = 0;
                }
                else
                {
                    stadium.HomePlateDirection = (int)item["HomePlateDirection"];
                }
                if (IsNullOrEmpty(item["GeoLat"]))
                {
                    stadium.GeoLat = 0;
                }
                else
                {
                    stadium.GeoLat = (double)item["GeoLat"];
                }
                if (IsNullOrEmpty(item["GeoLong"]))
                {
                    stadium.GeoLong = 0;
                }
                else
                {
                    stadium.GeoLong = (double)item["GeoLong"];
                }

                if (IsNullOrEmpty(item["State"]))
                {
                    stadium.State = null;
                }
                else
                {
                    stadium.State = (string)item["State"];
                }
                
                if (IsNullOrEmpty(item["City"]))
                {
                    stadium.City = "0";
                }
                else
                {
                    stadium.City = (string)item["City"];
                }


                if (IsNullOrEmpty(item["Active"]))
                {
                    stadium.Active = false;
                }
                else
                {
                    stadium.Active = (bool)item["Active"];
                }
                
                if (IsNullOrEmpty(item["Name"]))
                {
                    stadium.Name = "0";
                }
                else
                {
                    stadium.Name = (string)item["Name"];
                }
                if (IsNullOrEmpty(item["StadiumID"]))
                {
                    stadium.StadiumID = 0;
                }
                else
                {
                    stadium.StadiumID = (int)item["StadiumID"];
                }

                
                

                stadiums.Add(stadium);
            }
            return stadiums;
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
