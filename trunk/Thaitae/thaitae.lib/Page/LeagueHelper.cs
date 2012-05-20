using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib.Page
{
	public static  class LeagueHelper
	{
		public static IEnumerable<League> SelectLeagueItems()
		{
			using (var dc = new ThaitaeDataDataContext())
			{
				return dc.Leagues.Where(item => item.Active == 1).ToList();
			}
		}
	}
}
