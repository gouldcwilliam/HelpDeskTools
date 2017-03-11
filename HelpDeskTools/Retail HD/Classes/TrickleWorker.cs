using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_HD
{
    class TrickleWorker
    {
        /// <summary>
        /// Name of the computer
        /// </summary>
        public string Computer { get; private set; }
        public bool ServiceBGWLaunch { get; private set; }
        public string Output { get; private set; }

        public string Exec { get; private set; }
        public string Args { get; private set; }
        public event EventHandler OutputUpdate;
        private System.ComponentModel.BackgroundWorker bgw = new System.ComponentModel.BackgroundWorker();



        public TrickleWorker(string computer, string service, string action, bool overwrite = true)
        {
            Computer = computer;
            ServiceBGWLaunch = overwrite;
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
            Output = string.Format("Copying services.bat to {0}", Computer);
            if (OutputUpdate != null) { OutputUpdate(this, e); }

            if (!Shared.Functions.CopyServicesBatFile(Computer))
            {
                Output = string.Format("Failed to copy services.bat to {0}", Computer);
                return;
            }
            if (!Shared.Functions.CopyArgsXML(Computer))
            {
                Output = string.Format("Failed to copy args.xml to {0}", Computer);
                return;
            }

            Output = string.Format("Copied services.bat to {0}", Computer);
        }

        void bgw_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ;
        }

        public void bgw_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (OutputUpdate != null) { OutputUpdate(this, e); }
            if(ServiceBGWLaunch)
            {
                ServiceWorker swTransnetRestart = new ServiceWorker(Computer, "transnet", "restart", false);
                swTransnetRestart.OutputUpdate += ServiceWorker_OutputUpdate;
                swTransnetRestart.Start();

                ServiceWorker swSQLRestart = new ServiceWorker(Computer, "sql", "restart", false);
                swSQLRestart.OutputUpdate += ServiceWorker_OutputUpdate;
                swSQLRestart.Start();
            }

        }

        private void ServiceWorker_OutputUpdate(object sender, EventArgs e)
        {
            Output = ((TrickleWorker)sender).Output;
            if (OutputUpdate != null) { OutputUpdate(this, e); }
        }
    }
}
