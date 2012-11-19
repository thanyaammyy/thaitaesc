using System;
using System.Collections.Generic;
using thaitae.lib;
using thaitae.lib.Page;

namespace Thaitae.CenterControl
{
    public partial class Header : System.Web.UI.UserControl
    {
        public IEnumerable<League> ListLeague = new List<League>();
        public IEnumerable<League> ListChampionsLeague = new List<League>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListLeague = LeagueHelper.SelectNormalLeague();
            ListChampionsLeague = LeagueHelper.SelectChampionsLeague();
        }
    }
}