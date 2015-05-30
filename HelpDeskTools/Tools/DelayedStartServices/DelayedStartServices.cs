using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Management;
using System.Diagnostics;
using System.IO;
using DelayedStartServices.Properties;

namespace DelayedStartServices
{
	class DelayedStartServices
	{
		static int exitCode = -1;
		static string Computer = "";

		static void Main(string[] args)
		{
			// Get the computer's name from cmd line
			if (args.Count() > 0)
			{
				Computer = args[0].Trim();
				Console.WriteLine("Computer: {0}", Computer);
			}
			else
			{
				// Gets the computer's name from input
				do
				{
					Console.WriteLine("Enter the name of the computer to start SQL on");
					Console.Write("Computer: ");
					Computer = Console.ReadLine().Trim();
				} while (Computer == "");
			}

			// Write the batch file locally
			try { File.WriteAllText(Settings.Default._TempFile, Resources.batServices); }
			catch (Exception ex)
			{
				Console.WriteLine("Writing Temp File {0}", ex.Message);
				Environment.Exit(1);
			}

			// Get the process start info ready
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = "WINRS";
			startInfo.Arguments = string.Format("-r:{0} {1} {2}", Computer, Settings.Default._TempFile, "start sql");
			startInfo.CreateNoWindow = false;
			startInfo.UseShellExecute = true;

			// Remote network path
			string networkPath = string.Format(@"\\{0}\C$\{1}", Computer, Settings.Default._TempFile.Substring(2));

			// Time information displayed to the user
			int min = (Settings.Default._DelayInMiliseconds / 1000) / 60;
			int sec = (Settings.Default._DelayInMiliseconds / 1000) % 60;


			for (int attempt = 1; attempt < Settings.Default._Retries + 1; attempt++)
			{
				// if last itteration success exit5
				if (exitCode == 0) { continue; }

				Console.WriteLine("Waiting {0} mins & {1} secs before attempt {2} of {3}", min, sec, attempt, Settings.Default._Retries);
				System.Threading.Thread.Sleep(Settings.Default._DelayInMiliseconds);

				// Copy batch file to remote computer
				try { File.Copy(Settings.Default._TempFile, networkPath, true); }
				catch (Exception ex)
				{
					Console.WriteLine("Copying Temp File {0}", ex.Message);
					continue;
				}

				// Runs the remote process
				Process process = Process.Start(startInfo);
				process.WaitForExit();
				exitCode = process.ExitCode;

			}
			Console.WriteLine("The program ended with exit code: {0}", exitCode);
			Console.Write("Press any key.... ");
			Console.ReadKey();
	
		}
	}
}
