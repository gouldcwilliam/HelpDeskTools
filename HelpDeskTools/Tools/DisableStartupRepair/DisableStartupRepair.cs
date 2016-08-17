using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using LDAP;

namespace DisableStartupRepair
{
	class DisableStartupRepair
	{
		static void Main(string[] args)
		{

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

			if (searchResults.Count() > 0)
			{
				ProgressBar progressBar = new ProgressBar(searchResults.Count(), "DisableStartupRepair", " ");
				for (int i = 0; i < searchResults.Count(); i++)
				{
					progressBar.Update(i);
					string computer = searchResults[i].Value;

					ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.CreateNoWindow = true;
					startInfo.FileName = "WINRS";
					startInfo.Arguments = "-r:" + computer + " bcdedit /set {default} bootstatuspolicy ignoreallfailures && bcdedit /set {default} recoveryenabled No";
					Process process = Process.Start(startInfo);
                    process.WaitForExit();
				}
			}
		}
	}
}
