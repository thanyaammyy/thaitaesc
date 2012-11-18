using System;
using System.Linq;
using thaitae.lib;

namespace Thaitae.Backend
{
    public partial class League : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dc = ThaitaeDataDataContext.Create();
            JqgridLeague1.DataSource = dc.Leagues.Where(item => item.LeagueType != 1);
            JqgridLeague1.DataBind();
        }

        protected void JqgridLeague1_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var league = dc.Leagues.Single(item => item.LeagueId == Convert.ToInt32(e.RowKey));
                league.LeagueName = e.RowData["LeagueName"];
                league.LeagueType = Convert.ToInt32(e.RowData["LeagueTypeName"]);
                league.LeagueDesc = e.RowData["LeagueDesc"];
                league.Active = Convert.ToInt32(e.RowData["ActiveName"]);
                dc.SubmitChanges();
            }
        }

        protected void JqgridLeague1_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                Session.Remove("leagueid");
                var league = dc.Leagues.Single(item => item.LeagueId == Convert.ToInt32(e.RowKey));
                dc.Leagues.DeleteOnSubmit(league);
                var seasonList = dc.Seasons.Where(item => item.LeagueId == league.LeagueId).ToList();
                dc.Seasons.DeleteAllOnSubmit(seasonList);
                foreach (var season in seasonList)
                {
                    var teamSeasonList = dc.TeamSeasons.Where(item => item.SeasonId == season.SeasonId).ToList();
                    dc.TeamSeasons.DeleteAllOnSubmit(teamSeasonList);
                    var matchList = dc.Matches.Where(item => item.SeasonId == season.SeasonId).ToList();
                    dc.Matches.DeleteAllOnSubmit(matchList);
                    foreach (var match in matchList)
                    {
                        var teamMatchList = dc.TeamMatches.Where(item => item.MatchId == match.MatchId).ToList();
                        dc.TeamMatches.DeleteAllOnSubmit(teamMatchList);
                        var playerMatchList = dc.PlayerMatches.Where(item => item.MatchId == match.MatchId).ToList();
                        dc.PlayerMatches.DeleteAllOnSubmit(playerMatchList);
                        foreach (var playerMatch in playerMatchList)
                        {
                            var playerList = dc.Players.Where(item => item.PlayerId == playerMatch.PlayerId).ToList();
                            dc.Players.DeleteAllOnSubmit(playerList);
                        }
                    }
                    foreach (var teamSeason in teamSeasonList)
                    {
                        var teamList = dc.Teams.Where(item => item.TeamId == teamSeason.TeamId).ToList();
                        dc.Teams.DeleteAllOnSubmit(teamList);
                    }
                }

                dc.SubmitChanges();
            }
        }

        protected void JqgridLeague1_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var league = new thaitae.lib.League
                {
                    LeagueName = e.RowData["LeagueName"],
                    LeagueType = Convert.ToInt32(e.RowData["LeagueTypeName"]),
                    LeagueDesc = e.RowData["LeagueDesc"],
                    Active = Convert.ToByte(e.RowData["ActiveName"])
                };
                dc.Leagues.InsertOnSubmit(league);
                dc.SubmitChanges();
            }
        }
    }
}