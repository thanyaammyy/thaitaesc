using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib
{
    public partial class Match
    {
        public string MatchDateFormat
        {
            get { return MatchDate.ToString("dd/MM/yyyy"); }
            set { MatchDate = Convert.ToDateTime(value); }
        }

        public string TeamHomeString
        {
            get
            {
                if (TeamHomeId == Team.TeamId)
                    return Team.TeamName;
                else
                    return Team.TeamName;
            }
            set { }
        }
    }
}