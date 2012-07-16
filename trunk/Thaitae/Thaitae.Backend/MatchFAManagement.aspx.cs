using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using thaitae.lib;
using Trirand.Web.UI.WebControls;

namespace Thaitae.Backend
{
    public partial class MatchFAManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                JqgridFAMatchBinding();
            }
        }

        private void JqgridFAMatchBinding()
        {
            var dc = new ThaitaeDataDataContext().FAMatches;
            var faMatchList = dc.ToList();
            JqgridMatch1.DataSource = faMatchList;
            JqgridMatch1.DataBind();
        }

        protected void JqgridMatch1_RowDeleting(object sender, JQGridRowDeleteEventArgs e)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var faMatch = dc.FAMatches.Single(item => item.FAMatchId == Convert.ToInt32(e.RowKey));
                dc.FAMatches.DeleteOnSubmit(faMatch);
                dc.SubmitChanges();
            }
        }

        protected void JqgridMatch1_RowAdding(object sender, JQGridRowAddEventArgs e)
        {
            var teamWin = "<b style='color: red'>ยังไม่มีผลการแข่งขัน</b>";
            var hasResult = 0;
            var homeScore = String.IsNullOrEmpty(e.RowData["TeamHomeScore"])
                                ? 0
                                : Convert.ToInt32(e.RowData["TeamHomeScore"]);
            var awayScore = String.IsNullOrEmpty(e.RowData["TeamAwayScore"])
                                ? 0
                                : Convert.ToInt32(e.RowData["TeamAwayScore"]);
            var date = String.IsNullOrEmpty(e.RowData["FAMatchDate"])
                           ? DateTime.Now
                           : Convert.ToDateTime(e.RowData["FAMatchDate"]);
            if (homeScore > awayScore)
            {
                teamWin = "<b style='color: blue'>" + e.RowData["TeamHomeName"] + "</b>";
                hasResult = 1;
            }
            else if (homeScore < awayScore)
            {
                teamWin = "<b style='color: blue'>" + e.RowData["TeamAwayName"] + "</b>";
                hasResult = 1;
            }
            var faMatch = new FAMatch
                              {
                                  FAMatchDate = date,
                                  TeamHomeName = e.RowData["TeamHomeName"],
                                  TeamHomeScore = homeScore,
                                  TeamAwayScore = awayScore,
                                  TeamAwayName = e.RowData["TeamAwayName"],
                                  TeamWin = teamWin,
                                  HasResult = hasResult
                              };
            using (var dc = new ThaitaeDataDataContext())
            {
                dc.FAMatches.InsertOnSubmit(faMatch);
                dc.SubmitChanges();
            }
        }

        protected void JqgridMatch1_RowEditing(object sender, JQGridRowEditEventArgs e)
        {
            var teamWin = "<b style='color: red'>ยังไม่มีผลการแข่งขัน</b>";
            var hasResult = 0;
            var homeScore = String.IsNullOrEmpty(e.RowData["TeamHomeScore"])
                                ? 0
                                : Convert.ToInt32(e.RowData["TeamHomeScore"]);
            var awayScore = String.IsNullOrEmpty(e.RowData["TeamAwayScore"])
                                ? 0
                                : Convert.ToInt32(e.RowData["TeamAwayScore"]);
            var date = String.IsNullOrEmpty(e.RowData["FAMatchDate"])
                           ? DateTime.Now
                           : Convert.ToDateTime(e.RowData["FAMatchDate"]);
            if (homeScore > awayScore)
            {
                teamWin = "<b style='color: blue'>" + e.RowData["TeamHomeName"] + "</b>";
                hasResult = 1;
            }
            else if (homeScore < awayScore)
            {
                teamWin = "<b style='color: blue'>" + e.RowData["TeamAwayName"] + "</b>";
                hasResult = 1;
            }
            using (var dc = new ThaitaeDataDataContext())
            {
                var faMatch = dc.FAMatches.Single(item => item.FAMatchId == Convert.ToInt32(e.RowKey));
                faMatch.FAMatchDate = date;
                faMatch.TeamHomeName = e.RowData["TeamHomeName"];
                faMatch.TeamHomeScore = homeScore;
                faMatch.TeamAwayScore = awayScore;
                faMatch.TeamAwayName = e.RowData["TeamAwayName"];
                faMatch.TeamWin = teamWin;
                faMatch.HasResult = hasResult;
                dc.SubmitChanges();
            }
        }
    }
}