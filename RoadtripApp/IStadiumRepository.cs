using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public interface IStadiumRepository
    {
        public IEnumerable<Stadium> GetAllStadiums();

        

    }
}
