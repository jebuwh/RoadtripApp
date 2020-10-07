using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public class Stadium
    {
        public Stadium()
        {

        }

        public int StadiumID { get; set; }
        public bool? Active { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? Capacity { get; set; }
        public int? HomePlateDirection { get; set; }
        public double? GeoLat { get; set; }
        public double? GeoLong { get; set; }

        

    }
}
