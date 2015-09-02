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
			Process.Start(@".\UpdateComputerList.exe");
		}



		public static void v_BrowseComputer(List<Computer> SelectedComputers)
		{
			foreach (Computer computer in SelectedComputers)
			{
                if (!Shared.Functions.DnsLookup(computer.name)) { continue; }
				Process explore = Process.Start("EXPLORER", string.Format(@"\\{0}\c$", computer.name));
			}
		}
		public static void v_BrowseComputer(string Computer, string Suffix)
		{
			Process explore = Process.Start("EXPLORER", string.Format(@"\\{0}\c${1}", Computer, Suffix));
		}



		public static void v_ConnectWithAltiris(string computer)
		{
			if (!Shared.Functions.DnsLookup(computer)) { return; }
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
        public static void v_ConnectWithDW(string computer)
        {
            if (!Shared.Functions.DnsLookup(computer)) { return; }
            if (File.Exists(@"C:\Program Files (x86)\SolarWinds\DameWare Remote Support\dwrcc.exe"))
            {
                Process altiris = Process.Start(@"C:\Program Files (x86)\SolarWinds\DameWare Remote Support\dwrcc.exe", @"-c: -h: -a:1 -x: -m:" + computer);
            }
            else if (File.Exists(@"C:\Program Files\SolarWinds\DameWare Remote Support\dwrcc.exe"))
            {
                Process altiris = Process.Start(@"C:\Program Files\SolarWinds\DameWare Remote Support\dwrcc.exe", @"-c: -h: -a:1 -x: -m:" + computer);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Unable to launch DameWare Remote Control Center\nVerify that it is installed and using the default instalation path", "DameWare Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            System.Threading.Thread.Sleep(2500);
            Console.WriteLine("Launched DameWare on: " + computer);
        }
        public static void v_ConnectWithDW(Computer computer)
        {
            v_ConnectWithDW(computer.name);
        }
        public static void v_ConnectWithDW(List<Computer> SelectedComputers)
        {
            foreach(Computer computer in SelectedComputers)
            {
                v_ConnectWithDW(computer.name);
            }
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
				foreach (System.Data.DataRow dr in Shared.SQL.dt_SelectStore(Convert.ToInt32(Info.store)).Rows)
				{
                    Info.phone = dr["phone"].ToString();
                    Info.address = dr["address"].ToString();
                    Info.city = dr["city"].ToString();
                    Info.state = dr["state"].ToString();
                    Info.zip = dr["zip"].ToString();
                    Info.TZ = dr["TZ"].ToString();
                    Info.dm = dr["dm"].ToString();
                    Info.rm = dr["rm"].ToString();
					Info.manager = dr["manager"].ToString();
					Info.MP = dr["MP"].ToString();
					Info.name = dr["name"].ToString();
					Info.type = dr["type"].ToString();

                    Info._first = dr["1st"].ToString();
                    Info._second = dr["2nd"].ToString();
                    Info._third = dr["3rd"].ToString();

                    Info._lan1 = dr["lan1"].ToString();
                    Info._lan2 = dr["lan2"].ToString();
                    Info._lan3 = dr["lan3"].ToString();
                    Info._lan4 = dr["lan4"].ToString();

                    Info._gate1 = dr["gate1"].ToString();
                    Info._gate2 = dr["gate2"].ToString();
                    Info._gate3 = dr["gate3"].ToString();
                    Info._gate4 = dr["gate4"].ToString();

                    Info._cctv = dr["cctv"].ToString();

					Info.income = dr["income"].ToString();
					Info.rank = dr["rank"].ToString();

					Info.BAMS = dr["BAMS"].ToString();
					Info.SVS = dr["SVS"].ToString();
					Info.TID1 = dr["TID1"].ToString();
					Info.TID2 = dr["TID2"].ToString();
					Info.TID3 = dr["TID3"].ToString();
					Info.TID4 = dr["TID4"].ToString();

                    Info.open = (bool)dr["open"];
                    Info.pinpad = (bool)dr["pinpad"];
				}
			}
			catch (Exception ex) { Console.WriteLine("fillStoreInfo : Store Info query\n" + ex.Message + ex.InnerException); return false; }

            return true;
		}

		
		
		public static bool b_FillComputers()
		{
			try
			{
				foreach (System.Data.DataRow dr in Shared.SQL.dt_SelectComputers(Info.store).Rows)
				{
					Info.computers.Add(new Computer(dr["computer"].ToString().ToUpper()));
				}
				return true;
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
		}

		
		
		public static bool b_FillRecentCalls()
		{
			try { Info.recentCalls = Shared.SQL.dt_SelectRecentCalls(Info.store); return true; }
			catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
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

