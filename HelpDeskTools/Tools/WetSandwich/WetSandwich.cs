using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LDAP;
using WetSandwich.Properties;

namespace WetSandwich
{
	class WetSandwich
	{
		static void Main(string[] args)
		{
			string year = DateTime.Today.Year.ToString();
			string month = DateTime.Today.Month.ToString();
			if (month.Length < 2) { month = 0 + month; }
			string day = DateTime.Today.Day.ToString();
			if (day.Length < 2) { day = 0 + day; }

			string dateString = year + month + day;

			//string computer = "rock0711sap1";
			//Console.WriteLine(Functions.CheckNetwork(computer));
			//Console.WriteLine(Functions.checkMultiVersion(computer,dateString));
			//Console.WriteLine(Functions.checkRIBrokerVersion(computer));
			//Console.ReadKey();
			//Environment.Exit(0);

			List<string> exclusions = Shared.Functions.GetIgnoreList(args);

			string[] exclude = Settings.Default.ignore.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

			exclusions.AddRange(Shared.Functions.GetIgnoreList(exclude));

			// Filter results by Object category of Computer and Name and exclude
			string ADSearchFilter =
				string.Format("(&(objectCategory={0})(&({1}=*SAP*)(!({1}=*SAPQ*))))",
				ObjectClasses.Computer,
				ObjectAttribute.ComputerName);

			LDAP.OU ou = LDAP.RetailOUs.All;

			List<Result> searchResults = AD.SearchAD(ou.ComputerOU, ADSearchFilter, LDAP.ObjectAttribute.ComputerName);
			Console.WriteLine(searchResults.Count());

			searchResults.Sort((x, y) => x.Value.CompareTo(y.Value));

			// Removes exclusions
			foreach (string excluded in exclusions)
			{
				searchResults.RemoveAll(x => x.Value.Contains(excluded));
			}

			/* ============================================================================================================= */

			string body = global::WetSandwich.Properties.Settings.Default.header;
			string mv = "";
			foreach(string v in Settings.Default._multiVersions) { mv = v + " " + mv; }
			string rv = "";
			foreach(string v in Settings.Default._vfVersions) { rv = v + " " + rv; }

			body += "Multi Version: " + mv + "<br>";
			body += "Rediron Version: " + Settings.Default.redIronVersion + "<br>";
			body += "Verifone Version: " + rv + "<br>";
			body += Settings.Default.tableHead;

			ProgressBar progressBar;


			if (System.Diagnostics.Debugger.IsAttached)
			{
				searchResults = new List<Result>();
				searchResults.Add(new Result("name", "whit1663sap2"));
				searchResults.Add(new Result("", "AUBU6118SAP1"));
			}


			// Progress bar
			if (searchResults.Count() > 0)
			{
				progressBar = new ProgressBar(
				   searchResults.Count(),
				   "Checking Logs",
				   " ");

				// List all items
				for (int i = 0; i < searchResults.Count(); i++)
				{
					// Update the progress bar
					progressBar.Update(i);

					string computer = searchResults[i].Value;
					if (!Shared.Functions.CheckNetwork(computer))
					{
						//body += string.Format(Settings.Default.body, computer, "N/A", "N/A", "Connection Unavailable");
						continue;
					}
					else
					{
						string multi;
						if (!Shared.Functions.CopyTempLog(Shared.Functions.LatestMulti(string.Format(@"\\{0}\c$\MerchantConnectMulti\log\", computer)))) { multi = "Unable to read multi log"; }
						else { multi = Shared.Functions.MultiLog(Settings.Default._multiVersions).ToString(); }
						Console.WriteLine(multi);

						string ri;
						if(!Shared.Functions.CopyTempLog(string.Format(@"\\{0}\c$\Program Files\RedIron Technologies\RedIron Broker\2Authorize.log", computer))) { ri = "Unable to read ri log";  }
						else { ri = Shared.Functions.FindInLog(Properties.Settings.Default.redIronVersion).ToString(); }
						Console.WriteLine(ri);

						string vf;
                        vf = Shared.Functions.VFLog(computer, Properties.Settings.Default._vfVersions);

						Console.WriteLine(vf);

						if ( ri.ToUpper() == "FALSE" || multi.ToUpper() == "FALSE" || vf.ToUpper() == "FALSE") { body += string.Format(Settings.Default.body, computer, multi, ri, vf, ""); }
					}
				}

				

				progressBar.Completed();
			}
			// append closing HTML to message
			body += Settings.Default.footer;
			body += DateTime.Now.ToString();
			/* ============================================================================================================= */

			if(System.Diagnostics.Debugger.IsAttached)
			{
				Console.ReadKey();
			}

			Console.Write("\n * Sending email : ");

			if (Shared.Functions.SendMail(Settings.Default.from, Settings.Default.to, Settings.Default.subject, body, true))
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
			//Console.ReadKey();
		}
	}
}
