using System;
using System.Collections.Generic;
using System.Linq;
using thaitae.lib;
using thaitae.lib.Page;

namespace Thaitae
{
    public partial class index : System.Web.UI.Page
    {
        public IEnumerable<League> ListLeague = new List<League>();
        public IEnumerable<New> ListScoope = new List<New>();
        public IEnumerable<New> ListHotNews = new List<New>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListLeague = LeagueHelper.SelectLeague();
            ListScoope = NewsHelper.ScoopeList();
            ListHotNews = NewsHelper.HotNewsList();
            if (!IsPostBack)
            {
                var httpCookie = Request.Cookies["LeagueId"];
                if (httpCookie != null && httpCookie.Value != "")
                {
                    JqgridMatchFullResultBinding(Convert.ToInt32(httpCookie.Value));
                    JqgridMatchBinding(Convert.ToInt32(httpCookie.Value));
                    JqgridSulvoStarBinding(Convert.ToInt32(httpCookie.Value));
                }
                else
                {
                    if (ListLeague != null && ListLeague.Any())
                    {
                        var leagueId = ListLeague.First().LeagueId;
                        JqgridMatchFullResultBinding(leagueId);
                        JqgridMatchBinding(leagueId);
                        JqgridSulvoStarBinding(leagueId);
                    }
                }
            }
        }

        public void JqgridMatchFullResultBinding(int leagueId)
        {
            JQGridMatchFullResult.DataSource = TeamSeasonHelper.MatchResult(leagueId);
            JQGridMatchFullResult.DataBind();
        }

        public void JqgridSulvoStarBinding(int leagueId)
        {
            JQGridSulvoStar.DataSource = TeamSeasonHelper.SulvoStar(leagueId);
            JQGridSulvoStar.DataBind();
        }

        public void JqgridMatchBinding(int leagueId)
        {
            JQGridMatches.DataSource = MatchHelper.MatcheShowing(leagueId);
            JQGridMatches.DataBind();
        }

        protected void PostButton1_Click(object sender, EventArgs e)
        {
        }
    }
}