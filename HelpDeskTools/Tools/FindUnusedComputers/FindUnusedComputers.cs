using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using FindUnusedComputers.Properties;
using LDAP;

namespace FindUnusedComputers
{
	class FindUnusedComputers
	{
		static void Main(string[] args)
		{
#if DEBUG
			//Console.WriteLine("Found {0}: {1}", "rock0711sap1", Functions.CheckRemoteFile("rock0711sap1")); Console.ReadKey();
#endif	
			
			Console.WriteLine(" * Loading computers from AD...");

			// Load exclusions from cmd line
			List<string> exclusions = Functions.GetIgnoreList(args);
			// Load exclusions from settings
			exclusions.AddRange(
				Functions.GetIgnoreList(
					Settings.Default.ignore.Split(
						new string[] { "," },
						StringSplitOptions.RemoveEmptyEntries)));



			// Filter results by Object category of Computer and Name and exclude
			string ADSearchFilter =
				string.Format("(&(objectCategory={0})(&({1}=*SAP*)(!({1}=*SAPQ*))))",
				ObjectClasses.Computer,
				ObjectAttribute.ComputerName);

			// container for return values
			List<Result> searchResults = new List<Result>();

			// array of LDAP OUs
			OU[] OUs = { RetailOUs.Boston, RetailOUs.Michigan };

			// search each OU
			foreach (OU ou in OUs)
			{
				// Fill Result list with search results
				List<Result> tempResults = AD.SearchAD(ou.ComputerOU, ADSearchFilter, ObjectAttribute.ComputerName);

				// Iterate through store number range
				for (int i = ou.Lower; i < ou.Upper; i++)
				{
					// Search for store number as string in the list
					foreach (Result result in tempResults.FindAll(x => x.Value.Contains(i.ToString())))
					{
						// Add matches to search results list
						searchResults.Add(result);
					}
				}
			}

			// Sort list alphabetically
			searchResults.Sort((x, y) => x.Value.CompareTo(y.Value));


			// Removes exclusions
			foreach (string excluded in exclusions)
			{
				searchResults.RemoveAll(x => x.Value.Contains(excluded));
			}



			/* ============================================================================================================= */



			// Progress bar
			ProgressBar progressBar = new ProgressBar(
				searchResults.Count(),
				"1st Check",
				" ");

			// Container for stores who fail checks
			List<string> failed = new List<string>();

			// List all items
			for (int i = 0; i < searchResults.Count; i++)
			{
				// Update the progress bar
				progressBar.Update(i);

				if (!Functions.CheckRemoteFile(searchResults[i].Value)) 
				{
					failed.Add(searchResults[i].Value);
				}
				
			}

			failed.Sort((x, y) => x.CompareTo(y));

			progressBar.Completed();


			/* ============================================================================================================= */


			Console.WriteLine();

			// New instance of the progress bar
			progressBar = new ProgressBar(failed.Count(), "2nd Check", " ");

			// html message body
			string body = Settings.Default.header;

			// Check the second list
			for (int i = 0; i < failed.Count(); i++)
			{
				progressBar.Update(i);
				string computer = failed[i];

				// failed to ping
				if (!Functions.CheckRemoteFile(failed[i]))
				{
					body += string.Format(Settings.Default.body, failed[i], "");
				}
				
			}
			// end progress bar
			progressBar.Completed();

			// append closing HTML to message
			body += Settings.Default.footer;

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
		}


	}

}
