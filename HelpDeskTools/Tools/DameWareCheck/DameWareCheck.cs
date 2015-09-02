using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LDAP;
using DameWareCheck.Properties;

namespace DameWareCheck
{
    class DameWareCheck
    {
		static void Main(string[] args)
		{
			string start = DateTime.Now.ToString();
			Console.WriteLine("Job started at: " + start);
			Console.WriteLine(" * Loading computers from AD...");


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

			ProgressBar progressBar;

			List<string> failed = new List<string>();


			// Progress bar
			if (searchResults.Count() > 0)
			{
				 progressBar = new ProgressBar(
					searchResults.Count(),
					"1st Check",
					" ");




				// List all items
				for (int i = 0; i < searchResults.Count(); i++)
				{
					// Update the progress bar
					progressBar.Update(i);

					Result prop = searchResults[i];

					string message = string.Empty;

					if (!Functions.CheckNetwork(prop.Value))
					{
						failed.Add(prop.Value);
					}
					else
					{
						if(!Functions.FindDameWare(prop.Value))
                        {
                            failed.Add(prop.Value);
                        }
					}
				}

				failed.Sort((x, y) => x.CompareTo(y));

				progressBar.Completed();
			}

			/* ============================================================================================================= */

			Console.WriteLine();

			// html message body
			string body = Settings.Default.header;
			
			// add start time
			body += start + "<br>";



			body += Settings.Default.tableHead;

			if (failed.Count > 0)
			{
				// New instance of the progress bar
				progressBar = new ProgressBar(failed.Count(), "2nd Check", " ");

				// Check the second list
				for (int i = 0; i < failed.Count(); i++)
				{
					// Update progress
					progressBar.Update(i);

					string computer = failed[i];

					string message = string.Empty;		// Message to print

					// failed to ping
					if (!Functions.CheckNetwork(computer))
					{
						body += string.Format(Settings.Default.body, computer, "Unable to ping register", " ");
					}
					else
					{
						// check files
						if (!Functions.FindDameWare(computer))
						{
                            body += string.Format(Settings.Default.body, computer, "Dameware not found", " ");
						}

					}
				}
				// end progress bar
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
		}


	}
}
