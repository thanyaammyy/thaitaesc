using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace thaitae.lib
{
    public static class Task
    {
        public static void Run(Action action)
        {
            Delay(action, TimeSpan.FromTicks(1));
        }

        public static void Delay(Action action, TimeSpan delay)
        {
            if (delay.Ticks <= 0)
                delay = TimeSpan.FromTicks(1);

            HttpRuntime.Cache.Add(Guid.NewGuid().ToString(), string.Empty, null, Cache.NoAbsoluteExpiration, delay, CacheItemPriority.NotRemovable,
                (key, cacheItem, reason) =>
                {
                    try
                    {
                        action();
                    }
                    catch (Exception ex)
                    {
                        WriteLog(ex.ToString());
                    }
                });
        }

        public static void WriteLog(string message)
        {
            using (var dc = new ThaitaeDataDataContext())
            {
                var error = new ErrorLog()
                {
                    ErrorMessage = message,
                    ErrorDate = DateTime.Now
                };
                dc.ErrorLogs.InsertOnSubmit(error);
                dc.SubmitChanges();
            }
        }

        public static void SendMail(string to, string subject, string body)
        {
            Run(() => Helper.MailHelper.Send(to, subject, body));
        }
    }
}