using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_HD
{
    class ServiceWorker
    {
        /// <summary>
        /// Name of the computer
        /// </summary>
        public string Computer { get; private set; }
        public string Service { get; private set; }
        public string Action { get; private set; }
        public string Output { get; private set; }

        public event EventHandler WorkDone;
        private System.ComponentModel.BackgroundWorker bgw = new System.ComponentModel.BackgroundWorker();

        public ServiceWorker(string computer, string service, string action)
        {
            Computer = computer;
            Service = service;
            Action = action;
            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            bgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_ProgressChanged);
        }
        public void Start()
        {
            bgw.RunWorkerAsync();
        }

        void bgw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string args = string.Format("-r:{0} {1} {2}", Computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, Action + " " + Service);

            if (!Shared.Functions.CopyFileRemote(Computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices))
            {
                Output = string.Format("Failed to copy services.bat to {0}", Computer);
            }
            else
            {
                if (Service == "verifone" && !Shared.Functions.CopyArgsXML(Computer))
                {
                    Output = string.Format("Failed to copy args.xml to {0}", Computer);
                }
                else
                {
                    Shared.Functions.ExecuteCommand("WINRS", args, false, true);
                    Output = string.Format("Completed - services.bat {0} {1} on {2}", Action, Service, Computer);
                }
            }

        }

        void bgw_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ;
        }

        public void bgw_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (WorkDone != null) { WorkDone(this, e); }
        }
    }
}
