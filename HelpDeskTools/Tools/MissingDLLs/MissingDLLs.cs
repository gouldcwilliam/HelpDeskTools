﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using MissingDLLs.Properties;
using LDAP;

namespace MissingDLLs
{
	class MissingDLLs
	{
		static void Main(string[] args)
		{
			Console.WriteLine(" * Loading computers from AD...");

			List<string> exclusions = Functions.GetIgnoreList(args);

			string[] exclude = Settings.Default.ignore.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

			exclusions.AddRange(Functions.GetIgnoreList(exclude));


			// Filter results by Object category of Computer and Name and exclude
			string ADSearchFilter =
				string.Format("(&(objectCategory={0})(&({1}=*SAP1*)(!({1}=*SAPQ*))))",
				ObjectClasses.Computer,
				ObjectAttribute.ComputerName);

			// container for return values
			List<Result> searchResults = new List<Result>();

            LDAP.OU ou = LDAP.RetailOUs.All;

            string sn = "";

            List<LDAP.Result> tempResults = AD.SearchAD(ou.ComputerOU, ADSearchFilter, LDAP.ObjectAttribute.ComputerName);

            if (tempResults != null)
            {
                if (tempResults.Count > 0)
                {
                    for (int i = ou.Lower; i < ou.Upper + 1; i++)
                    {
                        sn = i.ToString();

                        while (sn.Length < 4) { sn = "0" + sn; }

                        foreach (LDAP.Result item in tempResults.FindAll(x => x.Value.Contains(sn)))
                        {
                            searchResults.Add(item);
                        }
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


			Console.WriteLine();

			// New instance of the progress bar
			ProgressBar progressBar = new ProgressBar(
				searchResults.Count(),
				"1st Check",
				" ");

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

			// Check the second list
			for (int i = 0; i < searchResults.Count(); i++)
			{
				// Update progress
				progressBar.Update(i);

				string computer = searchResults[i].Value;
			
				bool passed = false;
				string message = string.Empty;		// Message to print

				// failed to ping
				if (!Functions.CheckNetwork(computer))
				{
					body += string.Format(Settings.Default.body, computer, "Unable to ping register" , " ");
				}
				else
				{
					// check files
					if (Functions.CheckDLL(computer, out passed))
					{
						// trx count exceeds threshold
						if (!passed)
						{
							body += string.Format(Settings.Default.body, computer, "Missing atl71.dll", "Replaced ");
						}
					}
					// fails to check files
					else
					{
						body += string.Format(Settings.Default.body, computer, "Directory is unreachable", " ");
					}
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
