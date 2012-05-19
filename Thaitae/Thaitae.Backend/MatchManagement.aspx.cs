using System;
using System.Linq;
using thaitae.lib;
using Trirand.Web.UI.WebControls;

namespace Thaitae.Backend
{
    public partial class MatchManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dc = new ThaitaeDataDataContext();
            var leagueList = dc.Leagues.Where(item => item.Active == 1).Select(item => new { item.LeagueId, item.LeagueName });
            ddlLeague.DataSource = leagueList;
            ddlLeague.DataTextField = "LeagueName";
            ddlLeague.DataValueField = "LeagueId";
            ddlLeague.DataBind();
            JqgridMatch1.DataSource = dc.Matches;
            JqgridMatch1.DataBind();
        }

        protected void JqgridMatch1_RowAdding(object sender, JQGridRowAddEventArgs e)
        {
        }

        protected void JqgridMatch1_RowDeleting(object sender, JQGridRowDeleteEventArgs e)
        {
        }

        protected void JqgridMatch1_RowEditing(object sender, JQGridRowEditEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var match = dc.Matches.Single(item => item.MatchId == Convert.ToInt32(e.RowKey));
                match.TeamAwayId = Convert.ToInt32(e.RowData["TeamAwayId"]);
                match.TeamHomeId = Convert.ToInt32(e.RowData["TeamHomeId"]);
                match.MatchDate = Convert.ToDateTime(e.RowData["MatchDate"]);
                dc.SubmitChanges();
            }
        }
    }
}