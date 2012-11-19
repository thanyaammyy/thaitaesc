using System.Collections.Generic;
using System.Linq;

namespace thaitae.lib.Page
{
    public static class TeamSeasonHelper
    {
        public static IEnumerable<object> MatchResult(int leagueId)
        {
            var dc = ThaitaeDataDataContext.Create();
            IEnumerable<object> teamSeasonList = null;
            var league = dc.Leagues.Single(items => items.LeagueId == leagueId);
            var leagueName = league.LeagueName;
            var seasoncount = dc.Seasons.Count(items => items.LeagueId == league.LeagueId);
            if (seasoncount > 0)
            {
                var seasons = dc.Seasons.OrderByDescending(item => item.SeasonId).First(items => items.LeagueId == league.LeagueId);
                teamSeasonList = dc.TeamSeasons.OrderByDescending(item => item.TeamPts).ThenByDescending(item => item.TeamGoalDiff).ThenByDescending(item => item.TeamGoalFor)
                    .Where(teamSeason => teamSeason.SeasonId == seasons.SeasonId).Join(dc.Teams, teamSeason => teamSeason.TeamId, team => team.TeamId, (teamSeason, team) =>
                    new { teamSeason.TeamSeasonId, team.TeamName, teamSeason.TeamMatchPlayed, teamSeason.TeamDrew, teamSeason.TeamGoalAgainst, teamSeason.TeamGoalFor, teamSeason.TeamLoss, teamSeason.TeamPts, teamSeason.TeamWon, teamSeason.TeamGoalDiff, leagueName }).ToList();
            }

            return teamSeasonList;
        }

        public static IEnumerable<Player> SulvoStar(int leagueId)
        {
            var dc = ThaitaeDataDataContext.Create();
            var sulvoList = new List<Player>();
            var league = dc.Leagues.Single(items => items.LeagueId == leagueId);
            var seasoncount = dc.Seasons.Count(items => items.LeagueId == league.LeagueId);
            if (seasoncount > 0)
            {
                var seasons = dc.Seasons.OrderByDescending(item => item.SeasonId).First(items => items.LeagueId == league.LeagueId);
                var teamList = dc.TeamSeasons.Where(item => item.SeasonId == seasons.SeasonId).ToList();
                foreach (
                    var sulvos in
                        teamList.Select(
                            t => dc.Players.Where(item => item.SeasonId == seasons.SeasonId && item.TeamId == t.TeamId && item.PlayerNumber != -1).ToList()))
                {
                    sulvoList.AddRange(sulvos);
                }
            }
            return sulvoList.OrderByDescending(item => item.PlayerGoal);
        }

        public static List<TeamSeason> GetChampionsLeagueFinalTeamList(int seasonId)
        {
            List<TeamSeason> team;
            using (var dc = ThaitaeDataDataContext.Create())
            {
                team = dc.TeamSeasons.Where(item => item.SeasonId == seasonId)
                    .OrderByDescending(item => item.TeamPts).ThenByDescending(item => item.TeamGoalDiff).ThenByDescending(item => item.TeamGoalFor)
                    .Take(2).ToList();
            }
            return team;
        }

        public static List<TeamSeason> GetEuropaLeagueFinalTeamList(int seasonId)
        {
            List<TeamSeason> team;
            using (var dc = ThaitaeDataDataContext.Create())
            {
                team = dc.TeamSeasons.Where(item => item.SeasonId == seasonId)
                    .OrderBy(item => item.TeamPts).ThenBy(item => item.TeamGoalDiff).ThenBy(item => item.TeamGoalFor)
                    .Take(2).ToList();
            }
            return team;
        }

        public static TeamSeason GetChampionsLeagueFinalTeamFromGroupSeasonId(int groupSeasonId, int teamId)
        {
            TeamSeason team;
            using (var dc = ThaitaeDataDataContext.Create())
            {
                team =
                    dc.TeamSeasons.SingleOrDefault(item => item.GroupSeasonId == groupSeasonId && item.TeamId == teamId);
            }
            return team;
        }
    }
}