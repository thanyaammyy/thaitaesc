using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thaitae.lib;
using thaitae.lib.Page;

namespace Thaitae
{
	public partial class NewsTemplate : System.Web.UI.Page
	{
		public New SelectedNews = new New();
		protected void Page_Load(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(Request.QueryString["newsId"]))return;
			var newsId = Convert.ToInt32(Request.QueryString["newsId"]);
			SelectedNews = NewsHelper.SelectedNews(newsId);
		}
	}
}