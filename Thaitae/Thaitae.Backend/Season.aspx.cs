using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thaitae.lib;

namespace Thaitae.Backend
{
    public partial class Season : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

		protected void ddlLeague_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (((DropDownList)sender).SelectedValue != "")
			{
				Session["leagueid"] = ddlLeague.SelectedValue;
			}
		}
    }
}