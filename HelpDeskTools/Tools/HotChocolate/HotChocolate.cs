﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using LDAP;

namespace HotChocolate
{
    class DisableStartupRepair
    {
        static void Main(string[] args)
        {
            Shared.Functions.WriteFile(Shared.GlobalResources.batServices, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices);
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
            if (Debugger.IsAttached)
            {
                searchResults.Clear();
                searchResults.Add(new Result("", "para4975sap1"));
            }
            if (searchResults.Count() > 0)
            {
                for (int i = 0; i < searchResults.Count(); i++)
                {
                    string computer = searchResults[i].Value;
                    string arg1 = string.Format("-r:{0} {1} {2}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, "refresh verifone");
                    if (Shared.Functions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices))
                    {
                        if (Shared.Functions.CopyArgsXML(computer))
                        {
                            Shared.Functions.ExecuteCommand("WINRS", arg1, true, false);
                        }
                    }
                }
            }
        }
    }
}
