using System;
using System.Linq;
using thaitae.lib;
using System.Collections.Generic;

namespace Thaitae
{
	public partial class index : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			JqgridMatchResultBinding();
			//JqgridSulvoStarBinding();
		}

		public void JqgridMatchResultBinding()
		{
			var dc = new ThaitaeDataDataContext();
			var league = dc.Leagues.Single(items =>items.LeagueId==1);
			var seasons = dc.Seasons.OrderByDescending(item =>item.SeasonId).First(items => items.LeagueId == league.LeagueId);
			var teamSeasonList = dc.TeamSeasons.OrderByDescending(item=>item.TeamPts).OrderByDescending(item=>item.TeamGoalDiff).OrderByDescending(item=>item.TeamGoalFor)
				.Where(teamSeason => teamSeason.SeasonId == seasons.SeasonId).Join(dc.Teams, teamSeason => teamSeason.TeamId, team => team.TeamId, (teamSeason, team) =>
				new { teamSeason.TeamSeasonId, team.TeamName, teamSeason.TeamMatchPlayed, teamSeason.TeamDrew, teamSeason.TeamGoalAgainst, teamSeason.TeamGoalFor, teamSeason.TeamLoss, teamSeason.TeamPts, teamSeason.TeamWon }).ToList();
			JQGridMatchResult.DataSource = teamSeasonList;
			JQGridMatchResult.DataBind();
		}

		public void JqgridSulvoStarBinding()
		{
			using (var dc = new ThaitaeDataDataContext())
			{
				var league = dc.Leagues.Single(items => items.LeagueId == 1);
				var season = dc.Seasons.OrderByDescending(item => item.SeasonId).First(items => items.LeagueId == league.LeagueId);
				var teamSeasonList = dc.TeamSeasons.Where(teamSeason => teamSeason.SeasonId == season.SeasonId).ToList();
				JQGridMatchResult.DataSource = teamSeasonList;
				JQGridMatchResult.DataBind();
			}
		}

		public void JqgridMatchBinding()
		{
			using (var dc = new ThaitaeDataDataContext())
			{
				var league = dc.Leagues.Single(items => items.LeagueId == 1);
				var season = dc.Seasons.OrderByDescending(item => item.SeasonId).First(items => items.LeagueId == league.LeagueId);
				var teamSeasonList = dc.TeamSeasons.Where(teamSeason => teamSeason.SeasonId == season.SeasonId).ToList();
				JQGridMatchResult.DataSource = teamSeasonList;
				JQGridMatchResult.DataBind();
			}
		}
	}
}