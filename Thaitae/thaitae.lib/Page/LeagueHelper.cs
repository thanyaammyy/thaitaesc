using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace thaitae.lib.Page
{
    public static class LeagueHelper
    {
        public static IEnumerable<League> SelectLeagueItems()
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var leagueList = new List<League> { new League() { LeagueId = 0, LeagueName = "Select League" } };
                leagueList.AddRange(dc.Leagues.ToList());
                return leagueList;
            }
        }

        public static IEnumerable<League> SelectNormalLeagueItems()
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var leagueList = new List<League> { new League() { LeagueId = 0, LeagueName = "Select League" } };
                leagueList.AddRange(dc.Leagues.Where(item => item.LeagueType == 4 || item.LeagueType == 8).ToList());
                return leagueList;
            }
        }

        public static IEnumerable<League> SelectCustomLeagueItems()
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var leagueList = new List<League> { new League() { LeagueId = 0, LeagueName = "Select League" } };
                leagueList.AddRange(dc.Leagues.Where(item => item.LeagueType == 1 || item.LeagueType == 2).ToList());
                return leagueList;
            }
        }

        public static IEnumerable<League> SelectLeagueItemsWithGroupingChampionsLeague()
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var leagueList = new List<League> { new League() { LeagueId = 0, LeagueName = "Select League" } };
                leagueList.AddRange(dc.Leagues.Where(item => item.LeagueType == 4).ToList());
                var championLeague = dc.Leagues.Single(item => item.LeagueType == 1);
                championLeague.LeagueName = "Champions League";
                leagueList.Add(championLeague);
                return leagueList;
            }
        }

        public static IEnumerable<League> SelectLeague()
        {
            IEnumerable<League> leagues = new List<League>();
            var dc = ThaitaeDataDataContext.Create();
            var leagueCount = dc.Leagues.Count();
            if (leagueCount > 0) leagues = dc.Leagues.Where(item => item.LeagueType != 1 && item.LeagueType != 2 && item.Active == 1).ToList();
            foreach (var league in leagues)
            {
                league.Picture = ConfigurationManager.AppSettings["BackendUrl"] + league.Picture;
            }
            return leagues;
        }

        public static IEnumerable<League> SelectNormalLeague()
        {
            IEnumerable<League> leagues = new List<League>();
            var dc = ThaitaeDataDataContext.Create();
            var leagueCount = dc.Leagues.Count();
            if (leagueCount > 0) leagues = dc.Leagues.Where(item => item.LeagueType == 4).ToList();
            return leagues;
        }

        public static IEnumerable<League> SelectChampionsLeague()
        {
            IEnumerable<League> leagues = new List<League>();
            var dc = ThaitaeDataDataContext.Create();
            var leagueCount = dc.Leagues.Count();
            if (leagueCount > 0) leagues = dc.Leagues.Where(item => item.LeagueType == 1 || item.LeagueType == 2 || item.LeagueType == 8).OrderByDescending(item => item.LeagueType).ThenBy(item => item.LeagueId).ToList();
            foreach (var league in leagues)
            {
                league.Picture = ConfigurationManager.AppSettings["BackendUrl"] + league.Picture;
            }
            return leagues;
        }

        public static League GetLeague(int leagueId)
        {
            var dc = ThaitaeDataDataContext.Create();
            var league = dc.Leagues.Single(item => item.LeagueId == leagueId);
            league.Picture = ConfigurationManager.AppSettings["BackendUrl"] + league.Picture;
            return league;
        }

        public static List<League> GetChampionsLeagueGroupList()
        {
            List<League> leagueList;
            using (var dc = ThaitaeDataDataContext.Create())
            {
                leagueList = dc.Leagues.Where(item => (item.LeagueType == 8 || item.LeagueType == 2) && item.Active == 1).ToList();
            }
            return leagueList;
        }
    }
}