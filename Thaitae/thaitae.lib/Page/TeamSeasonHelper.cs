using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib.Page
{
	public static class TeamSeasonHelper
	{
		public static IEnumerable<object> MatchResult(int leagueId)
		{
			var dc = new ThaitaeDataDataContext();
			var league = dc.Leagues.Single(items => items.LeagueId == leagueId);
			var seasons = dc.Seasons.OrderByDescending(item => item.SeasonId).First(items => items.LeagueId == league.LeagueId);
			var teamSeasonList = dc.TeamSeasons.OrderByDescending(item => item.TeamPts).OrderByDescending(item => item.TeamGoalDiff).OrderByDescending(item => item.TeamGoalFor)
				.Where(teamSeason => teamSeason.SeasonId == seasons.SeasonId).Join(dc.Teams, teamSeason => teamSeason.TeamId, team => team.TeamId, (teamSeason, team) =>
				new { teamSeason.TeamSeasonId, team.TeamName, teamSeason.TeamMatchPlayed, teamSeason.TeamDrew, teamSeason.TeamGoalAgainst, teamSeason.TeamGoalFor, teamSeason.TeamLoss, teamSeason.TeamPts, teamSeason.TeamWon }).ToList();
			return teamSeasonList;
		}
	}
}
