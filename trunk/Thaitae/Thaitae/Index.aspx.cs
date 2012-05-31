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

        protected void Page_Load(object sender, EventArgs e)
        {
            ListLeague = LeagueHelper.SelectLeague();
            if (!IsPostBack)
            {
                if (Session["LeagueId"] != null && Session["LeagueId"].ToString() != "")
                {
                    JqgridMatchFullResultBinding(Convert.ToInt32(Session["LeagueId"]));
                    JqgridMatchBinding(Convert.ToInt32(Session["LeagueId"]));
                    JqgridSulvoStarBinding(Convert.ToInt32(Session["LeagueId"]));
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
            Session["LeagueId"] = GetLeague1.Value;
        }
    }
}