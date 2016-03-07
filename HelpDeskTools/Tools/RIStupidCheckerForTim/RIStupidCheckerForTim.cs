using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RIStupidCheckerForTim.Properties;
using LDAP;

namespace RIStupidCheckerForTim
{
	class RIStupidCheckerForTim
	{
		static void Main(string[] args)
		{
			bool rename = false;
			foreach(string arg in args)
			{
				if (arg.ToUpper() == "RENAME") { rename = true; }
			}

			string start = DateTime.Now.ToString();
			Console.WriteLine("Job started at: " + start);
			Console.WriteLine(" * Loading computers from AD...");

			// Filter results by Object category of Computer and Name and exclude
			string ADSearchFilter =
				string.Format("(&(objectCategory={0})(&({1}=*SAP1*)(!({1}=*SAPQ*))))",
				ObjectClasses.Computer,
				ObjectAttribute.ComputerName);

			// container for return values
			List<string> searchResults = new List<string>();

			LDAP.OU ou = LDAP.RetailOUs.All;

			List<LDAP.Result> tempResults = AD.SearchAD(ou.ComputerOU, ADSearchFilter, LDAP.ObjectAttribute.ComputerName);

			searchResults = Functions.GetComputerList(Settings.Default.Stores.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries),tempResults);

			string body = Settings.Default.header;
			body += Settings.Default.tableHead;

			ProgressBar progressBar = new ProgressBar(
				   searchResults.Count(),
				   "Checking Ri Folder",
				   " ");

			if (searchResults.Count() > 0)
			{
				for (int i = 0; i < searchResults.Count(); i++)
				{
					progressBar.Update(i);
					string computer = searchResults[i];
					if (rename) { Functions.RenameFiles(computer); }
					body += string.Format(
						Settings.Default.body,
						computer,
						Functions.CountFiles(computer, "*.txn"),
						Functions.CountFiles(computer, "*.fail"),
						""
						);
					
				}
			}

			progressBar.Completed();

			body += Settings.Default.footer;
			body += DateTime.Now.ToString();

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

			
		}
	}
}
