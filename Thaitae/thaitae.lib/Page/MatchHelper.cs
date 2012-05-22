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
    }
}