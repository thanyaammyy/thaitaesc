using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib
{
    public partial class Match
    {
        public string TeamName
        {
            get
            {
                using (var dc = new ThaitaeDataDataContext())
                {
                    var teamName = dc.Teams.SingleOrDefault(item => item.TeamId == TeamHomeId);
                    if (teamName != null) return teamName.TeamName;
                    return "Not Found";
                }
            }
        }

        public string TeamAwayIdName
        {
            get
            {
                using (var dc = new ThaitaeDataDataContext())
                {
                    var teamName = dc.Teams.SingleOrDefault(item => item.TeamId == TeamAwayId);
                    if (teamName != null) return teamName.TeamName;
                    return "Not Found";
                }
            }
        }
    }
}