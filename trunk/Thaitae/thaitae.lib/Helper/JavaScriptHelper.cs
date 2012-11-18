using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace thaitae.lib.Helper
{
    public static class JavaScriptHelper
    {
        /// <summary>
        /// Shows a client-side JavaScript alert in the browser.
        /// </summary>
        /// <param name="message">The message to appear in the alert.</param>
        public static void Alert(string message)
        {
            // Cleans the message to allow single quotation marks
            string cleanMessage = message.Replace("'", "\\'");
            string script = "alert('" + cleanMessage + "');";

            // Gets the executing web page
            var page = HttpContext.Current.CurrentHandler as System.Web.UI.Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", script, true);
        }

        public static void WindowsAlert(string message)
        {
            // Cleans the message to allow single quotation marks
            string cleanMessage = message.Replace("'", "\\'");
            string script = "window.alert('" + cleanMessage + "');";

            // Gets the executing web page
            var page = HttpContext.Current.CurrentHandler as System.Web.UI.Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", script, true);
        }

        /// <summary>
        /// Javascript set Css Visible
        /// Need Jquery
        /// </summary>
        public static void SetVisble(string pStrSelector, bool pBoolVisible)
        {
            string showHide = "$('" + pStrSelector + "')." + (pBoolVisible ? "show();" : "hide();");

            // Gets the executing web page
            var page = HttpContext.Current.CurrentHandler as System.Web.UI.Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page
            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowOrHide" + pStrSelector + pBoolVisible.ToString(), showHide, true);
        }
    }
}