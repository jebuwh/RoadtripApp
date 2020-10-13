using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadtripApp
{
    public class BoxScores
    {
        public string Status { get; set; }
        public string AwayTeam { get; set; }
        public string HomeTeam { get; set; }
        public int Inning { get; set; }
        public string InningHalf { get; set; }
        public int Outs { get; set; }
        public int Balls { get; set;}
        public int Strikes { get; set; }
        public int AwayTeamRuns { get; set; }
        public int HomeTeamRuns { get; set; }
        public int AwayTeamHits { get; set; }
        public int HomeTeamHits { get; set; }
        public int AwayTeamErrors { get; set; }
        public int HomeTeamErrors { get; set; }
        public bool RunnerOnFirst { get; set; }
        public bool RunnerOnSecond { get; set; }
        public bool RunnerOnThird { get; set; }
    }
}
