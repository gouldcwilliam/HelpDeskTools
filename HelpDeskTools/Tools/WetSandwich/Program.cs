using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LDAP;
using WetSandwich.Properties;

namespace WetSandwich
{
	class Program
	{
		static void Main(string[] args)
		{
			string year = DateTime.Today.Year.ToString();
			string month = DateTime.Today.Month.ToString();
			if (month.Length < 2) { month = 0 + month; }
			string day = (DateTime.Today.Day - 1).ToString();
			if (day.Length < 2) { day = 0 + day; }

			string dateString = year + month + day;

			//string computer = "rock0711sap1";
			//Console.WriteLine(Functions.CheckNetwork(computer));
			//Console.WriteLine(Functions.checkMultiVersion(computer,dateString));
			//Console.WriteLine(Functions.checkRIBrokerVersion(computer));
			//Console.ReadKey();
			//Environment.Exit(0);

			// Filter results by Object category of Computer and Name and exclude
			string ADSearchFilter =
				string.Format("(&(objectCategory={0})(&({1}=*SAP*)(!({1}=*SAPQ*))))",
				ObjectClasses.Computer,
				ObjectAttribute.ComputerName);

			// container for return values
			List<Result> searchResults = new List<Result>();


			LDAP.OU ou = LDAP.RetailOUs.All;


			string sStore = "";

			List<LDAP.Result> tempResults = AD.SearchAD(ou.ComputerOU, ADSearchFilter, LDAP.ObjectAttribute.ComputerName);

			if (tempResults != null)
			{
				if (tempResults.Count > 0)
				{
					for (int i = ou.Lower; i < ou.Upper + 1; i++)
					{
						sStore = i.ToString();

						while (sStore.Length < 4) { sStore = "0" + sStore; }

						foreach (LDAP.Result item in tempResults.FindAll(x => x.Value.Contains(sStore)))
						{
							searchResults.Add(item);
						}
					}
				}
			}

			// Sort list alphabetically
			searchResults.Sort((x, y) => x.Value.CompareTo(y.Value));

			/* ============================================================================================================= */

			string body = WetSandwich.Properties.Settings.Default.header;

			body += Settings.Default.tableHead;

			ProgressBar progressBar;

			//searchResults = new List<Result>();
			//searchResults.Add(new Result("name", "whit1663sap2"));
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
					if (!Functions.CheckNetwork(computer))
					{
						//body += string.Format(Settings.Default.body, computer, "N/A", "N/A", "Connection Unavailable");
						continue;
					}
					else
					{
						string multi;
						if(!Functions.CopyTempLog(string.Format(@"\\{0}\c$\MerchantConnectMulti\log\multi_{1}.log", computer, dateString))) { multi = "Unable to read log"; }
						else { multi = Functions.FindInLog("4.2.12.139").ToString(); }

						string ri;
						if(!Functions.CopyTempLog(string.Format(@"\\{0}\c$\Program Files\RedIron Technologies\RedIron Broker\2Authorize.log", computer))) { ri = "Unable to read log"; }
						else { ri = Functions.FindInLog("2.0.0.926").ToString(); }

						if( ri.ToUpper() == "FALSE" || multi.ToUpper() == "FALSE") { body += string.Format(Settings.Default.body, computer, multi, ri, ""); }
					}
				}

				

				progressBar.Completed();
			}
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
			//Console.ReadKey();
		}
	}
}
