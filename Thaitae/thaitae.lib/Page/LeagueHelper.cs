using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib.Page
{
    public static class LeagueHelper
    {
        public static IEnumerable<League> SelectLeagueItems()
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var leagueList = new List<League> { new League() { LeagueId = 0, LeagueName = "Select League" } };
                leagueList.AddRange(dc.Leagues.ToList());
                return leagueList;
            }
        }

        public static IEnumerable<League> SelectLeague()
        {
            IEnumerable<League> leagues = new List<League>();
            var dc = new ThaitaeDataDataContext();
            var leagueCount = dc.Leagues.Count();
            if (leagueCount > 0) leagues = dc.Leagues.Where(item => item.Active == 1).ToList();
            return leagues;
        }

        public static League GetLeague(int leagueId)
        {
            var dc = new ThaitaeDataDataContext();
            var league = dc.Leagues.Single(item => item.LeagueId == leagueId);
            return league;
        }
    }
}