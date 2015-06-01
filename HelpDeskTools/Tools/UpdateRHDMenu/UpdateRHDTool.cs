using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace UpdateRHDTool
{
	class UpdateRHDTool
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Closing the Retail HD Tool");
			foreach (Process p in Process.GetProcessesByName("Retail HD"))
			{
				p.Kill();
			}

			string sourcePath = UpdateRHDMenu.Properties.Settings.Default._sourcePath;
			string destPath = UpdateRHDMenu.Properties.Settings.Default._sourcePath;

			if (!Directory.Exists(destPath)) 
			{ 
				Console.WriteLine("Creating Directory: {0}", destPath);
				Directory.CreateDirectory(destPath);
			}

			if (Directory.Exists(sourcePath))
			{
				string[] files = Directory.GetFiles(sourcePath);
				Console.WriteLine("Copying {0} Files \n From: {1}\n To: {2}", files.GetLength(0), sourcePath, destPath);
				foreach (string file in files)
				{
					string filename = Path.GetFileName(file);
					if (filename.Contains("Retail HD.exe.config") ||
						filename.Contains("UpdateComputerList") ||
						filename.Contains(".pdb")
					){ continue; }
					Console.Write("===> {0}", filename);
					try 
					{
						File.Copy(file, Path.Combine(destPath, filename), true);
						Console.WriteLine(" ===> done");
					}
					catch(Exception)
					{ Console.WriteLine(" ===> failed"); }
				}
				//File.Copy(sourcePath + @"\Resources", destPath, true);
			}
			else
			{
				Console.WriteLine("{0} not found!", sourcePath);
			}

			if (args.GetLength(0) > 0)
			{
				if (args[0] == "restart")
				{
					ProcessStartInfo startInfo = new ProcessStartInfo();
					startInfo.FileName = destPath + @"\Retail HD.exe";
					startInfo.CreateNoWindow = false;
					startInfo.UseShellExecute = true;
					Process process = Process.Start(startInfo);
				}
			}

			Console.Write("Press any key..."); Console.ReadKey();
		}
	}
}
