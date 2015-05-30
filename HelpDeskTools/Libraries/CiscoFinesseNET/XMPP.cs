using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Matrix;
using Matrix.Xmpp.Client;

namespace CiscoFinesseNET
{
    internal class XMPPHandler
    {
        XmppClient _client = new XmppClient();
        StreamWriter _sw;
        Settings _settings = new Settings();
        //PubSubManager subManager;

        internal void Connect(Settings _s)
        {
            _client = new XmppClient();

            string lic = @"eJxkkFtTwjAQhf+K4yujaaFYcdaM2iKWi0qrIr5FEkqkSWoutPjrRcX7y86e/fZyZmHIZ0watlOLQprjXZLvGTW3FdHsqPhAuxiutaJuZhOKM+soV4C+KzB2RFpu19gH9JVD5IxVgmkMl0Qw3F2RwhGrNKB3DZESJZHrT8CV3NlaAfTJoCsIL7AhBTMnP5zt003TB9s0fx26LSmxrFuXXLN4k+Gm57d9zw8B/UOQmJgJha12m11bAW/x93zg+/4BoD8AMp5LYp1muGLiKQja5WM9iNKKthp3JmzXN5yxwVXfu5qGd1WwuOjzHolXnTkfJOex1KcNtMqr65fZsOz36Dpb90gnK+u8E1couxcs8M/6+SDJRtGil6C6deGmSKcibfGYHI7vyWTSaC+HZSs3cvQ8fbCeSFeHY9tsTqgkZ8MR71g1cS/RUj2n04fwNKTFgecdA/r2DWj7bvwqgAA=";
            Matrix.License.LicenseManager.SetLicense(lic);
            _settings = _s;

            _client.SetUsername(_s.userName);
            _client.SetXmppDomain(_s.GetNakedFQDN());
            _client.Password = _s.password;
            _client.Resource = "FinesseNET";

            //create the XMPPLOGGING folder if it doesn't exist
            if (!Directory.Exists(Init.mainSettings.GetSaveLocation(false) + @"XMPPLOGGING\"))
            {
                Directory.CreateDirectory(Init.mainSettings.GetSaveLocation(false) + @"XMPPLOGGING\");
            }

            _client.Open();

            //register events
            _client.OnLogin += _client_OnLogin;
            _client.OnMessage += _client_OnMessage;
        }

        private void _client_OnMessage(object sender, MessageEventArgs e)
        {
            DateTime fnDetermine = (DateTime.Now.Hour < 2) ? DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)) : DateTime.Now;
            string todayFNString = string.Format("{0:00}{1:00}{2:00}", fnDetermine.Year, fnDetermine.Month, fnDetermine.Day);

            string _s = e.Message.ToString().Replace("&lt;", "<");
            _s = _s.Replace("&gt;", ">");

            using (_sw = new StreamWriter(Init.mainSettings.GetSaveLocation(false) + @"\XMPPLOGGING\xmpplog." + todayFNString + ".log", true))
            {
                _sw.WriteLine(System.DateTime.Now.ToLongDateString() + "    " + System.DateTime.Now.ToLongTimeString());
                _sw.WriteLine(_s);
                _sw.WriteLine();
            }

            if (System.Diagnostics.Debugger.IsAttached)
            {
                System.Diagnostics.Debug.WriteLine(_s);
            }

            Helper.UpdateObjects(_s);
        }

        internal void _client_OnLogin(object sender, Matrix.EventArgs e)
        {
            //do nothing for now
            //eventually subscribe to additional alerts from xmpp
            //if this is global HD, run init here and NOW
            if (_settings.AppID == "GlobalHD")
            {
                Init.GlobalHDInit();
            }

            //email yesterday's logs, if it hasn't already been done.

            //check what the most recently sent log was, send all logs before this time and delete them to prevent resend
            string[] files = System.IO.Directory.GetFiles(Init.mainSettings.GetSaveLocation(false) + @"\XMPPLOGGING", "xmpplog.*.log", SearchOption.TopDirectoryOnly);

            foreach (string fn in files)
            {
                string[] parts = fn.Split('.');
                DateTime compare = new DateTime(int.Parse(parts[1].Substring(0, 4)), int.Parse(parts[1].Substring(4, 2)), int.Parse(parts[1].Substring(6)));

                if (DateTime.Compare(compare, Finesse.Default.LastLogSent) > 0) //newer than last submitted
                {
                    if (DateTime.Compare(compare, DateTime.Now.Date) < 0) //older than today
                    {
                        //submit this log
                        FileInfo file2Send = new FileInfo(fn);
                        if (b_SendEmail("john.kidd@wwwinc.com", "See attached log file.", "Finesse Log for " + System.Environment.UserName + " on " + parts[1], new FileInfo(fn)))
                        {
                            //File.Delete(fn);
                            Finesse.Default.LastLogSent = DateTime.Now.Date.Subtract(new TimeSpan(1, 0, 0, 0));
                            Finesse.Default.Save();
                        }
                    }
                }
            }
        }

        internal void CloseSession()
        {
            _client.Close();
        }

        private static bool b_SendEmail(string to, string body, string subject, FileInfo attachement)
        {
            try
            {
                string from = Environment.UserName.ToString() + "@wwwinc.com";
                //System.Net.Mail.MailMessage _msg = new System.Net.Mail.MailMessage(from, to, subject, body);
                System.Net.Mail.MailMessage _msg = new System.Net.Mail.MailMessage();
                _msg.From = new System.Net.Mail.MailAddress(from);
                _msg.Subject = subject;
                _msg.Body = body;
                _msg.To.Add(to);

                using (FileStream fs = attachement.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    _msg.Attachments.Add(new System.Net.Mail.Attachment(fs, attachement.Name));
                }

                _msg.IsBodyHtml = true;

                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("wwwsmtp.wwwint.corp", 25);
                client.UseDefaultCredentials = true;
                client.Send(_msg);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
