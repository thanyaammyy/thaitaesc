using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trirand.Web.UI.WebControls;
using thaitae.lib;

namespace Thaitae.Backend
{
    public partial class League : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dc = new ThaitaeDataDataContext();
            JqgridLeague1.DataSource = dc.Leagues;
            JqgridLeague1.DataBind();
			var leagueList = dc.Leagues.Where(item => item.Active == 1).Select(item => new { item.LeagueId, item.LeagueName });
			ddlLeague.DataSource = leagueList;
			ddlLeague.DataTextField = "LeagueName";
			ddlLeague.DataValueField = "LeagueId";
			ddlLeague.DataBind();

        }

        protected void JqgridLeague1_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var league = dc.Leagues.Single(item => item.LeagueId == Convert.ToInt32(e.RowKey));
                league.LeagueName = e.RowData["LeagueName"];
                league.LeagueType = Convert.ToInt32(e.RowData["LeagueTypeName"]);
                league.LeagueDesc = e.RowData["LeagueDesc"];
                league.Active = Convert.ToInt32(e.RowData["ActiveName"]);
                dc.SubmitChanges();
            }
        }

        protected void JqgridLeague1_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var league = dc.Leagues.Single(item => item.LeagueId == Convert.ToInt32(e.RowKey));
                dc.Leagues.DeleteOnSubmit(league);
                dc.SubmitChanges();
            }
        }

        protected void JqgridLeague1_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                dc.Leagues.InsertOnSubmit(new thaitae.lib.League
                {
                    LeagueName = e.RowData["LeagueName"],
                    LeagueType = Convert.ToInt32(e.RowData["LeagueTypeName"]),
                    LeagueDesc = e.RowData["LeagueDesc"],
                    Active = Convert.ToInt32(e.RowData["ActiveName"])
                });
                dc.SubmitChanges();
            }
        }
    }
}