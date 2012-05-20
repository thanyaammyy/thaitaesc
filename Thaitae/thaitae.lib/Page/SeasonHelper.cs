using System;
using System.Collections.Generic;
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
	}
}
