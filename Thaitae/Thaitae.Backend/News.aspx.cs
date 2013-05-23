using System;
using System.Linq;
using thaitae.lib;
using thaitae.lib.Page;

namespace Thaitae.Backend
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JqgridNewsBinding();
        }

        protected void JqgridNews_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var news = new New
                        {
                            newsContent = e.RowData["newsContent"],
                            newsTopic = e.RowData["newsTopic"],
                            newsType = Convert.ToInt32(e.RowData["NewsTypeName"])
                        };
                dc.News.InsertOnSubmit(news);
                dc.SubmitChanges();
            }
        }

        protected void JqgridNews_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var news = dc.News.Single(item => item.newsId == Convert.ToInt32(e.RowKey));
                dc.News.DeleteOnSubmit(news);
                dc.SubmitChanges();
            }
        }

        protected void JqgridNews_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            using (var dc = ThaitaeDataDataContext.Create())
            {
                var news = dc.News.Single(item => item.newsId == Convert.ToInt32(e.RowKey));
                news.newsTopic = e.RowData["newsTopic"];
                news.newsContent = e.RowData["newsContent"];
                news.newsType = Convert.ToInt32(e.RowData["NewsTypeName"]);
                dc.SubmitChanges();
            }
        }

        private void JqgridNewsBinding()
        {
            JqgridNews.DataSource = NewsHelper.ListNews();
            JqgridNews.DataBind();
        }
    }
}