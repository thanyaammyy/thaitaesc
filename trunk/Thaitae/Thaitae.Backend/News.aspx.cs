using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thaitae.lib;

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
            using (var dc = new ThaitaeDataDataContext())
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
            using (var dc = new ThaitaeDataDataContext())
            {
                var news = dc.News.Single(item => item.newsId == Convert.ToInt32(e.RowKey));
                dc.News.DeleteOnSubmit(news);
                dc.SubmitChanges();
            }
        }

        protected void JqgridNews_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
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
            var dc = new ThaitaeDataDataContext().News;
            var seasonList = dc.ToList();
            JqgridNews.DataSource = seasonList;
            JqgridNews.DataBind();
        }
    }
}