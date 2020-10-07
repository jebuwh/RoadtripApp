using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public class Team
    {
      public Team()
      {

      }
     
        public int TeamID { get; set; }
        public string Key { get; set; }
        public string City { get; set; }
        public string League { get; set; }
        public string Name { get; set; }
        public string Division { get; set; }
        public string Logo { get; set; }
        public int StadiumID { get; set; }
        public string PrimaryColor { get; set; }


    }
}
