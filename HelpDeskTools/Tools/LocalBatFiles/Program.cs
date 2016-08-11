using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalBatFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string start = DateTime.Now.ToString();
            Console.WriteLine(" * Job started at: {0}", start);

            // Create local temp dir
            //Shared.Functions.CreateTempFolder();
            //Shared.Functions.UpdateLocalBatFiles();

            Console.WriteLine(" * Loading computers from AD...");

            // Filter results by Object category of Computer and Name and exclude
            string ADSearchFilter =
                string.Format("(&(objectCategory={0})(&({1}=*SAP*)(!({1}=*SAPQ*))))",
                LDAP.ObjectClasses.Computer,
                LDAP.ObjectAttribute.ComputerName);

            // set the OU
            LDAP.OU ou = LDAP.RetailOUs.All;

            // search AD
            List<string> computers = AD.SearchAD(ou.ComputerOU, ADSearchFilter, LDAP.ObjectAttribute.ComputerName).ConvertAll(new Converter<LDAP.Result, string>(LDAP.Result.GetValue));

            // Sort list alphabetically
            computers.Sort((x, y) => x.CompareTo(y));

            // Removes exclusions
            foreach (string excluded in Properties.Settings.Default._IgnoreList)
            {
                computers.RemoveAll(x => x.Contains(excluded));
            }

            /* Testing stuff */
            //if (System.Diagnostics.Debugger.IsAttached)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.Write("press any key...");  Console.ReadKey();  Environment.Exit(0);
            //}

            /* ============================================================================================================= */

            string body = Properties.Settings.Default._EmailHeader;

            // add start time
            body += start + "<br>";

            if (Properties.Settings.Default._IgnoreList.Count > 0)
            {
                body += "Excluded Stores: ";
                foreach (string store in Properties.Settings.Default._IgnoreList)
                {
                    body += store + " ";
                }
            }
            body += Properties.Settings.Default._EmailTableHead;

            if (computers.Count() > 0)
            {
                // Set progress bar parameters
                ProgressBar progressBar = new ProgressBar(computers.Count(), "Updating Bat Files", " ");

                // List all items
                for (int i = 0; i < computers.Count(); i++)
                {
                    // Update the progress bar
                    progressBar.Update(i);
                    if (Shared.Functions.CheckNetwork(computers[i]))
                    {
                        //Console.Write(computers[i]);
                        if (!Shared.Functions.UpdateLocalBatFiles(computers[i]))
                        {
                            body += string.Format(Properties.Settings.Default._EmailTableRow, computers[i], "Failed to update files", "");
                        }
                        else { body += string.Format(Properties.Settings.Default._EmailTableRow, computers[i], "Files Updated", ""); }

                    }
                    else { body += string.Format(Properties.Settings.Default._EmailTableRow, computers[i], "Unable to ping", ""); }
                    if (System.Diagnostics.Debugger.IsAttached) { if (i > 40) { break; } }
                }

            }

            body += Properties.Settings.Default._EmailFooter;
            body += DateTime.Now.ToString();
            Console.Write("\n * Sending email : ");

            if (Shared.Functions.SendEmail(Properties.Settings.Default._To, body, Properties.Settings.Default._Subject))
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

            if (System.Diagnostics.Debugger.IsAttached) { Console.ReadKey(); }
            //progressBar.Completed();
        }
    }
}
