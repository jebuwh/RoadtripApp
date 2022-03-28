using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public class TeamPlayer
    {
      public TeamPlayer()
      {

      }
        public IEnumerable<Team> Team { get; set; }
        public IEnumerable<Players> Players { get; set; }
    }
}
