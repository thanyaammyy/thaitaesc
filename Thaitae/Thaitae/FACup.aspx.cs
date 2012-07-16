using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thaitae.lib;

namespace Thaitae
{
    public partial class FACup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dc = new ThaitaeDataDataContext().FAMatches.OrderByDescending(item => item.FAMatchDate);
                var faMatchList = dc.ToList();
                JqgridMatch1.DataSource = faMatchList;
                JqgridMatch1.DataBind();
            }
        }
    }
}