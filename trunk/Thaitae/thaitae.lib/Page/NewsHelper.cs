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

		public static IEnumerable<New>ListNews()
		{
			IEnumerable<New> listNews = new List<New>();
			var dc = new ThaitaeDataDataContext();
			var count = dc.News.Count();
			if (count > 0) listNews = dc.News.OrderByDescending(item => item.newsId).ToList();
			return listNews;
		}

		public static IEnumerable<New> HotNewsList()
		{
			IEnumerable<New> hotNewsList = new List<New>();
			var dc = new ThaitaeDataDataContext();
			var count = dc.News.Count();
			if (count > 0) hotNewsList = dc.News.OrderByDescending(item => item.newsId).Where(item => item.newsType == 1).Take(10).ToList();
			return hotNewsList;
		}
	}
}
