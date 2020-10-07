using GeoCoordinatePortable;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace RoadtripApp
{
    public class StadiumGeoLoc
    {
        public StadiumGeoLoc()
        {
            var client = new HttpClient();

            //API Url
            var stadiumURL = "https://api.sportsdata.io/v3/mlb/scores/json/Stadiums?key=ab95e23a65c14b37bc7dea6950da78ec";

            //Stores the JSON repsonse in a variable
            var response = client.GetStringAsync(stadiumURL).Result;

            //Parses through the response we received to get the value associated with
            //the NAME "quote"
            var answer = JArray.Parse(response);

            GeoCoordinate geo = new GeoCoordinate();

            var locations = new List<GeoCoordinate>();

           
            foreach (var item in answer)
            {
                
                geo.Latitude = (double)item["GeoLat"];
                geo.Longitude = (double)item["GeoLong"];
                
                
                locations.Add(geo);
                
            }
        }


        
            

}
}
