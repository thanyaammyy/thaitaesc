using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace thaitae.lib.Page
{
    public static class SeasonHelper
    {
        public static IEnumerable<Season> SelectSeasonItems(int leagueId)
        {
            var dc = ThaitaeDataDataContext.Create().Seasons;
            return dc.Where(item => item.LeagueId == leagueId).ToList();
        }

        public static IEnumerable<Season> ListSeasonItems(int leagueId)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var seasonList = new List<Season> { new Season { SeasonId = 0, SeasonName = "Select Season" } };
                seasonList.AddRange(dc.Seasons.Where(item => item.LeagueId == leagueId).ToList());
                return seasonList;
            }
        }

        public static void InsertSeason(Season objSeason)
        {
            using (var dc = ThaitaeDataDataContext.Create())
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
            using (var dc = ThaitaeDataDataContext.Create())
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
            using (var dc = ThaitaeDataDataContext.Create())
            {
                Season linqSeason = (from dataItem in dc.Seasons
                                     where dataItem.SeasonId == objSeason.SeasonId
                                     select dataItem).First();
                dc.Seasons.DeleteOnSubmit(linqSeason);
                dc.SubmitChanges();
            }
        }

        public static List<Season> GetChampionLeagueGroupSeasonList(int championsFinalSeasonId)
        {
            List<Season> championsGroupSeasonList;
            using (var dc = ThaitaeDataDataContext.Create())
            {
                championsGroupSeasonList =
                    dc.Seasons.Where(item => item.ChampionLeagueSeasonId == championsFinalSeasonId).ToList();
            }
            return championsGroupSeasonList;
        }

        public static bool CheckGroupSeasonIsFinnish(int seasonId)
        {
            bool checkSesson = false;
            using (var dc = ThaitaeDataDataContext.Create())
            {
                if (dc.TeamMatches.Count(item => item.SeasonId == seasonId) != 0)
                {
                    checkSesson = !dc.TeamMatches.Any(item => item.SeasonId == seasonId && item.TeamEdited == 0);
                }
            }
            return checkSesson;
        }

        public static int CheckIsEuropaSeasonId(int seasonId)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var seasonCheck = dc.Seasons.SingleOrDefault(item => item.SeasonId == seasonId && item.LeagueId == 31);
                if (seasonCheck != null)
                {
                    var championLeagueSeason = dc.Seasons.SingleOrDefault(item => item.LeagueId == 14);
                    if (championLeagueSeason != null)
                    {
                        return championLeagueSeason.SeasonId;
                    }
                }
                return seasonId;
            }
        }
    }
}