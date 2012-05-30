using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace thaitae.lib.Page
{
    public static class MatchHelper
    {
        public static IEnumerable<Match> SelectItems()
        {
            var dc = new ThaitaeDataDataContext();
            return dc.Matches;
        }

        public static void Insert(Match objMatch)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                dc.Matches.InsertOnSubmit(objMatch);
                try
                {
                    dc.SubmitChanges();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        throw;
                    }
                }
            }
        }

        public static void Update(Match objMatch)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                Match linqMatch = (from dataItem in dc.Matches
                                   where dataItem.MatchId == objMatch.MatchId
                                   select dataItem).First();
                linqMatch.MatchDate = Convert.ToDateTime(objMatch.SeasonId);
                linqMatch.MatchDate = objMatch.MatchDate;
                try
                {
                    dc.SubmitChanges();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        throw;
                    }
                }
            }
        }

        public static void Delete(Match objMatch)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                dc.Matches.DeleteOnSubmit(objMatch);
                dc.SubmitChanges();
            }
        }

        public static IEnumerable<Match> MatcheShowing(int leagueId)
        {
            IEnumerable<Match> matches = null;
            var matchFilteredList = new List<Match>();
            var dc = new ThaitaeDataDataContext();
            var league = dc.Leagues.Single(items => items.LeagueId == leagueId);
            var seasoncount = dc.Seasons.Count(items => items.LeagueId == league.LeagueId);
            if (seasoncount > 0)
            {
                var seasons = dc.Seasons.OrderByDescending(item => item.SeasonId).First(items => items.LeagueId == league.LeagueId);
                matches = dc.Matches.OrderByDescending(item => item.MatchDate).Where(item => item.SeasonId == seasons.SeasonId && item.MatchDate < DateTime.Now.AddDays(1)).ToList();
                foreach (var match in matches)
                {
                    var checkNotEdited = false;
                    var teamMatchList = dc.TeamMatches.Where(item => item.MatchId == match.MatchId).ToList();
                    foreach (var teamMatch in teamMatchList)
                    {
                        if (teamMatch.TeamEdited == 0)
                        {
                            checkNotEdited = true;
                        }
                    }
                    if (checkNotEdited == false)
                    {
                        matchFilteredList.Add(match);
                    }
                }
                matches = matchFilteredList;
            }
            return matches;
        }
    }
}