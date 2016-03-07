using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtractEmployeeTables.Properties;
using LDAP;

namespace ExtractEmployeeTables
{
	class ExtractEmployeeTables
	{
		static void Main(string[] args)
		{
			string start = DateTime.Now.ToString();
			Console.WriteLine("Job started at: " + start);
			if(!System.IO.Directory.Exists(@"C:\temp\emp_extract\"))
			{
				System.IO.Directory.CreateDirectory(@"C:\temp\emp_extract\");
			}
			Console.WriteLine(" * Loading computers from AD...");

			// Filter results by Object category of Computer and Name and exclude
			string ADSearchFilter =
				string.Format("(&(objectCategory={0})(&({1}=*SAP1*)(!({1}=*SAPQ*))))",
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


			/* ============================================================================================================= */

			ProgressBar progressBar;

			//test
			//searchResults.Clear();
			//searchResults.Add(new Result("","aven4769sap1"));
			//searchResults.Add(new Result("","west0787sap1b"));

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

					if (Functions.CheckNetwork(prop.Value))
					{
						string a = string.Format(@"-r:{0} bcp backoff..employee OUT c:\temp\emp_extract.txt -w -T", prop.Value);
						Functions.ExecuteCommand("winrs", a, false, true);
						Functions.CopyEmpExtract(prop.Value);
					}
				}
				progressBar.Completed();
			}

			Console.WriteLine();
			Console.WriteLine("Creating master output file: all_stores_emp_extract.txt");

			using (var output = System.IO.File.Create(@"C:\temp\all_stores_emp_extract.txt"))
			{
				System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"C:\temp\emp_extract\");
				foreach (System.IO.FileInfo file in dir.GetFiles())
				{
					using (var input = System.IO.File.OpenRead(file.FullName))
					{
						input.CopyTo(output);
					}
				}
			}
				

			//Console.WriteLine("Paused.....");
			//Console.ReadKey();

			/* ============================================================================================================= */

			string body = "Attached is all the store employees";


			Console.Write("\n * Sending email : ");

			if (Functions.SendMail(Settings.Default.from, Settings.Default.to, Settings.Default.subject, body, @"C:\temp\all_stores_emp_extract.txt"))
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
			Console.WriteLine("Cleaning up");

			System.IO.DirectoryInfo dirs = new System.IO.DirectoryInfo(@"C:\temp\emp_extract\");
			foreach (System.IO.FileInfo file in dirs.GetFiles())
			{
				System.IO.File.Delete(file.FullName);
			}
        }
	}
}
