using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thaitae.lib;

namespace Thaitae
{
    public partial class ChampionsLeagueFinal : System.Web.UI.Page
    {
        public Match[] Match = new Match[15];
        public League League = new League();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["leagueId"])) return;
            var leagueId = Convert.ToInt32(Request.QueryString["leagueId"]);
            using (var dc = ThaitaeDataDataContext.Create())
            {
                League = dc.Leagues.Single(item => item.LeagueId == leagueId);
                var seasonId = dc.Seasons.OrderByDescending(item => item.SeasonId).First(item => item.LeagueId == leagueId).SeasonId;
                var matchList = dc.Matches.Where(item => item.SeasonId == seasonId).ToArray();
                var j = 0;
                for (var i = 0; i < matchList.Count(); i++)
                {
                    if (i % 2 == 0)
                    {
                        Match[j] = matchList[i];
                        j++;
                    }
                }
            }
        }
    }
}