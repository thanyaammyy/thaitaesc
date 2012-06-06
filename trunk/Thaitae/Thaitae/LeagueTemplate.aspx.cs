using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thaitae.lib.Page;

namespace Thaitae
{
	public partial class LeagueTemplate : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(Request.QueryString["leagueId"])) return;
			var leagueId = Convert.ToInt32(Request.QueryString["leagueId"]);
			JqgridMatchFullResultBinding(leagueId);
			JqgridMatchBinding(leagueId);
			JqgridSulvoStarBinding(leagueId);
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
	}
}