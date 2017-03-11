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

            //FixDiffieHellman();
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

        /*
        First, you’ll need an application manifest (Right click on project, Add New Item, Application Manifest)

        You may get an error that “Click Once doesn’t support runas admin”; Go to project settings, Security tab, and disable Click-Once security.

        Change this line:
        <requestedExecutionLevel level="asInvoker" uiAccess="false" />
        To
        <requestedExecutionLevel level="requireAdministrator" uiAccess="false" />

        Add this to your code and run on app open (in the main init):
        */
        static void FixDiffieHellman()
        {
            //disable Diffie-Hellman exchange key because Cisco blows goats, I have proof
            Microsoft.Win32.RegistryKey _key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL", true);
            string[] subKeys = _key.GetSubKeyNames();
            bool keaFound = false;
            bool difhelFound = false;

            if (subKeys.Length > 0)
            {
                foreach (string _s in subKeys)
                {
                    if (_s == "KeyExchangeAlgorithms")
                    {
                        keaFound = true;
                        _key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\KeyExchangeAlgorithms", true);
                        string[] subKeys2 = _key.GetSubKeyNames();

                        foreach (string _sk in subKeys2)
                        {
                            if (_sk == "Diffie-Hellman")
                            {
                                difhelFound = true;
                                //check value, and change to 0
                                _key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\KeyExchangeAlgorithms\Diffie-Hellman", true);

                                string dhValue = _key.GetValue("Enabled", 1).ToString();

                                if (dhValue != "0")
                                {
                                    _key.SetValue("Enabled", 0, Microsoft.Win32.RegistryValueKind.DWord);
                                }
                            }
                        }

                        if (!difhelFound)
                        {
                            //create diffiehellman and set enabled to 0
                            _key = _key.CreateSubKey("Diffie-Hellman");

                            _key.SetValue("Enabled", 0, Microsoft.Win32.RegistryValueKind.DWord);
                        }
                    }
                }

                if (!keaFound)
                {
                    _key = _key.CreateSubKey("KeyExchangeAlgorithms");
                    keaFound = true;
                    _key = _key.CreateSubKey("Diffie-Hellman");
                    difhelFound = true;
                    _key.SetValue("Enabled", 0, Microsoft.Win32.RegistryValueKind.DWord);
                }
            }
            else
            {
                //create everything
                if (!keaFound && !difhelFound)
                {
                    _key = _key.CreateSubKey("KeyExchangeAlgorithms");
                    _key = _key.CreateSubKey("Diffie-Hellman");
                    _key.SetValue("Enabled", 0, Microsoft.Win32.RegistryValueKind.DWord);
                }
            }
        }

    }
}
