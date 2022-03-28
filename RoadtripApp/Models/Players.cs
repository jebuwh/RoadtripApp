using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public class Players
    {
        public string Status { get; set; }
        public int Jersey { get; set; }
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BatHand { get; set; }
        public string ThrowHand { get; set; }
        public string Photo { get; set; }
        public string Team { get; internal set; }
    }
}
