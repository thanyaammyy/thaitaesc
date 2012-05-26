using System;
using System.Linq;
using thaitae.lib;
using thaitae.lib.Page;

namespace Thaitae
{
	public partial class index : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			JqgridMatchFullResultBinding(1);
			JqgridMatchResultBinding(1);
			JqgridMatchBinding(1);
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

		public void JqgridSulvoStarBinding()
		{
			//JQGridSulvoStar.DataSource = TeamSeasonHelper.MatchResult(1);
			//JQGridSulvoStar.DataBind();
		}

		public void JqgridMatchBinding(int leagueId)
		{
			JQGridMatches.DataSource = MatchHelper.MatcheShowing(leagueId);
			JQGridMatches.DataBind();
		}
	}
}