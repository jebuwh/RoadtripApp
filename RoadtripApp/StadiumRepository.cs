using GeoCoordinatePortable;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace RoadtripApp
{
    public class StadiumRepository
    {
        public StadiumRepository()
        {
            var client = new HttpClient();

            //API Url
            var stadiumURL = "https://api.sportsdata.io/v3/mlb/scores/json/Stadiums?key=ab95e23a65c14b37bc7dea6950da78ec";

            //Stores the JSON repsonse in a variable
            var response = client.GetStringAsync(stadiumURL).Result;

            //Parses through the response we received to get the value associated with
            //the NAME "quote"
            var answer = JArray.Parse(response);

            var locations = new List<Location>();

            

            foreach (var item in answer)
            {
                var loc = new Location();
                loc.Latitude = (double)item["GeoLat"];
                loc.Longitude = (double)item["GeoLong"];
                

                locations.Add(loc);
            }
        }


        
            

}
}
