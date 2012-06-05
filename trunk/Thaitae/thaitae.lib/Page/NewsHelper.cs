using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace thaitae.lib.Page
{
	public static class NewsHelper
	{
		public static IEnumerable<New> ScoopeList()
		{
			IEnumerable<New> scoopeList = new List<New>();
			var dc = new ThaitaeDataDataContext();
			var scoopeCount = dc.News.Count();
			if (scoopeCount > 0) scoopeList = dc.News.OrderByDescending(item=>item.newsId).Where(item => item.newsType==2).Take(4).ToList();
			return scoopeList;
		}
		public static New SelectedNews(int newsId)
		{
			var dc = new ThaitaeDataDataContext();
			return dc.News.Single(item => item.newsId == newsId);
		}
	}
}
