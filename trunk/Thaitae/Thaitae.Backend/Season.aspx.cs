using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thaitae.lib;

namespace Thaitae.Backend
{
    public partial class Season : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				if (Session["leagueid"] == null) return;
				if (Convert.ToInt32(Session["leagueid"]) == 0) return;
                ddlLeague.SelectedValue = (string)Session["leagueid"];
                JqgridSeasonBinding(Convert.ToInt32(Session["leagueid"]));
                
            }
        }

        protected void ddlLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DropDownList)sender).SelectedValue != "")
            {
                Session["leagueid"] = ddlLeague.SelectedValue;
                Session.Remove("seasonid");
            }
        }

        protected void JqgridSeason_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
			if (Session["leagueid"] == null) return;
			if (Convert.ToInt32(Session["leagueid"]) == 0)return;
            using (var dc = new ThaitaeDataDataContext())
            {
                dc.Seasons.InsertOnSubmit(new thaitae.lib.Season
                {
                    LeagueId = Convert.ToInt32(Session["leagueid"]),
                    SeasonName = e.RowData["SeasonName"],
                    SeasonDesc = e.RowData["SeasonDesc"]
                });
                dc.SubmitChanges();
            }
        }

        protected void JqgridSeason_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var season = dc.Seasons.Single(item => item.SeasonId == Convert.ToInt32(e.RowKey));
                dc.Seasons.DeleteOnSubmit(season);
                dc.SubmitChanges();
            }
        }

        protected void JqgridSeason_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var season = dc.Seasons.Single(item => item.SeasonId == Convert.ToInt32(e.RowKey));
                season.SeasonName = e.RowData["SeasonName"];
                season.SeasonDesc = e.RowData["SeasonDesc"];
                dc.SubmitChanges();
            }
        }

        private void JqgridSeasonBinding(int leagueId)
        {
            var dc = new ThaitaeDataDataContext().Seasons;
            var seasonList = dc.Where(item => item.LeagueId == leagueId).ToList();
            JqgridSeason.DataSource = seasonList;
            JqgridSeason.DataBind();
        }
    }
}