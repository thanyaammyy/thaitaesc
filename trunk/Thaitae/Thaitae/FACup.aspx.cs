using System;
using System.Linq;
using thaitae.lib;

namespace Thaitae
{
    public partial class FACup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dc = ThaitaeDataDataContext.Create().FAMatches.OrderByDescending(item => item.FAMatchDate);
                var faMatchList = dc.ToList();
                JqgridMatch1.DataSource = faMatchList;
                JqgridMatch1.DataBind();
            }
        }
    }
}