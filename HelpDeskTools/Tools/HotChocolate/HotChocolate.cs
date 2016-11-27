using System;
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
            List<Computer> computers = new List<Computer>();


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
                            computers.Add(new Computer(item.Value, sStore));
                        }
                    }
                }
            }
            if (Debugger.IsAttached && Properties.Settings.Default._debugUseTestComputers)
            {
                computers.Clear();
                computers.Add(new Computer("retailtest1a","9999"));
                computers.Add(new Computer("retailtest2","9999"));
            }
            if (computers.Count() > 0)
            {
                foreach (Computer computer in computers)
                {
                    
                    string arg1 = string.Format("-r:{0} {1} {2}", computer.Name, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, "refresh verifone");
                    if (Shared.Functions.CopyFileRemote(computer.Name, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices))
                    {
                        if (Shared.Functions.CopyArgsXML(computer.Name))
                        {
                            Shared.Functions.ExecuteCommand("WINRS", arg1, true, false);
                            MvVFQuueryLog(computer);
                        }
                    }
                }
            }
        }
        static bool MvVFQuueryLog(Computer c)
        {
            try
            {
                string Source = string.Format(@"\\{0}\C$\{1}", c.Name, @"Program Files\VeriFone\MX915\UpdateFiles\logfiles\vfquerylog.xml");

                if(c.Name== "retailtest1a") { c.Name = "ROCK9999sap1z"; }
                else if(c.Name== "retailtest2") { c.Name = "DETR8888sap2f"; }

                string Destination = string.Format(@"\\ROCHLD01\pinp\Serial_{0}_0{1}_vfquerylog.xml",c.Store,c.Name.Substring(11,1));

                System.IO.File.Copy(Source, Destination, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        private class Computer
        {
            public string Name { get; set; }
            public string Store { get; set; }

            public Computer() { new Computer(string.Empty, string.Empty); }
            public Computer(string name) { new Computer(name, string.Empty); }
            public Computer(string name, string store) { Name = name; Store = store; }
        } 
    }
    
}
