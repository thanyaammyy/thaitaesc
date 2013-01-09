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
    public partial class CustomMatchManagement : System.Web.UI.Page
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

        private void JqgridMatchBinding(int seasonId)
        {
            var dc = ThaitaeDataDataContext.Create().Matches;
            var matchSeasonList = dc.Where(item => item.SeasonId == seasonId).ToList();
            JqgridMatch1.DataSource = matchSeasonList;
            JqgridMatch1.DataBind();
        }

        protected void JqgridMatch1_RowDeleting(object sender, JQGridRowDeleteEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var matchHome = dc.Matches.Single(item => item.MatchId == Convert.ToInt32(e.RowKey));
                var matchAway =
                    dc.Matches.Single(
                        item => item.TeamHomeId == matchHome.TeamAwayId && item.TeamAwayId == matchHome.TeamHomeId && item.SeasonId == Convert.ToInt32(Session["seasonid"]));
                var faMatch = dc.TeamMatches.Where(item => item.MatchId == Convert.ToInt32(e.RowKey)).ToList();
                dc.TeamMatches.DeleteAllOnSubmit(faMatch);
                dc.SubmitChanges();
                dc.Matches.DeleteOnSubmit(matchHome);
                dc.Matches.DeleteOnSubmit(matchAway);
                dc.SubmitChanges();
            }
        }

        protected void JqgridMatch1_RowAdding(object sender, JQGridRowAddEventArgs e)
        {
            var homeId = String.IsNullOrEmpty(e.RowData["TeamHomeIdNameExtend"])
                                ? 0
                                : Convert.ToInt32(e.RowData["TeamHomeIdNameExtend"]);
            var awayId = String.IsNullOrEmpty(e.RowData["TeamAwayIdNameExtend"])
                                ? 0
                                : Convert.ToInt32(e.RowData["TeamAwayIdNameExtend"]);
            var date = String.IsNullOrEmpty(e.RowData["MatchDate"])
                           ? DateTime.Now
                           : Convert.ToDateTime(e.RowData["MatchDate"]);
            if (homeId == 0 || awayId == 0 || Convert.ToInt32(Session["seasonid"]) == 0) return;
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var match1 = new Match
                {
                    MatchDate = date,
                    SeasonId = Convert.ToInt32(Session["seasonid"]),
                    TeamHomeId = homeId,
                    TeamAwayId = awayId
                };
                var match2 = new Match
                {
                    MatchDate = date,
                    SeasonId = Convert.ToInt32(Session["seasonid"]),
                    TeamHomeId = awayId,
                    TeamAwayId = homeId
                };
                dc.Matches.InsertOnSubmit(match2);
                dc.Matches.InsertOnSubmit(match1);
                dc.SubmitChanges();
                var teamHome1 = new TeamMatch
                {
                    TeamId = homeId,
                    TeamGoalFor = 0,
                    TeamGoalPenalty = 0,
                    TeamHome = 1,
                    SeasonId = Convert.ToInt32(Session["seasonid"]),
                    MatchId = match1.MatchId
                };

                var teamAway1 = new TeamMatch
                {
                    TeamId = awayId,
                    TeamGoalFor = 0,
                    TeamGoalPenalty = 0,
                    TeamHome = 0,
                    SeasonId = Convert.ToInt32(Session["seasonid"]),
                    MatchId = match1.MatchId
                };

                
                
                var teamHome2 = new TeamMatch
                {
                    TeamId = awayId,
                    TeamGoalFor = 0,
                    TeamGoalPenalty = 0,
                    TeamHome = 1,
                    SeasonId = Convert.ToInt32(Session["seasonid"]),
                    MatchId = match2.MatchId
                };

                var teamAway2 = new TeamMatch
                {
                    TeamId = homeId,
                    TeamGoalFor = 0,
                    TeamGoalPenalty = 0,
                    TeamHome = 0,
                    SeasonId = Convert.ToInt32(Session["seasonid"]),
                    MatchId = match2.MatchId
                };
                dc.TeamMatches.InsertOnSubmit(teamHome1);
                dc.TeamMatches.InsertOnSubmit(teamHome2);
                dc.TeamMatches.InsertOnSubmit(teamAway1);
                dc.TeamMatches.InsertOnSubmit(teamAway2);
                dc.SubmitChanges();
            }
     
        }

        protected void JqgridMatch1_RowEditing(object sender, JQGridRowEditEventArgs e)
        {
            var homeScore = String.IsNullOrEmpty(e.RowData["TeamHomeScore"])
                                ? 0
                                : Convert.ToInt32(e.RowData["TeamHomeScore"]);
            var homePScore = String.IsNullOrEmpty(e.RowData["TeamHomePScore"])
                                ? 0
                                : Convert.ToInt32(e.RowData["TeamHomePScore"]);
            var awayScore = String.IsNullOrEmpty(e.RowData["TeamAwayScore"])
                                ? 0
                                : Convert.ToInt32(e.RowData["TeamAwayScore"]);
            var awayPScore = String.IsNullOrEmpty(e.RowData["TeamAwayPScore"])
                                ? 0
                                : Convert.ToInt32(e.RowData["TeamAwayPScore"]);
            var date = String.IsNullOrEmpty(e.RowData["MatchDate"])
                           ? DateTime.Now
                           : Convert.ToDateTime(e.RowData["MatchDate"]);
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var match = dc.Matches.Single(item => item.MatchId == Convert.ToInt32(e.RowKey));
                var teamHome =
                    dc.TeamMatches.Single(item => item.MatchId == Convert.ToInt32(e.RowKey) && item.TeamHome == 1);
                var teamAway =
                    dc.TeamMatches.Single(item => item.MatchId == Convert.ToInt32(e.RowKey) && item.TeamHome == 0);
                match.MatchDate = date;
                teamHome.TeamGoalFor = homeScore;
                teamHome.TeamGoalPenalty = homePScore;
                teamAway.TeamGoalFor = awayScore;
                teamAway.TeamGoalPenalty = awayPScore;
                if (teamHome.TeamGoalFor == -1 && teamHome.TeamGoalPenalty == -1 && teamAway.TeamGoalFor == -1 &&
                    teamAway.TeamGoalPenalty == -1)
                {
                    teamHome.TeamGoalFor = 0;
                    teamHome.TeamGoalPenalty = 0;
                    teamAway.TeamGoalFor = 0;
                    teamAway.TeamGoalPenalty = 0;
                    teamHome.TeamEdited = 0;
                    teamHome.TeamStatus = 0;
                    teamAway.TeamEdited = 0;
                    teamAway.TeamStatus = 0;
                }
                if (teamHome.TeamGoalFor == teamAway.TeamGoalFor)
                {
                    if (teamHome.TeamGoalFor + teamHome.TeamGoalPenalty >
                        teamAway.TeamGoalFor + teamAway.TeamGoalPenalty)
                    {
                        teamHome.TeamEdited = 1;
                        teamHome.TeamStatus = 1;
                        teamAway.TeamEdited = 1;
                        teamAway.TeamStatus = 3;
                    }
                    else if (teamHome.TeamGoalFor + teamHome.TeamGoalPenalty <
                             teamAway.TeamGoalFor + teamAway.TeamGoalPenalty)
                    {
                        teamHome.TeamEdited = 1;
                        teamHome.TeamStatus = 3;
                        teamAway.TeamEdited = 1;
                        teamAway.TeamStatus = 1;
                    }
                    else
                    {
                        teamHome.TeamEdited = 1;
                        teamHome.TeamStatus = 2;
                        teamAway.TeamEdited = 1;
                        teamAway.TeamStatus = 2;
                    }
                }
                else if (teamHome.TeamGoalFor > teamAway.TeamGoalFor)
                {
                    teamHome.TeamEdited = 1;
                    teamHome.TeamStatus = 1;
                    teamAway.TeamEdited = 1;
                    teamAway.TeamStatus = 3;
                }
                else if (teamHome.TeamGoalFor < teamAway.TeamGoalFor)
                {
                    teamHome.TeamEdited = 1;
                    teamHome.TeamStatus = 3;
                    teamAway.TeamEdited = 1;
                    teamAway.TeamStatus = 1;
                }
                dc.SubmitChanges();
            }
        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSeason.SelectedValue == "") return;
            Session["seasonid"] = ddlSeason.SelectedValue;
        }

        protected void ddlLeague_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLeague.SelectedValue == "") return;
            Session["leagueid"] = ddlLeague.SelectedValue;
            Session.Remove("seasonid");
        }
    }
}