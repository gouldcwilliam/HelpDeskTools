using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;
using System.IO;
using System.Threading;

using System.Data;
using System.Data.SqlClient;

namespace Retail_HD
{
	public static class GlobalFunctions
    {
        #region Phone Crap *****IGNORE*****
        public static string _pusr = string.Empty;
        public static string _ppas = string.Empty;
        public static string _pacd = string.Empty;

        public static List<Classes.People> onCallList = new List<Classes.People>();
        #endregion
        /// <summary>
        /// Returns the currently used version number.
        /// </summary>
        public static Version currentVersion
        {
            get
            {
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                }
                else return new Version(0, 0, 0, 1);
            }
        }

        /// <summary>
        /// Checks for the newest version deployed, and returns the version number.
        /// </summary>
        public static Version newestVersion
        {
            get
            {
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    System.Deployment.Application.UpdateCheckInfo updateInfo = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CheckForDetailedUpdate();
                    if (updateInfo.UpdateAvailable)
                    {
                        return updateInfo.AvailableVersion;
                    }
                    else return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                }
                else return new Version(0, 0, 0, 1);
            }
        }

        public static bool ForceUpdate()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.UpdateCheckInfo updateInfo = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CheckForDetailedUpdate();
                if (updateInfo.UpdateAvailable)
                {
                    return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.Update();
                }
                else return false;
            }
            else return false;
        }

        //change this to return the value from SQL.
        public static string newestVersionChangelog
        {
            get
            {
				SqlParameter sp = new SqlParameter("@version", newestVersion.ToString());
				DataTable dt = SQL.Select("select [change] from [ChangeSet] where [version] = @version",sp);
				if (dt.Rows.Count > 0)
				{
					return dt.Rows[0][0].ToString();
				}
				else
				{
					return string.Empty;
				}
					//"- Added \"What's New?\" section to Help menu.\n- Updated verbage for wrap up errors.\n- Added update button.\n- Minor tweaks to UX.";
            }
        }

        public static bool b_CheckValidExtensionPrefix(string extprefix)
        {
            switch (extprefix)
            {
                case "300":
                case "302":
                case "303":
                case "304":
                case "305":
                case "311":
                case "314":
                case "315":
                case "317":
                case "318":
                case "400":
                case "500":
                case "502":
                    return true;
                default:
                    return false;
            }
        }

		public static void v_InstallPsTools()
		{
			try
			{

				if (!File.Exists(Environment.ExpandEnvironmentVariables("%WINDIR%") + @"\System32\PsExec.exe"))
				{
					Console.WriteLine(@"PsExec not found, copying to: {0}\System32\", Environment.ExpandEnvironmentVariables("%WINDIR%"));
					File.Copy(Shared.Settings.Default._NetworkShare + @"\Software\psexec\PsExec.exe",
						Environment.ExpandEnvironmentVariables("%WINDIR%") + @"\System32\PsExec.exe",
						true);
				}
			}
			catch (Exception) { }
		}


		public static void v_Install_DelayedStartServices()
		{
			try
			{
				File.Copy(Shared.Settings.Default._NetworkShare + @"\Software\DelayedStartServices\DelayedStartServices.exe",
						Environment.ExpandEnvironmentVariables("%WINDIR%") + @"\System32\DelayedStartServices.exe",
						true);
			}
			catch (Exception) { Console.WriteLine("Failed copying DelayedStartServices"); }
		}


        public static void v_CreateTempFolder()
        {
            if (!Directory.Exists(@"C:\Temp"))
            {
                Directory.CreateDirectory(@"C:\Temp");
            }
        }

		

		public static bool b_KillProcess(string ComputerName, string ProcName)
		{
			try
			{
				ManagementScope msScope = new ManagementScope(string.Format(@"\\{0}\root\cimv2", ComputerName));
				msScope.Connect();
				ObjectQuery oqQuery = new ObjectQuery(string.Format("SELECT * FROM Win32_Process WHERE Name='{0}'", ProcName));
				ManagementObjectSearcher mosSearcher = new ManagementObjectSearcher(msScope, oqQuery);
				ManagementObjectCollection mocCollection = mosSearcher.Get();

				foreach (ManagementObject moObj in mocCollection)
				{
					moObj.InvokeMethod("Terminate", null);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			return true;
		}



		public static int i_ExecuteCommand(string ExecutableFile, bool Interactive, string Arguments, string Title, bool wait)
		{
			return i_ExecuteCommand("CMD", Interactive, string.Format("/C TITLE {0} && {1} {2}", Title, ExecutableFile, Arguments), wait);
		}
		public static int i_ExecuteCommand(string ExecutableFile, bool Interactive, string Arguments, bool Wait)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = ExecutableFile;
			startInfo.Arguments = Arguments;
			startInfo.CreateNoWindow = (!Interactive);
			startInfo.UseShellExecute = Interactive;
			Process process = Process.Start(startInfo);
			if (Wait) { process.WaitForExit(); return process.ExitCode; }
			return 0;
		}
		public static void i_ExecuteCommand(List<Computer> computers,string ExecutableFile, bool Interactive, string Arguments, bool Wait)
		{
			foreach (Computer computer in computers)
			{
				i_ExecuteCommand(ExecutableFile, Interactive, Arguments, Wait);
			}
		}
		public static int i_ExecuteCommand(string ExecutableFile, bool Interactive)
		{
			return i_ExecuteCommand(ExecutableFile, Interactive, string.Empty);
		}
		public static int i_ExecuteCommand(string ExecutableFile, bool Interactive, string Arguments)
		{
			return i_ExecuteCommand(ExecutableFile, Interactive, Arguments, true);
		}


		public static bool b_WriteBatFile(string Contents)
		{
			return b_WriteFile(Contents, Shared.Settings.Default._TempFile);
		}



		public static bool b_WriteFile(string Contents, string TempFileLocation)
		{
			try { File.WriteAllText(TempFileLocation, Contents); }
			catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
			return true;
		}

		

		public static bool b_CopyBatFile(string ComputerName)
		{
			return b_CopyFile(ComputerName, Shared.Settings.Default._TempFile);
		}

	

		public static bool b_CopyFile(string ComputerName, string TempFileLocation)
		{
			try
			{
				string Destination = string.Format(@"\\{0}\C$\{1}", ComputerName, TempFileLocation.Substring(3));
				Console.WriteLine(Destination);
				File.Copy(TempFileLocation, Destination, true);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			return true;
		}



		public static void v_UpdateComputersFromAD()
		{
			if (System.IO.File.Exists(Shared.Settings.Default._UpdateComputerList))
			{
				Process.Start(Shared.Settings.Default._UpdateComputerList);
			}
		}



		public static void v_BrowseComputer(List<Computer> SelectedComputers)
		{
			foreach (Computer computer in SelectedComputers)
			{
				Process explore = Process.Start("EXPLORER", string.Format(@"\\{0}\c$", computer.name));
			}
		}
		public static void v_BrowseComputer(string Computer, string Suffix)
		{
			Process explore = Process.Start("EXPLORER", string.Format(@"\\{0}\c${1}", Computer, Suffix));
		}



		public static void v_ConnectWithAltiris(string computer)
		{
			if (!DnsLookup(computer)) { return; }
			Process altiris = Process.Start("AWREM32", @"C:\Users\All Users\Symantec\pcAnywhere\Remotes\Network, Cable, DSL.chf /c" + computer);
			System.Threading.Thread.Sleep(2500);
			Console.WriteLine("Launched altiris on: " + computer);
		}
		public static void v_ConnectWithAltiris(Computer computer)
		{
			v_ConnectWithAltiris(computer.name);
		}
		public static void v_ConnectWithAltiris(List<Computer> SelectedComputers)
		{
			foreach (Computer computer in SelectedComputers)
			{
				v_ConnectWithAltiris(computer.name);
			}
		}



		public static bool DnsLookup(string hostname)
		{
			System.Net.IPHostEntry host;
			try
			{
				host = System.Net.Dns.GetHostEntry(hostname);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				System.Windows.Forms.MessageBox.Show("Exception caught during DNS lookup\nThe computer is not online", "DNS Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			if (host == null || host.AddressList.GetLength(0) == 0)
			{
				System.Windows.Forms.MessageBox.Show("No addresses availible for the hostname", "DNS Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return false;
			}
			return true;
		}
		

		public static void v_RemoteCMD(List<Computer> SelectedComputers)
		{
			foreach (Computer computer in SelectedComputers)
			{
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.FileName = "CMD";
				startInfo.Arguments = string.Format("/C TITLE Remote CMD on: {0} && WINRS -d:C:\\ -r:{0} CMD", computer.name);
				Process process = Process.Start(startInfo);
			}
		}

		public static void v_InstallSemantic(string computer)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = "PSEXEC";
			startInfo.Arguments = string.Format(@"\\{0} -s -d -i {1}", computer, Shared.Settings.Default._TempFile);
			Process process = Process.Start(startInfo);
		}

		public static void v_LocalCMD(string computer)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = "PSEXEC";
			startInfo.Arguments = string.Format(@"\\{0} -s -d -i CMD", computer);
			Process process = Process.Start(startInfo);
		}


		public static void v_LocalCMD(Computer computer)
		{
			v_LocalCMD(computer.name);
		}
		public static void v_LocalCMD(List<Computer> SelectedComputers)
		{
			foreach (Computer computer in SelectedComputers)
			{
				v_LocalCMD(computer.name);
			}
		}



		public static void Multi(string computer)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = "PSEXEC";
			startInfo.Arguments = string.Format(@"\\{0} -s -d -i \HELPDESK\multi.bat", computer);
			Process process = Process.Start(startInfo);
		}
		public static void Multi(Computer computer)
		{
			Multi(computer.name);
		}

		
		
		public static void v_Pinger(string item)
		{
			v_Pinger(item, string.Empty);
		}
		public static void v_Pinger(string item, string title)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = "CMD";
			if (title == string.Empty)
			{
				startInfo.Arguments = string.Format("/C PING -t {0}", item);
			}
			else
			{
				startInfo.Arguments = string.Format("/C TITLE PING: {0} && PING -t {1}", title, item);
			}
			Process.Start(startInfo);
		}

		
		
		public static void v_PingRegisters(List<Computer> Computers)
		{
			foreach (Computer computer in Computers)
			{
				v_Pinger(computer.name, computer.name);
			}
		}
		
		public static bool b_FillStoreInfo()
		{
			try
			{
				foreach (System.Data.DataRow dr in SQL.dt_SelectStore(Convert.ToInt32(Info.store)).Rows)
				{
					Info.address = dr["address"].ToString();
					Console.WriteLine(Info.address);
					Info.city = dr["city"].ToString();
					Info.dm = dr["dm"].ToString();
					Info.email = dr["email"].ToString();
					Info.manager = dr["manager"].ToString();
					Info.MP = dr["MP"].ToString();
					Info.name = dr["name"].ToString();
					Info.phone = dr["phone"].ToString();
					Info.state = dr["state"].ToString();
					Info.type = dr["type"].ToString();
					Info.TZ = dr["TZ"].ToString();
					Info.zip = dr["zip"].ToString();

					Info.pos = dr["pos"].ToString();
					Info.pos_gate = dr["pos_gate"].ToString();
					Info.sensor = dr["sensor"].ToString();
					Info.sensor_gate = dr["sensor_gate"].ToString();
					Info.mim = dr["mim"].ToString();
					Info.mim_gate = dr["mim_gate"].ToString();
					Info.income = dr["income"].ToString();
					Info.rank = dr["rank"].ToString();

					Info.BAMS = dr["BAMS"].ToString();
					Info.SVS = dr["SVS"].ToString();
					Info.TID1 = dr["TID1"].ToString();
					Info.TID2 = dr["TID2"].ToString();
					Info.TID3 = dr["TID3"].ToString();
					Info.TID4 = dr["TID4"].ToString();
				}
				return true;
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
		}

		
		
		public static bool b_FillComputers()
		{
			try
			{
				foreach (System.Data.DataRow dr in SQL.dt_SelectComputers(Info.store).Rows)
				{
					Info.computers.Add(new Computer(dr["computer"].ToString().ToUpper()));
				}
				return true;
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
		}

		
		
		public static bool b_FillRecentCalls()
		{
			try { Info.recentCalls = SQL.dt_SelectRecentCalls(Info.store); return true; }
			catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
		}


		public static bool PlaceCerts(string Computer)
		{
			try
			{
				string Cert1 = @"\\wwwint\roc\IS-Share\Helpdesk\Retail Helpdesk\Software\global.cer";
				string Cert2 = @"\\wwwint\roc\IS-Share\Helpdesk\Retail Helpdesk\Software\verisign-root.cer";
				string Destination1 = string.Format(@"\\{0}\C$\Temp\global.cer", Computer);
				string Destination2 = string.Format(@"\\{0}\C$\Temp\verisign-root.cer", Computer);
				File.Copy(Cert1, Destination1, true);
				File.Copy(Cert2, Destination2, true);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			return true;
		}




        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="to">Recipients, seperated by a comma (,)</param>
        /// <param name="body">Body of message</param>
        /// <param name="subject">Subject of message</param>
        /// <returns>Pass/Fail</returns>
        public static bool b_SendEmail(string to, string body, string subject)
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

        /// <summary>
        /// Looks up the passed number in AD and returns the person's information.
        /// </summary>
        /// <param name="number">Phone number to lookup</param>
        /// <returns>(Department) FirstName LastName - Title</returns>
        public static string s_LookupPhoneNumber(string number)
        {
            try
            {
                //ldap
                //LDAP://OU=Retail Stores-BBB, OU=North America,OU=WWW,DC=wwwint,DC=corp"
                string ldapquery = "LDAP://DC=wwwint,DC=corp";
                string strFilter = "(&(objectCategory=user)(|(Mobile={0})(ipPhone={0})))";//"(&(objectCategory=user)(|(Mobile={0})(IP phone={1}))";
                List<LDAP.Result> result;
                if (number.Length > 7)
                {
                    //result = AD.SearchAD(ldapquery, strFilter, new string[] { "Mobile" });
                    number = string.Format("{0}{1}{0}{2}{0}{3}", "*", number.Substring(0, 3), number.Substring(3, 3), number.Substring(6));
                    result = AD.SearchAD(ldapquery, string.Format(strFilter, number));
                }
                else
                {
                    //result = AD.SearchAD(ldapquery, strFilter, new string[] { "IP phone" });
                    result = AD.SearchAD(ldapquery, string.Format(strFilter, number));
                }

                //survey says.... find me the info!!!!
                string firstname = (result.Find(e => e.Attribute.ToLower() == "givenName".ToLower())).Value;
                string lastname = (result.Find(e => e.Attribute.ToLower() == "sn".ToLower())).Value;
                string title = (result.Find(e => e.Attribute.ToLower() == "title".ToLower())).Value;
                string department = (result.Find(e => e.Attribute.ToLower() == "description".ToLower())).Value;

                return string.Format("({3}) {0} {1} - {2}", firstname, lastname, title, department);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Used for multiple extensions being involved, this will look them up in order and return the first one.
        /// </summary>
        /// <param name="numbers">Numbers to look up</param>
        /// <returns></returns>
        public static string s_LookupPhoneNumber(string[] numbers)
        {
            foreach (string number in numbers)
            {
                try
                {
                    //ldap
                    //LDAP://OU=Retail Stores-BBB, OU=North America,OU=WWW,DC=wwwint,DC=corp"
                    string ldapquery = "LDAP://DC=wwwint,DC=corp";
                    string strFilter = "(&(objectCategory=user)(|(Mobile={0})(ipPhone={0})))";//"(&(objectCategory=user)(|(Mobile={0})(IP phone={1}))";
                    List<LDAP.Result> result;
                    if (number.Length > 7)
                    {
                        string tmp = string.Empty;
                        //result = AD.SearchAD(ldapquery, strFilter, new string[] { "Mobile" });
                        tmp = string.Format("{0}{1}{0}{2}{0}{3}", "*", number.Substring(0, 3), number.Substring(3, 3), number.Substring(6));
                        result = AD.SearchAD(ldapquery, string.Format(strFilter, tmp));
                    }
                    else
                    {
                        //result = AD.SearchAD(ldapquery, strFilter, new string[] { "IP phone" });
                        result = AD.SearchAD(ldapquery, string.Format(strFilter, number));
                    }

                    //survey says.... find me the info!!!!
                    string firstname = (result.Find(e => e.Attribute.ToLower() == "givenName".ToLower())).Value;
                    string lastname = (result.Find(e => e.Attribute.ToLower() == "sn".ToLower())).Value;
                    string title = (result.Find(e => e.Attribute.ToLower() == "title".ToLower())).Value;
                    string department = (result.Find(e => e.Attribute.ToLower() == "description".ToLower())).Value;

                    return string.Format("({3}) {0} {1} - {2}", firstname, lastname, title, department);
                }
                catch
                {
                    continue;
                }
            }
            return string.Empty;
        }

        public static bool b_SendEmail(string to, string body, string subject, FileInfo attachement)
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
                _msg.Attachments.Add(new System.Net.Mail.Attachment(attachement.Open(FileMode.Open, FileAccess.Read, FileShare.Read), attachement.Name));
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

        public static bool b_SendEmail(List<string> to, string body, string subject, List<FileInfo> attachement)
        {
            try
            {
                string from = Environment.UserName.ToString() + "@wwwinc.com";
                //System.Net.Mail.MailMessage _msg = new System.Net.Mail.MailMessage(from, to, subject, body);
                System.Net.Mail.MailMessage _msg = new System.Net.Mail.MailMessage();
                _msg.From = new System.Net.Mail.MailAddress(from);
                _msg.Subject = subject;
                _msg.Body = body;
                //_msg.To.Add(to);

                foreach (string _to in to)
                {
                    _msg.To.Add(_to);
                }

                //_msg.Attachments.Add(new System.Net.Mail.Attachment(attachement.Open(FileMode.Open, FileAccess.Read, FileShare.Read), attachement.Name));
                foreach (FileInfo _file in attachement)
                {
                    _msg.Attachments.Add(new System.Net.Mail.Attachment(_file.Open(FileMode.Open, FileAccess.Read, FileShare.Read), _file.Name));
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

    public class WrapUpInvokeEventArgs : EventArgs
    {
        public bool isAutoInvoke { get; private set; }

        public WrapUpInvokeEventArgs(bool autoInvoke)
        {
            isAutoInvoke = autoInvoke;
        }
    }
}

