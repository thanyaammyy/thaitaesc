using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trirand.Web.UI.WebControls;
using thaitae.lib;

namespace Thaitae.Backend
{
    public partial class MatchManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dc = new ThaitaeDataDataContext();
            var leagueList = dc.Leagues.Where(item => item.Active == 1);
            foreach (var league in leagueList)
            {
                Jqdropdownlist1.Items.Add(new JQListItem { Text = league.LeagueName, Value = league.LeagueId.ToString() });
                foreach (var season in league.Seasons)
                {
                    Jqdropdownlist2.Items.Add(new JQListItem { Text = season.SeasonName, Value = season.SeasonId.ToString() });
                }
            }
        }
    }
}