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
            var dc = new ThaitaeDataDataContext().Matches;
            var matchSeasonList = dc.Where(item => item.SeasonId == seasonId).ToList();
            JqgridMatch1.DataSource = matchSeasonList;
            JqgridMatch1.DataBind();
        }

        protected void JqgridAwayTeam_DataRequesting(object sender, JQGridDataRequestEventArgs e)
        {
            var teamAwayMatchList = new ThaitaeDataDataContext().TeamMatches.Where(item => item.MatchId == Convert.ToInt32(e.ParentRowKey) && item.TeamHome == 1).ToList();
            JqgridAwayTeam.DataSource = teamAwayMatchList;
            JqgridAwayTeam.DataBind();
        }

        protected void JqgridHomeTeam_DataRequesting(object sender, JQGridDataRequestEventArgs e)
        {
            var teamHomeMatchList = new ThaitaeDataDataContext().TeamMatches.Where(item => item.MatchId == Convert.ToInt32(e.ParentRowKey) && item.TeamHome == 0).ToList();
            JqgridHomeTeam.DataSource = teamHomeMatchList;
            JqgridHomeTeam.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["seasonid"] == null) return;
            if (Convert.ToInt32(Session["seasonid"]) == 0) return;
            GenerateMatch(Convert.ToInt32(Session["seasonid"]));
        }

        public void GenerateMatch(int seasonId)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var teamSeasonList = dc.TeamSeasons.Join(dc.Teams, teamSeason => teamSeason.TeamId, team => team.TeamId, (teamSeason, team) => new { teamSeason.SeasonId, team.TeamId }).Where(teamSeason => teamSeason.SeasonId == seasonId).ToList();
                for (var i = 0; i < teamSeasonList.Count; i++)
                {
                    for (var j = 0; j < teamSeasonList.Count; j++)
                    {
                        if (teamSeasonList[i].TeamId != teamSeasonList[j].TeamId)
                        {
                            var matchExist = dc.Matches.Count(
                                item => item.SeasonId == seasonId && item.TeamHomeId == teamSeasonList[i].TeamId && item.TeamAwayId == teamSeasonList[j].TeamId);
                            if (matchExist == 0)
                            {
                                var match = new Match
                                {
                                    SeasonId = seasonId,
                                    MatchDate = DateTime.Now,
                                    TeamHomeId = teamSeasonList[i].TeamId,
                                    TeamAwayId = teamSeasonList[j].TeamId
                                };
                                dc.Matches.InsertOnSubmit(match);
                                dc.SubmitChanges();
                                var teamHomeExist =
                                    dc.TeamMatches.Count(
                                        item => item.MatchId == match.MatchId && item.TeamId == match.TeamHomeId);
                                if (teamHomeExist == 0)
                                {
                                    var teamHomeMatch = new TeamMatch
                                                            {
                                                                MatchId = match.MatchId,
                                                                TeamId = match.TeamHomeId,
                                                                TeamHome = 1
                                                            };
                                    dc.TeamMatches.InsertOnSubmit(teamHomeMatch);
                                    dc.SubmitChanges();
                                }
                                var teamAwayExist =
                                    dc.TeamMatches.Count(
                                        item => item.MatchId == match.MatchId && item.TeamId == match.TeamAwayId);
                                if (teamAwayExist == 0)
                                {
                                    var teamAwayMatch = new TeamMatch
                                                            {
                                                                MatchId = match.MatchId,
                                                                TeamId = match.TeamAwayId,
                                                                TeamHome = 0
                                                            };
                                    dc.TeamMatches.InsertOnSubmit(teamAwayMatch);
                                    dc.SubmitChanges();
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void JqgridMatch1_Searching(object sender, JQGridSearchEventArgs e)
        {
            if (e.SearchString == "[All]")
                e.Cancel = true;
        }

        protected void JqgridAwayPlayer_DataRequesting(object sender, JQGridDataRequestEventArgs e)
        {
        }

        protected void JqgridHomePlayer_DataRequesting(object sender, JQGridDataRequestEventArgs e)
        {
        }
    }
}