using System.Collections.Generic;
using System.Linq;

namespace thaitae.lib.Page
{
    public static class TeamHelper
    {
        public static IEnumerable<object> ListTeamItems(int seasonId)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var teamSeasonList = dc.TeamSeasons.Join(dc.Teams, teamSeason => teamSeason.TeamId, team => team.TeamId, (teamSeason, team) => new { teamSeason.SeasonId, team.TeamId, team.TeamName, team.TeamDesc, team.ActiveName, teamSeason.TeamSeasonId, teamSeason.TeamDrew, teamSeason.TeamGoalAgainst, teamSeason.TeamGoalDiff, teamSeason.TeamGoalFor, teamSeason.TeamLoss, teamSeason.TeamMatchPlayed, teamSeason.TeamPts, teamSeason.TeamWon }).Where(teamSeason => teamSeason.SeasonId == seasonId).ToList();
                var teamList = new List<object> { new { TeamId = 0, TeamName = "[All]" } };
                teamList.AddRange(teamSeasonList);
                return teamList;
            }
        }
    }
}