using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace thaitae.lib.Page
{
    public static class SeasonHelper
    {
        public static IEnumerable<Season> SelectSeasonItems(int leagueId)
        {
            var dc = new ThaitaeDataDataContext().Seasons;
            return dc.Where(item => item.LeagueId == leagueId).ToList();
        }

        public static IEnumerable<Season> ListSeasonItems(int leagueId)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var seasonList = new List<Season> { new Season { SeasonId = 0, SeasonName = "Select Season" } };
                seasonList.AddRange(dc.Seasons.Where(item => item.LeagueId == leagueId).ToList());
                return seasonList;
            }
        }

        public static void InsertSeason(Season objSeason)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                dc.Seasons.InsertOnSubmit(objSeason);
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

        public static void UpdateSeason(Season objSeason)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                Season linqSeason = (from dataItem in dc.Seasons
                                     where dataItem.SeasonId == objSeason.SeasonId
                                     select dataItem).First();
                linqSeason.LeagueId = objSeason.LeagueId;
                linqSeason.SeasonName = objSeason.SeasonName;
                linqSeason.SeasonDesc = objSeason.SeasonDesc;
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

        public static void DeleteSeason(Season objSeason)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                Season linqSeason = (from dataItem in dc.Seasons
                                     where dataItem.SeasonId == objSeason.SeasonId
                                     select dataItem).First();
                dc.Seasons.DeleteOnSubmit(linqSeason);
                dc.SubmitChanges();
            }
        }
    }
}