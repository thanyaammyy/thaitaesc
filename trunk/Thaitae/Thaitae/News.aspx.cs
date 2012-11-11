using System;
using thaitae.lib.Page;

namespace Thaitae
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JqgridNewsBinding();
        }

        public void JqgridNewsBinding()
        {
            JQGridNews.DataSource = NewsHelper.ListNews();
            JQGridNews.DataBind();
        }
    }
}