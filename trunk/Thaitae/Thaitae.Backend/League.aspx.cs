using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thaitae.lib;
using Trirand.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;

namespace Thaitae.Backend
{
    public partial class League : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dc = new ThaitaeDataDataContext();
            JqgridLeague1.DataSource = dc.Leagues;
            JqgridLeague1.DataBind();
        }

        protected void JqgridLeague1_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var league = dc.Leagues.Single(item => item.LeagueId == Convert.ToInt32(e.RowKey));
                league.LeagueName = e.RowData["LeagueName"];
                league.LeagueType = Convert.ToInt32(e.RowData["LeagueTypeName"]);
                league.LeagueDesc = e.RowData["LeagueDesc"];
                league.Active = Convert.ToByte(e.RowData["ActiveName"]);
                dc.SubmitChanges();
            }
        }

        protected void JqgridLeague1_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var league = dc.Leagues.Single(item => item.LeagueId == Convert.ToInt32(e.RowKey));
                dc.Leagues.DeleteOnSubmit(league);
                dc.SubmitChanges();
            }
        }

        protected void JqgridLeague1_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
			if (!IsImage(e.RowData["Picture"])) return;
            using (var dc = new ThaitaeDataDataContext())
            {
				var league = new thaitae.lib.League
            	{
					LeagueName = e.RowData["LeagueName"],
					LeagueType = Convert.ToInt32(e.RowData["LeagueTypeName"]),
					LeagueDesc = e.RowData["LeagueDesc"],
					Active = Convert.ToByte(e.RowData["ActiveName"])
            	};
            	dc.Leagues.InsertOnSubmit(league);
                dc.SubmitChanges();

				const string path = "~/LeagueImages/";
				var pathServer = Server.MapPath(path);
				var name = league.LeagueId + ".jpg";
				var fileName = pathServer + name;
				var fileStream = new FileStream(e.RowData["Picture"], FileMode.OpenOrCreate);
				try
				{
					var image = System.Drawing.Image.FromStream(fileStream);
					image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
				}
				finally
				{
					fileStream.Close();
				}
				league.Picture = "www.thaitaesc.com/Admin/LeagueImages/" + fileName;
				dc.SubmitChanges();

            }
        }

		private static bool IsImage(string path)
		{
			var format = Path.GetFileName(path);
			var regEx = new Regex("([^\\s]+(\\.(?i)(jpg|png|gif|bmp))$)");
			return format != null && regEx.IsMatch(format);
		}
    }
}