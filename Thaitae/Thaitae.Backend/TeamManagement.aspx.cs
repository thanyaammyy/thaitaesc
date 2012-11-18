using System;
using System.Linq;
using System.Web.UI.WebControls;
using thaitae.lib;
using thaitae.lib.Helper;
using thaitae.lib.Page;

namespace Thaitae.Backend
{
    public partial class TeamManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["seasonid"] == null) return;
                if (Convert.ToInt32(Session["seasonid"]) == 0) return;

                if (Session["leagueid"] == null) return;
                if (Convert.ToInt32(Session["leagueid"]) == 0) return;

                ddlLeague.SelectedValue = Convert.ToString(Session["leagueid"]);
                ddlSeason.SelectedValue = Convert.ToString(Session["seasonid"]);
                var leagueId = Convert.ToInt32(Session["leagueid"]);
                var league = LeagueHelper.GetLeague(leagueId);
                GenTeam.Visible = league.LeagueType == 1;
                JqgridTeamBinding(Convert.ToInt32(Session["seasonid"]));
            }
        }

        protected void ddlLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLeague.SelectedValue == "") return;

            Session["leagueid"] = ddlLeague.SelectedValue;
            Session.Remove("seasonid");
            if (ddlLeague.SelectedValue == "0")
            {
                GenTeam.Visible = false;
                return;
            }
            var leagueId = Convert.ToInt32(Session["leagueid"]);
            var league = LeagueHelper.GetLeague(leagueId);
            GenTeam.Visible = league.LeagueType == 1;
        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSeason.SelectedValue == "") return;
            Session["seasonid"] = ddlSeason.SelectedValue;
        }

        protected void JqgridTeam_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var teamSeason = dc.TeamSeasons.Single(item => item.TeamSeasonId == Convert.ToInt32(e.RowKey));
                var team = dc.Teams.Single(item => item.TeamId == teamSeason.TeamId);
                dc.TeamSeasons.DeleteOnSubmit(teamSeason);
                if (teamSeason.GroupSeasonId == null)
                {
                    dc.Teams.DeleteOnSubmit(team);
                }
                dc.SubmitChanges();
            }
        }

        protected void JqgridTeam_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var teamSeason = dc.TeamSeasons.Single(item => item.TeamSeasonId == Convert.ToInt32(e.RowKey));
                var team = dc.Teams.Single(item => item.TeamId == teamSeason.TeamId);
                team.TeamName = e.RowData["TeamName"].Trim();
                team.TeamDesc = e.RowData["TeamDesc"].Trim();
                team.Active = Convert.ToByte(e.RowData["ActiveName"]);
                dc.SubmitChanges();
            }
        }

        protected void JqgridTeam_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
            if (Session["seasonid"] == null) return;
            if (Convert.ToInt32(Session["seasonid"]) == 0) return;
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var objTeam = new Team
                                  {
                                      TeamName = e.RowData["TeamName"].Trim(),
                                      TeamDesc = e.RowData["TeamDesc"].Trim(),
                                      Active = Convert.ToByte(e.RowData["ActiveName"]),
                                      Guid = Guid.NewGuid()
                                  };
                dc.Teams.InsertOnSubmit(objTeam);
                dc.SubmitChanges();
                dc.TeamSeasons.InsertOnSubmit(new TeamSeason
                {
                    SeasonId = Convert.ToInt32(Session["seasonid"]),
                    TeamId = objTeam.TeamId
                });
                dc.SubmitChanges();
            }
        }

        private void JqgridTeamBinding(int seasonId)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var teamSeasonList = dc.TeamSeasons.Join(dc.Teams, teamSeason => teamSeason.TeamId, team => team.TeamId, (teamSeason, team) => new { teamSeason.SeasonId, team.TeamId, team.TeamName, team.TeamDesc, team.ActiveName, teamSeason.TeamSeasonId, teamSeason.TeamDrew, teamSeason.TeamGoalAgainst, teamSeason.TeamGoalDiff, teamSeason.TeamGoalFor, teamSeason.TeamLoss, teamSeason.TeamMatchPlayed, teamSeason.TeamPts, teamSeason.TeamWon, teamSeason.TeamYellowCard, teamSeason.TeamRedCard }).Where(teamSeason => teamSeason.SeasonId == seasonId)
                    .OrderByDescending(item => item.TeamPts).ThenByDescending(item => item.TeamGoalDiff).ThenByDescending(item => item.TeamGoalFor).ToList();
                JqgridTeam.DataSource = teamSeasonList;
                JqgridTeam.DataBind();
            }
        }

        protected void GenTeam_Click(object sender, EventArgs e)
        {
            if (Session["seasonid"] == null) return;
            if (Convert.ToInt32(Session["seasonid"]) == 0) return;

            var seasonList = SeasonHelper.GetChampionLeagueGroupSeasonList(Convert.ToInt32(Session["seasonid"]));
            foreach (var season in seasonList)
            {
                var isFinished = SeasonHelper.CheckGroupSeasonIsFinnish(season.SeasonId);
                if (!isFinished)
                {
                    JavaScriptHelper.Alert("ยังใส่ผล Champion League ไม่ครบทุก Group");
                    return;
                }
            }

            foreach (var season in seasonList)
            {
                var teamSeasonList = TeamSeasonHelper.GetChampionsLeagueFinalTeamList(season.SeasonId);
                var i = 1;
                foreach (var teamSeason in teamSeasonList)
                {
                    using (var dc = ThaitaeDataDataContext.Create())
                    {
                        var teamFinalSelected =
                            TeamSeasonHelper.GetChampionsLeagueFinalTeamFromGroupSeasonId(teamSeason.SeasonId,
                                                                                          teamSeason.TeamId);
                        if (teamFinalSelected == null)
                        {
                            var teamFinal = new TeamSeason
                            {
                                TeamDrew = 0,
                                TeamGoalAgainst = 0,
                                TeamGoalDiff = 0,
                                TeamGoalFor = 0,
                                TeamLoss = 0,
                                TeamMatchPlayed = 0,
                                TeamPts = 0,
                                TeamRedCard = 0,
                                TeamWon = 0,
                                TeamYellowCard = 0,
                                GroupSeasonId = 0,
                                GroupSeasonOrder = i++,
                                TeamId = teamSeason.TeamId,
                                SeasonId = Convert.ToInt32(Session["seasonid"])
                            };
                            dc.TeamSeasons.InsertOnSubmit(teamFinal);
                        }
                        else
                        {
                            teamFinalSelected.GroupSeasonOrder = i++;
                        }

                        dc.SubmitChanges();
                    }
                }
            }
        }
    }
}