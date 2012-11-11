using System.Net.Mail;
using System.Text;

namespace thaitae.lib.Helper
{
    internal class MailHelper
    {
        public static void Send(string to, string subject, string body)
        {
            var message = new MailMessage { BodyEncoding = Encoding.UTF8 };
            foreach (var str in to.Split(';'))
                message.To.Add(new MailAddress(str.Trim()));

            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            var smtpClient = new SmtpClient();
            smtpClient.EnableSsl = smtpClient.Port != 25;
            smtpClient.Send(message);
        }
    }
}