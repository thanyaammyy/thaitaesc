using System;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using thaitae.lib;
using Trirand.Web.UI.WebControls;

namespace Thaitae.Backend
{
    public partial class MatchManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["seasonid"] != null && Session["leagueid"] != null)
                {
                    ddlLeague.SelectedValue = (string)Session["leagueid"];
                    ddlSeason.SelectedValue = (string)Session["seasonid"];
                    JqgridMatchBinding(Convert.ToInt32(Session["seasonid"]));
                }
            }
        }

        protected void ddlLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLeague.SelectedValue == "") return;
            Session["leagueid"] = ddlLeague.SelectedValue;
            Session.Remove("seasonid");
        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSeason.SelectedValue == "") return;
            Session["seasonid"] = ddlSeason.SelectedValue;
        }

        protected void JqgridMatch1_RowAdding(object sender, JQGridRowAddEventArgs e)
        {
            if (Session["seasonid"] == null || (int)Session["seasonid"] == 0) return;
            //if (e.RowData[""])
            using (var dc = new ThaitaeDataDataContext())
            {
            }
        }

        protected void JqgridMatch1_RowDeleting(object sender, JQGridRowDeleteEventArgs e)
        {
        }

        protected void JqgridMatch1_RowEditing(object sender, JQGridRowEditEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var match = dc.Matches.Single(item => item.MatchId == Convert.ToInt32(e.RowKey));
                match.MatchDate = Convert.ToDateTime(e.RowData["MatchDate"]);
                dc.SubmitChanges();
            }
        }

        private void JqgridMatchBinding(int seasonId)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var matchSeasonList = dc.Matches.Where(item => item.SeasonId == seasonId).ToList();
                JqgridMatch1.DataSource = matchSeasonList;
                JqgridMatch1.DataBind();
            }
        }
    }
}