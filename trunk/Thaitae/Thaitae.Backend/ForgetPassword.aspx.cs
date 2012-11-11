using System;
using System.Web;
using System.Web.Security;
using thaitae.lib;

namespace Thaitae.Backend
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SendEmailResetPassword();
            lblResult.Visible = true;
        }

        protected void SendEmailResetPassword()
        {
            string email = txtEmail.Text.Trim();
            string username = Membership.GetUserNameByEmail(email);

            if (username != null)
            {
                HttpContext context = HttpContext.Current;
                MembershipUser Current = Membership.GetUser(username);

                if (Current.IsLockedOut)
                    Current.UnlockUser();

                Task.SendMail(email, "Password recovery from Thaitae Backend", "New Pass :" + Membership.GeneratePassword(8, 2));
            }
        }
    }
}