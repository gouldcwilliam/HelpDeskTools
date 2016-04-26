using System;
using System.Collections.Generic;
using System.Linq;

using LDAP;


namespace RunOnAllStores
{
	class RunOnAllStores
	{
		static void Main(string[] args)
		{
			// initial info
			string start = DateTime.Now.ToString();
			Console.WriteLine(" * Job started at: {0}", start);

			// Create local temp dir
			Shared.Functions.CreateTempFolder(false);
			// Update wsadmin.bat
			Console.WriteLine(Shared.Functions.WriteFile(Shared.GlobalResources.batWSAdmin, Shared.Settings.Default._TempPath + Shared.Settings.Default._WSAdmin) ? " * Updated local version of " + Shared.Settings.Default._WSAdmin : " * Unable to update local version of " + Shared.Settings.Default._WSAdmin);

			Console.WriteLine(" * Loading computers from AD...");

			// determines the ad filter
			string registers = "";
			// path to file being executed
			string executable = "";
			// arguments to the executable
			string arguments = "";
			// array of excluded computers
			string[] exclusions = new string[] { };

			// Interpret command line arguments
			if (args.Length > 0 )
			{
				// Argument one determines All registers or just register 1
				if (args[0].ToLower() == "all") { registers = "SAP"; } else { registers = "SAP1"; }
				// argument two is the executable's path
				executable = args[1];
				// all other arguments are arguments to executable
				for (int i = 2; i < args.Length; i++)
				{
					if (arguments == "") { arguments = args[i]; }
					else { arguments = arguments + " " + args[i]; }
				}
				
			}
			// If command line args are wrong, exit and show usage
			else { Usage(); Environment.Exit(1); }

			// Filter results by Object category of Computer and Name and exclude
			string ADSearchFilter =
				string.Format("(&(objectCategory={0})(&({1}=*{2}*)(!({1}=*SAPQ*))))",
				ObjectClasses.Computer,
				ObjectAttribute.ComputerName,
				registers);

			// set the OU
			LDAP.OU ou = LDAP.RetailOUs.All;

			// search AD
			List<string> computers = AD.SearchAD(ou.ComputerOU, ADSearchFilter, LDAP.ObjectAttribute.ComputerName).ConvertAll(new Converter<Result,string>(LDAP.Result.GetValue));

			// Sort list alphabetically
			computers.Sort((x, y) => x.CompareTo(y));

			// Removes exclusions
			foreach (string excluded in exclusions)
			{
				computers.RemoveAll(x => x.Contains(excluded));
			}

            /* Testing stuff */
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Filter: {0}\n" +
                    "Computers: {1} | Executable: {2} | Arguments: {3}\n",
                    ADSearchFilter, computers.Count, executable, arguments);
            }

			/* ============================================================================================================= */

			if (computers.Count() > 0)
			{
				// Set progress bar parameters
				ProgressBar progressBar = new ProgressBar(computers.Count(), "Running", " ");

				// List all items
				for (int i = 0; i < computers.Count(); i++)
				{
					// Update the progress bar
					progressBar.Update(i);
					if(Shared.Functions.CheckNetwork(computers[i]))
					{
						if(Shared.Functions.CopyFileRemote(computers[i], executable, false))
						{
							string command = string.Format("-r:{0} {1} {2}", computers[i], executable, arguments);
							if (i != 0 && i % 20 == 0) { Shared.Functions.ExecuteCommand("WINRS", command, true, true); }
							else { Shared.Functions.ExecuteCommand("WINRS", command, true, false); }
						}

					}
				}
				Console.ReadKey();
				//progressBar.Completed();
			}
		}

		static void Usage()
		{
			Console.WriteLine(@"USAGE: RunOnAllStores [ALL/ONE] [Filename including C:\temp\ path]");
		}

	}
}
