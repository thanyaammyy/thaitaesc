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

        public static IEnumerable<object> ListCustomTeamItems(int seasonId)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var teamSeasonList = dc.TeamSeasons.Join(dc.Teams, teamSeason => teamSeason.TeamId, team => team.TeamId, (teamSeason, team) => new { teamSeason.SeasonId, team.TeamId, team.TeamName, team.TeamDesc, team.ActiveName, teamSeason.TeamSeasonId, teamSeason.TeamDrew, teamSeason.TeamGoalAgainst, teamSeason.TeamGoalDiff, teamSeason.TeamGoalFor, teamSeason.TeamLoss, teamSeason.TeamMatchPlayed, teamSeason.TeamPts, teamSeason.TeamWon }).Where(teamSeason => teamSeason.SeasonId == seasonId).ToList();
                var teamList = new List<Team> { new Team{ TeamId = 0, TeamName = "[All]" } };
                foreach (var team in teamSeasonList)
                {
                    if (!TeamInMatch(team.TeamId, team.SeasonId))
                    {
                        teamList.Add(new Team { TeamId = team.TeamId, TeamName = team.TeamName });
                    }
                }
                
                return teamList;
            }
        }

        public static bool TeamInMatch(int teamId, int seasonId)
        {
            var inMatch = false;
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var matchCount = dc.TeamMatches.Count(item => item.SeasonId == seasonId && item.TeamId == teamId);
                var winCount =
                    dc.TeamMatches.Count(
                        item => item.SeasonId == seasonId && item.TeamId == teamId && item.TeamStatus == 1);
                inMatch = matchCount/winCount + 1 == 2;
            }
            return inMatch;
        }
    }
}