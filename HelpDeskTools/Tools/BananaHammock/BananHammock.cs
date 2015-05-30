using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using BananaHammock.Properties;
using LDAP;

namespace BananaHammock
{
	class BananaHammock
	{
		static void Main(string[] args)
		{
			string start = DateTime.Now.ToString();
			Console.WriteLine(" * Job started at: " + start);


			List<string> listOfStores = new List<string>();

			listOfStores = Functions.GetComputerList(args);

			if (listOfStores.Count == 0)
			{
				Console.WriteLine("\n * Loading computers from AD...");

				// Filter results by Object category of Computer and Name and exclude
				string ADSearchFilter =
					string.Format("(&(objectCategory={0})(&({1}=*SAP1*)(!({1}=*SAPQ*))))",
					ObjectClasses.Computer,
					ObjectAttribute.ComputerName);

				List<Result> retail = AD.SearchAD(LDAP.RetailOUs.All.ComputerOU, ADSearchFilter, ObjectAttribute.ComputerName);
				foreach (Result item in retail)
				{
					listOfStores.Add(item.Value);
				}

				// Sort list alphabetically
				listOfStores.Sort((x, y) => x.ToString().CompareTo(y.ToString()));

			}



			/* ============================================================================================================= */

			ProgressBar progressBar;
			// html message body
			string body = Settings.Default.header;
			body += Settings.Default.tableHead;

			// Progress bar
			if (listOfStores.Count() == 0) { return; }

			progressBar = new ProgressBar(listOfStores.Count(), "Something Something Banana", " ");
			string message;

			for (int i = 0; i < listOfStores.Count(); i++)
			{
				progressBar.Update(i);
				message = string.Empty;

				if (!Functions.CheckNetwork(listOfStores[i])) { body += string.Format(Settings.Default.body, listOfStores[i], "1: Unable to ping register", " "); }
				else
				{
					if (!Functions.PlaceCerts(listOfStores[i])) { body += string.Format(Settings.Default.body, listOfStores[i], "1: Unable to copy Certs", " "); }
					else
					{
						if (!Functions.WriteFile(Resources.batCerts)) { body += string.Format(Settings.Default.body, listOfStores[i], "1: Error writing file", " "); }
						else
						{
							if (!Functions.CopyFile(listOfStores[i])) { body += string.Format(Settings.Default.body, listOfStores[i], "1: Error copying file", " "); }
							else
							{
								string a = string.Format(@"\\{0} {1}", listOfStores[i], Shared.Settings.Default._TempFile);
								Functions.i_ExecuteCommand("PSEXEC", true, a, true);
							}
						}
					}
				}
			}
			progressBar.Completed();

			progressBar = new ProgressBar(60, "I like turtles", " ");
			for (int i = 0; i < 60; i++)
			{
				progressBar.Update(i);
				System.Threading.Thread.Sleep(50000);
			}
			progressBar.Completed();

			progressBar = new ProgressBar(listOfStores.Count(), "Derp Ferp and Sterf", " ");

			for (int i = 0; i < listOfStores.Count(); i++)
			{
				progressBar.Update(i);
				message = string.Empty;

				if (!Functions.CheckNetwork(listOfStores[i])) { body += string.Format(Settings.Default.body, listOfStores[i], "2: Unable to ping register", " "); }
				else
				{
					if (!Functions.WriteFile(Resources.batDascli)) { body += string.Format(Settings.Default.body, listOfStores[i], "2: Error writing file", " "); }
					else
					{
						if (!Functions.CopyFile(listOfStores[i])) { body += string.Format(Settings.Default.body, listOfStores[i], "2: Error copying file", " "); }
						else
						{
							string a = string.Format(@"\\{0} {1}", listOfStores[i], Shared.Settings.Default._TempFile);
							Functions.i_ExecuteCommand("PSEXEC", true, a, true);
						}
					}
				}
			}
			progressBar.Completed();

			// append closing HTML to message
			body += Settings.Default.footer;
			body += DateTime.Now.ToString();
			/* ============================================================================================================= */


			Console.Write("\n * Sending email : ");

			if (Functions.SendMail(Settings.Default.from, Settings.Default.to, Settings.Default.subject, body, true))
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("Sent");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("Failed!");
			}
			Console.ResetColor();
			Console.WriteLine();
		}
	}
}
