using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LDAP;
using EReceiptMonitor.Properties;

namespace EReceiptMonitor
{
	class EReceiptMonitor
	{
		static void Main(string[] args)
		{
			Console.WriteLine(" * Loading computers from AD...");

			List<string> exclusions = Functions.GetIgnoreList(args);
			
			string[] exclude = Settings.Default.ignore.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

			exclusions.AddRange(Functions.GetIgnoreList(exclude));

			if (Settings.Default.path.ToUpper().Contains(@"C:\"))
			{
				Settings.Default.path = Settings.Default.path.ToUpper().Replace(@"C:\", "");
			}

			// Filter results by Object category of Computer and Name and exclude
			string ADSearchFilter = 
				string.Format("(&(objectCategory={0})(&({1}=*SAP*)(!({1}=*SAPQ*))))", 
				ObjectClasses.Computer, 
				ObjectAttribute.ComputerName);

			// container for return values
			List<Result> searchResults = new List<Result>();

			List<OU> OUs = new List<OU>(); 

			// array of LDAP OUs
			if (Settings.Default.includeBoston)
			{
				OUs.Add(RetailOUs.Boston);
			}
			if (Settings.Default.includeMichigan)
			{
				OUs.Add(RetailOUs.Michigan);
			}

			// search each OU
			foreach (OU ou in OUs)
			{
				// Fill Result list with search results
				List<Result> tempResults = AD.SearchAD(ou.ComputerOU, ADSearchFilter, ObjectAttribute.ComputerName);

				// Canada
				if (ou.BaseOU == RetailOUs.Boston.BaseOU)
				{
					for (int i = 400; i < 499; i++)
					{
						// Search for store number as string in the list
						foreach (Result result in tempResults.FindAll(x => x.Value.Contains("0"+i.ToString())))
						{
							// Add matches to search results list
							searchResults.Add(result);
						}
					}
				}

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
			foreach(string excluded in exclusions)
			{
				searchResults.RemoveAll(x => x.Value.Contains(excluded));
			}



			/* ============================================================================================================= */


			// count of files exceding limit
			int c = 0;

			// html message body
			string body = Settings.Default.header;

			if (exclude.Count() > 0)
			{
				body += "Excluded Stores: ";
				foreach (string store in exclude)
				{
					body += store + " ";
				}
			}
			body += Settings.Default.tableHead;

			// Progress bar
			ProgressBar progressBar = new ProgressBar(
				searchResults.Count(),
				"Checking Files",
				" ");

			// List all items
			for (int i = 0; i < searchResults.Count; i++)
			{
				// Update the progress bar
				progressBar.Update(i);

				string computer = searchResults[i].Value;

				long size = 0;
				string message = string.Empty;


				foreach (string file in Settings.Default.files)
				{
					size = Functions.CheckFileSize(Settings.Default.path + file, computer);
					if (size > Settings.Default.sizeBytes)
					{
						//file is wrong size
						body += string.Format(Settings.Default.body, computer, "File: " + file + " size: " + (size / 1024).ToString() + "." + (size % 1024).ToString() + "K", " ");
						c++;
					}
				}

			}

			progressBar.Completed();
			
			// append closing HTML to message
			body += Settings.Default.footer;

			/* ============================================================================================================= */

			if (c > 0)
			{
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
}
