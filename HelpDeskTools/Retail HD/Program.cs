using System;
using System.Windows.Forms;

namespace Retail_HD
{
	static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
		{
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;

			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new RetailHD());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            string message = "<font size=\"+1\"><strong>Unhandled Exception: Crash Report</strong></font><br>" +
                "=====================================================<br>" +
                "<br><br>" +
                "<p>Exception Message: " + ex.Message + "</p>" +
                "<p>Stack Trace: " + ex.StackTrace + "</p>" +
                "<p>Exception Source:" + ex.Source + "</p>" +
                "<p>Microsoft Help Link: " + ex.HelpLink + "</p>" +
                "<br><br>" +
                "Please register this as a bug on <a href=\"http://johnkiddjr.visualstudio.com\">http://johnkiddjr.visualstudio.com</a> to track fix progress.";

            Shared.Functions.SendEmail("chad.gould@wwwinc.com", message, "Unhandled Thread Exception: Crash Report");
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            string message = "<font size=\"+1\"><strong>Unhandled Exception: Crash Report</strong></font><br>" +
                "=====================================================<br>" +
                "<br><br>" +
                "<p>Exception Message: " + ex.Message + "</p>" +
                "<p>Stack Trace: " + ex.StackTrace + "</p>" +
                "<p>Exception Source:" + ex.Source + "</p>" +
                "<p>Microsoft Help Link: " + ex.HelpLink + "</p>" +
                "<br><br>" +
                "Please register this as a bug on <a href=\"http://johnkiddjr.visualstudio.com\">http://johnkiddjr.visualstudio.com</a> to track fix progress.";

			Shared.Functions.SendEmail("chad.gould@wwwinc.com", message, "Unhandled Thread Exception: Crash Report");
        }
    }
}
