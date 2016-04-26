using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LDAP;

namespace FileSizeChecker4D_Bos
{
    class Program
    {
        static void Main(string[] args)
        {
            // initial info
            string start = DateTime.Now.ToString();
            Console.WriteLine(" * Job started at: {0}", start);


            Console.WriteLine(" * Loading computers from AD...");

            // array of excluded computers
            string[] exclusions = new string[] { };

            // Filter results by Object category of Computer and Name and exclude
            string ADSearchFilter =
                string.Format("(&(objectCategory={0})(&({1}=*SAP*)(!({1}=*SAPQ*))))",
                ObjectClasses.Computer,
                ObjectAttribute.ComputerName);

            // set the OU
            LDAP.OU ou = LDAP.RetailOUs.All;

            // search AD
            List<string> computers = AD.SearchAD(ou.ComputerOU, ADSearchFilter, LDAP.ObjectAttribute.ComputerName).ConvertAll(new Converter<Result, string>(LDAP.Result.GetValue));

            // Sort list alphabetically
            computers.Sort((x, y) => x.CompareTo(y));

            // Removes exclusions
            foreach (string excluded in exclusions)
            {
                computers.RemoveAll(x => x.Contains(excluded));
            }

            //if(System.Diagnostics.Debugger.IsAttached)
            //{
            //    computers.Clear();
            //    computers.Add("birm0827sap1a");
            //}

            /* ============================================================================================================= */
            string csvFile = "";

            if (computers.Count() > 0)
            {
                // Set progress bar parameters
                ProgressBar progressBar = new ProgressBar(computers.Count(), "Running", " ");

                // List all items
                for (int i = 0; i < computers.Count(); i++)
                {
                    // Update the progress bar
                    progressBar.Update(i);
                    if (Shared.Functions.CheckNetwork(computers[i]))
                    {
                        string file = string.Format(@"\\{0}\c$\Program Files\SAP\Retail Systems\Point of Sale\codes.bin", computers[i]);
                        string filesize = getFileSize(file);
                        csvFile += string.Format("{0}, {1} \n", computers[i], filesize);
                    }

                    if(System.Diagnostics.Debugger.IsAttached)
                    {
                        if(i>10)
                        {
                            break;
                        }
                    }
                }
                progressBar.Completed();

                if (!System.IO.Directory.Exists("C:\temp")) { System.IO.Directory.CreateDirectory("C:\temp"); }
                Shared.Functions.WriteFile(csvFile, @"c:\temp\filesizes.csv");

                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }

            }
        }

        static string getFileSize(string path)
        {
            try
            {
                return new System.IO.FileInfo(path).Length.ToString();
            }
            catch(Exception)
            {
                return "ERROR";
            }

        }

    }
}
