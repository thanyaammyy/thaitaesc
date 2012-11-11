using System;
using System.Collections.Generic;
using System.Linq;
using thaitae.lib;

namespace Thaitae
{
    public partial class PlayerMatchResult : System.Web.UI.Page
    {
        public List<PlayerMatch> PlayerHomeList;
        public List<PlayerMatch> PlayerAwayList;
        public string TeamHome;
        public string TeamAway;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["MatchId"]))
                using (var dc = ThaitaeDataDataContext.Create())
                {
                    var match =
                        dc.Matches.Single(item => item.MatchId == Convert.ToInt32(Request.QueryString["MatchId"]));
                    TeamHome = match.TeamHomeIdName;
                    TeamAway = match.TeamAwayIdName;
                    PlayerHomeList = dc.PlayerMatches.Where(item => item.TeamId == match.TeamHomeId && item.MatchId == match.MatchId).ToList();
                    PlayerAwayList = dc.PlayerMatches.Where(item => item.TeamId == match.TeamAwayId && item.MatchId == match.MatchId).ToList();
                }
        }
    }
}