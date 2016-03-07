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
		/// <summary>
		/// Launches an instance of another program/executable
		/// </summary>
		/// <param name="ExecutableFile">Name of program or path to EXE</param>
		/// <param name="Arguments">Arguments given to the EXE</param>
		/// <param name="Interactive">Show the program running</param>
		/// <param name="Wait">Pause all other processing until process completes</param>
		/// <returns></returns>
		public static int ExecuteCommand(string ExecutableFile, string Arguments, bool Interactive, bool Wait)
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
		/// <summary>
		/// Launches an instance of another program/executable
		/// </summary>
		/// <param name="ExecutableFile">Name of program or path to EXE</param>
		/// <param name="Arguments">Arguments given to the EXE</param>
		/// <param name="Interactive">Show the program running</param>
		/// <param name="Title">Change the title of the program (only tested on batch files)</param>
		/// <param name="Wait">Pause all other processing until process completes</param>
		/// <returns></returns>
		public static int ExecuteCommand(string ExecutableFile, string Arguments, bool Interactive, string Title, bool Wait)
		{
			return ExecuteCommand("CMD", string.Format("/C TITLE {0} && {1} {2}", Title, ExecutableFile, Arguments), Interactive, Wait);
		}
		/// <summary>
		/// Launches an instance of another program/executable
		/// </summary>
		/// <param name="ExecutableFile">Name of program or path to EXE</param>
		/// <param name="Interactive">Show the program running</param>
		/// <returns></returns>
		public static int ExecuteCommand(string ExecutableFile, bool Interactive)
		{
			return ExecuteCommand(ExecutableFile, string.Empty, Interactive);
		}
		/// <summary>
		/// Launches an instance of another program/executable
		/// </summary>
		/// <param name="ExecutableFile">Name of program or path to EXE</param>
		/// <param name="Arguments">Arguments given to the EXE</param>
		/// <param name="Interactive">Show the program running</param>
		/// <returns></returns>
		public static int ExecuteCommand(string ExecutableFile, string Arguments, bool Interactive)
		{
			return ExecuteCommand(ExecutableFile, Arguments, Interactive, true);
		}


		/// <summary>
		/// Writes a string to a file
		/// </summary>
		/// <param name="Contents">Text to put in file</param>
		/// <param name="FileLocation">Location to write file to</param>
		/// <returns></returns>
		public static bool WriteFile(string Contents, string FileLocation)
		{
			try { File.WriteAllText(FileLocation, Contents); }
			catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
			return true;
		}

		/// <summary>
		/// Copies a local file to the same directory on a remote machine
		/// </summary>
		/// <param name="ComputerName">Name of remote machine</param>
		/// <param name="FileLocation">Location of file to copy</param>
		/// <returns></returns>
		public static bool CopyFileRemote(string ComputerName, string FileLocation)
		{
			try
			{
				string Destination = string.Format(@"\\{0}\C$\{1}", ComputerName, FileLocation.Substring(3));
				Console.WriteLine(Destination);
				File.Copy(FileLocation, Destination, true);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			return true;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ComputerName"></param>
        /// <returns></returns>
        public static bool CopyArgsXML(string ComputerName)
        {
            try
            {
                string Destination = string.Format(@"\\{0}\C$\Program Files\VeriFone\MX915\vfQueryUpdate\args.xml", ComputerName);
                Console.WriteLine(Destination);
                System.IO.File.Copy(Shared.Settings.Default._TempPath + "args.xml", Destination, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

		/// <summary>
		/// Runs my tool that updates our list of computers in SQL
		/// </summary>
        public static void UpdateComputersFromAD()
		{
			Process.Start(@".\UpdateComputerList.exe");
		}


		/// <summary>
		/// Opens an explorer window on the remote machines C:
		/// </summary>
		/// <param name="Computer">Name of remote machine</param>
		/// <param name="Suffix">Remote path to browse relative to C:</param>
		public static void BrowseComputer(string Computer, string Suffix)
		{
			if (!Shared.Functions.DnsLookup(Computer)) { return; }
			Suffix = Suffix.ToLower().Replace("c:", "");
			if (Suffix!="" && Suffix.Substring(0,1) !="\\") { Suffix = "\\" + Suffix; }
			Process explore = Process.Start("EXPLORER", string.Format(@"\\{0}\c${1}", Computer, Suffix));
		}
		/// <summary>
		/// Opens an explorer window on the remote machines C:
		/// </summary>
		/// <param name="Computer">Name of remote machine</param>
		public static void BrowseComputer(string Computer)
		{
			BrowseComputer(Computer, "");
		}
		/// <summary>
		/// Opens an explorer window on the remote machines C:
		/// </summary>
		/// <param name="Computers">List of Computers to browse</param>
		public static void BrowseComputer(List<Computer> Computers)
		{
			foreach (Computer Computer in Computers)
			{
				BrowseComputer(Computer.name);
			}
		}
		/// <summary>
		/// Opens an explorer window on the remote machines C:
		/// </summary>
		/// <param name="Computers">List of strings to browse</param>
		public static void BrowseComputer(List<string>Computers)
		{
			foreach (string computer in Computers)
			{
				BrowseComputer(computer);
			}
		}


		public static void ConnectWithDW(string computer)
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
           // System.Threading.Thread.Sleep(2500);
            Console.WriteLine("Launched DameWare on: " + computer);
        }
        public static void ConnectWithDW(Computer computer)
        {
            ConnectWithDW(computer.name);
        }
        public static void ConnectWithDW(List<Computer> SelectedComputers)
        {
            foreach(Computer computer in SelectedComputers)
            {
                ConnectWithDW(computer.name);
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
			startInfo.FileName = Shared.Settings.Default._TempPath + "PSEXEC";
			startInfo.Arguments = string.Format(@"\\{0} -s -d -i {1}", computer, Shared.Settings.Default._TempPath+Shared.Settings.Default._BatEndpoint);
			Process process = Process.Start(startInfo);
		}

		public static void v_LocalCMD(string computer)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = Shared.Settings.Default._TempPath + "PSEXEC";
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
			startInfo.FileName = Shared.Settings.Default._TempPath + "PSEXEC";
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

		public static bool CopyTempLog(string pathToLog)
		{
			try
			{
				File.Copy(pathToLog, @"C:\temp\tmp.log", true);
				return true;
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
		}
		public static bool CopyTempLog(string pathToLog, string destination)
		{
			try
			{

				File.Copy(pathToLog, destination, true);
				return true;
			}
			catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
		}

		public static bool FindInLog(string searchString)
		{
			try
			{
				return File.ReadAllText(@"C:\temp\tmp.log").Contains(searchString);
			}
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

