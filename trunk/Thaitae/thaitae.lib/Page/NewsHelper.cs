using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace thaitae.lib.Page
{
    public static class NewsHelper
    {
        public static IEnumerable<New> ScoopeList()
        {
            IEnumerable<New> scoopeList = new List<New>();
            var dc = ThaitaeDataDataContext.Create();
            var scoopeCount = dc.News.Count();
            if (scoopeCount > 0) scoopeList = dc.News.OrderByDescending(item => item.newsId).Where(item => item.newsType == 2).Take(4).ToList();
            foreach (var news in scoopeList)
            {
                news.picture = ConfigurationManager.AppSettings["BackendUrl"] + news.picture;
            }
            return scoopeList;
        }

        public static New SelectedNews(int newsId)
        {
            var dc = ThaitaeDataDataContext.Create();
            var news = dc.News.Single(item => item.newsId == newsId);
            news.picture = ConfigurationManager.AppSettings["BackendUrl"] + news.picture;
            return news;
        }

        public static IEnumerable<New> ListNews()
        {
            IEnumerable<New> listNews = new List<New>();
            var dc = ThaitaeDataDataContext.Create();
            var count = dc.News.Count();
            if (count > 0) listNews = dc.News.OrderByDescending(item => item.newsId).ToList();
            foreach (var news in listNews)
            {
                news.picture = ConfigurationManager.AppSettings["BackendUrl"] + news.picture;
            }
            return listNews;
        }

        public static IEnumerable<New> HotNewsList()
        {
            IEnumerable<New> hotNewsList = new List<New>();
            var dc = ThaitaeDataDataContext.Create();
            var count = dc.News.Count();
            if (count > 0) hotNewsList = dc.News.OrderByDescending(item => item.newsId).Where(item => item.newsType == 1).Take(10).ToList();
            foreach (var hotnews in hotNewsList)
            {
                hotnews.picture = ConfigurationManager.AppSettings["BackendUrl"] + hotnews.picture;
            }
            return hotNewsList;
        }
    }
}