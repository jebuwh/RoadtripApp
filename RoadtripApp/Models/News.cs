using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public class News
    {
        public News()
        {

        }

        public string DateUpdated {get; set;}
        public string TimeAgo { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string NewsURL { get; set; }
        public string TeamKey { get; set; }
}
}
