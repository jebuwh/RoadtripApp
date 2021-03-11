using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadtripApp
{
    interface IMasterTeamPlayers
    {
        public IEnumerable<MasterTeamPlayers> GetAllPlayers();
    }
}
