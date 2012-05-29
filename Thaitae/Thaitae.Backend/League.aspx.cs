using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using thaitae.lib;

namespace Thaitae.Backend
{
    public partial class League : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dc = new ThaitaeDataDataContext();
            JqgridLeague1.DataSource = dc.Leagues;
            JqgridLeague1.DataBind();
        }

        protected void JqgridLeague1_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var league = dc.Leagues.Single(item => item.LeagueId == Convert.ToInt32(e.RowKey));
                league.LeagueName = e.RowData["LeagueName"];
                league.LeagueType = Convert.ToInt32(e.RowData["LeagueTypeName"]);
                league.LeagueDesc = e.RowData["LeagueDesc"];
                league.Active = Convert.ToInt32(e.RowData["ActiveName"]);
                dc.SubmitChanges();
                const string path = "~/LeagueImages/";
                if (!IsImage(e.RowData["Picture"])) return;
                var pathServer = Server.MapPath(path);
                var name = league.LeagueId + ".jpg";
                var fileName = pathServer + name;
                var fileStream = new FileStream(e.RowData["Picture"], FileMode.OpenOrCreate);
                try
                {
                    var image = System.Drawing.Image.FromStream(fileStream);
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                finally
                {
                    fileStream.Close();
                }

                league.Picture = "http://www.thaitaesc.com/Admin/LeagueImages/" + name;
                dc.SubmitChanges();
            }
        }

        protected void JqgridLeague1_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
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
            using (var dc = new ThaitaeDataDataContext())
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
                if (!IsImage(e.RowData["Picture"])) return;
                const string path = "~/LeagueImages/";
                var pathServer = Server.MapPath(path);
                var name = league.LeagueId + ".jpg";
                var fileName = pathServer + name;
                var fileStream = new FileStream(e.RowData["Picture"], FileMode.OpenOrCreate);
                try
                {
                    var image = System.Drawing.Image.FromStream(fileStream);
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                finally
                {
                    fileStream.Close();
                }
                league.Picture = "http://www.thaitaesc.com/Admin/LeagueImages/" + name;
                dc.SubmitChanges();
            }
        }

        private static bool IsImage(string path)
        {
            var format = Path.GetFileName(path);
            var regEx = new Regex("([^\\s]+(\\.(?i)(jpg|png|gif|bmp))$)");
            return format != null && regEx.IsMatch(format);
        }
    }
}