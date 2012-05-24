using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thaitae.lib;

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

                ddlLeague.SelectedValue = (string)Session["leagueid"];
                ddlSeason.SelectedValue = (string)Session["seasonid"];
                JqgridTeamBinding(Convert.ToInt32(Session["seasonid"]));
                
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

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSeason.SelectedValue == "") return;
            Session["seasonid"] = ddlSeason.SelectedValue;
        }

        protected void JqgridTeam_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var teamSeason = dc.TeamSeasons.Single(item => item.TeamSeasonId == Convert.ToInt32(e.RowKey));
                var team = dc.Teams.Single(item => item.TeamId == teamSeason.TeamId);
                dc.TeamSeasons.DeleteOnSubmit(teamSeason);
                dc.Teams.DeleteOnSubmit(team);
                dc.SubmitChanges();
            }
        }

        protected void JqgridTeam_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var teamSeason = dc.TeamSeasons.Single(item => item.TeamSeasonId == Convert.ToInt32(e.RowKey));
                var team = dc.Teams.Single(item => item.TeamId == teamSeason.TeamId);
                team.TeamName = e.RowData["TeamName"];
                team.TeamDesc = e.RowData["TeamDesc"];
                team.Active = Convert.ToByte(e.RowData["ActiveName"]);
                dc.SubmitChanges();
            }
        }

        protected void JqgridTeam_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
            if (Session["seasonid"] == null) return;
			if (Convert.ToInt32(Session["seasonid"]) == 0) return;
            using (var dc = new ThaitaeDataDataContext())
            {
                var objTeam = new Team
                                  {
                                      TeamName = e.RowData["TeamName"],
                                      TeamDesc = e.RowData["TeamDesc"],
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
            using (var dc = new ThaitaeDataDataContext())
            {
                var teamSeasonList = dc.TeamSeasons.Join(dc.Teams, teamSeason => teamSeason.TeamId, team => team.TeamId, (teamSeason, team) => new { teamSeason.SeasonId, team.TeamId, team.TeamName, team.TeamDesc, team.ActiveName, teamSeason.TeamSeasonId, teamSeason.TeamDrew, teamSeason.TeamGoalAgainst, teamSeason.TeamGoalDiff, teamSeason.TeamGoalFor, teamSeason.TeamLoss, teamSeason.TeamMatchPlayed, teamSeason.TeamPts, teamSeason.TeamWon }).Where(teamSeason => teamSeason.SeasonId == seasonId).ToList();
                JqgridTeam.DataSource = teamSeasonList;
                JqgridTeam.DataBind();
            }
        }
    }
}