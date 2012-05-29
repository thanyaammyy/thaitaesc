using System;
using System.Linq;
using thaitae.lib;
using thaitae.lib.Page;
using System.Collections.Generic;

namespace Thaitae
{
	public partial class index : System.Web.UI.Page
	{
		public IEnumerable<League> ListLeague = new List<League>();
		protected void Page_Load(object sender, EventArgs e)
		{
			ListLeague = LeagueHelper.SelectLeague();
			if(!IsPostBack)
			{
				if (Session["LeagueId"] != null && Session["LeagueId"].ToString()!="")
				{
					JqgridMatchFullResultBinding(Convert.ToInt32(Session["LeagueId"]));
					JqgridMatchResultBinding(Convert.ToInt32(Session["LeagueId"]));
					JqgridMatchBinding(Convert.ToInt32(Session["LeagueId"]));
					JqgridSulvoStarBinding(Convert.ToInt32(Session["LeagueId"]));
					SetLabelPage(Convert.ToInt32(Session["LeagueId"]));
				}
				
			}
			
		}

		public void SetLabelPage(int leagueId)
		{
			var league = LeagueHelper.GetLeague(leagueId);
			lbMatch.Text = league.LeagueName;
			lbMatchResult.Text = league.LeagueName;
			lbSulvoStar.Text = league.LeagueName;
		}

		public void JqgridMatchFullResultBinding(int leagueId)
		{
			JQGridMatchFullResult.DataSource = TeamSeasonHelper.MatchResult(leagueId);
			JQGridMatchFullResult.DataBind();
		}

		public void JqgridMatchResultBinding(int leagueId)
		{
			JQGridMatchResult.DataSource = TeamSeasonHelper.MatchResult(leagueId);
			JQGridMatchResult.DataBind();
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