using System;
using System.Linq;
using thaitae.lib;
using thaitae.lib.Page;

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
            if (ddlLeague.SelectedValue != "")
            {
                Session["leagueid"] = ddlLeague.SelectedValue;
                Session.Remove("seasonid");
            }
        }

        protected void JqgridSeason_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
            if (Session["leagueid"] == null) return;
            if (Convert.ToInt32(Session["leagueid"]) == 0) return;
            var league = LeagueHelper.GetLeague(Convert.ToInt32(Session["leagueid"]));
            using (var dc = ThaitaeDataDataContext.Create())
            {
                if (league.LeagueType == 1)
                {
                    var season = new thaitae.lib.Season
                                     {
                                         LeagueId = Convert.ToInt32(Session["leagueid"]),
                                         SeasonName = e.RowData["SeasonName"],
                                         SeasonDesc = e.RowData["SeasonDesc"]
                                     };
                    dc.Seasons.InsertOnSubmit(season);
                    dc.SubmitChanges();
                    var leagueList = LeagueHelper.GetChampionsLeagueGroupList();
                    foreach (var championGroup in leagueList)
                    {
                        var seasonGroup = new thaitae.lib.Season
                        {
                            LeagueId = championGroup.LeagueId,
                            SeasonName = e.RowData["SeasonName"],
                            SeasonDesc = e.RowData["SeasonDesc"],
                            ChampionLeagueSeasonId = season.SeasonId
                        };
                        dc.Seasons.InsertOnSubmit(seasonGroup);
                    }
                    dc.SubmitChanges();
                }
                else
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
        }

        protected void JqgridSeason_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var season = dc.Seasons.Single(item => item.SeasonId == Convert.ToInt32(e.RowKey));
                var seasonGroup = dc.Seasons.Where(item => item.ChampionLeagueSeasonId == Convert.ToInt32(e.RowKey));
                dc.Seasons.DeleteOnSubmit(season);
                dc.Seasons.DeleteAllOnSubmit(seasonGroup);
                dc.SubmitChanges();
            }
        }

        protected void JqgridSeason_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var season = dc.Seasons.Single(item => item.SeasonId == Convert.ToInt32(e.RowKey));
                var seasonGroupList = dc.Seasons.Where(item => item.ChampionLeagueSeasonId == Convert.ToInt32(e.RowKey));
                season.SeasonName = e.RowData["SeasonName"];
                season.SeasonDesc = e.RowData["SeasonDesc"];
                foreach (var seasonGroup in seasonGroupList)
                {
                    seasonGroup.SeasonName = e.RowData["SeasonName"];
                    seasonGroup.SeasonDesc = e.RowData["SeasonDesc"];
                }
                dc.SubmitChanges();
            }
        }

        private void JqgridSeasonBinding(int leagueId)
        {
            var dc = ThaitaeDataDataContext.Create().Seasons;
            var seasonList = dc.Where(item => item.LeagueId == leagueId).ToList();
            JqgridSeason.DataSource = seasonList;
            JqgridSeason.DataBind();
        }
    }
}