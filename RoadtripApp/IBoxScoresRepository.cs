using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadtripApp
{ 
    public interface IBoxScoresRepository
    {
        public IEnumerable<BoxScores> GetAllBoxScores();
    }
}
