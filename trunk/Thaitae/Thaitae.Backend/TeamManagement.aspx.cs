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
			if (Session["seasonid"] == null) return;
			JqgridTeamBinding(Convert.ToInt32(Session["seasonid"]));
        }

		protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(ddlSeason.SelectedValue=="")return;
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
				team.Active = Convert.ToInt32(e.RowData["ActiveName"]);
				dc.SubmitChanges();
			}
		}

		protected void JqgridTeam_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
		{
			if (Session["seasonid"]==null)return;
			using (var dc = new ThaitaeDataDataContext())
			{
				dc.Teams.InsertOnSubmit(new thaitae.lib.Team
				{
					TeamName = e.RowData["TeamName"],
					TeamDesc = e.RowData["TeamDesc"],
					Active = Convert.ToInt32(e.RowData["ActiveName"])
				});
				dc.TeamSeasons.InsertOnSubmit(new thaitae.lib.TeamSeason
				{
					SeasonId = Convert.ToInt32(Session["seasonid"])
				});
				dc.SubmitChanges();
			}

		}

		private void JqgridTeamBinding(int seasonId)
		{
			using (var dc = new ThaitaeDataDataContext())
			{
				var teamSeasonList = dc.TeamSeasons.Join(dc.Teams, teamSeason => teamSeason.TeamId, team => team.TeamId, (teamSeason, team) => new { teamSeason.SeasonId, team.TeamId, team.TeamName, team.TeamDesc, team.ActiveName, teamSeason.TeamSeasonId }).Where(teamSeason => teamSeason.SeasonId == seasonId).ToList();
				JqgridTeam.DataSource = teamSeasonList;
				JqgridTeam.DataBind();

			}
		}
    }
}