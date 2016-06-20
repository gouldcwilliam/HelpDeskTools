using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_HD
{
    class LogCheck
    {
        /// <summary>
        /// Name of the computer
        /// </summary>
        public string Computer { get; private set; }
        public string Output { get; private set; }

        public event EventHandler WorkDone;
        private System.ComponentModel.BackgroundWorker bgw = new System.ComponentModel.BackgroundWorker();


        /// <summary>
        /// Creates a new instance of LogCheck and sets the Computer property
        /// </summary>
        /// <param name="computer"></param>
        public LogCheck(string computer)
        {
            Computer=computer;
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
            string multi;
            string multiLog = string.Format(@"\\{0}\c$\MerchantConnectMulti\log\", Computer);
            string tmpMultiLog = string.Format("{0}{1}-mult.log", Shared.Settings.Default._TempPath, Computer);

            if (!Shared.Functions.CopyTempLog(Shared.Functions.LatestMulti(multiLog), tmpMultiLog))
            {
                multi = "Unable to read multi log";
            }
            else
            {
                multi = Shared.Functions.FindInLog(Properties.Settings.Default.multiVersion, tmpMultiLog).ToString();
            }

            string ri;
            string riLog = string.Format(@"\\{0}\c$\Program Files\RedIron Technologies\RedIron Broker\2Authorize.log", Computer);
            string tmpRILog = string.Format("{0}{1}-ri.log", Shared.Settings.Default._TempPath, Computer);
            if (!Shared.Functions.CopyTempLog(riLog, tmpRILog))
            {
                ri = "Unable to read ri log";
            }
            else
            {
                ri = Shared.Functions.FindInLog(Properties.Settings.Default.redIronVersion, tmpRILog).ToString();
            }

            string vf;
            vf = Shared.Functions.VFLog(Computer, Properties.Settings.Default.vfVersion);

            Output = string.Format("{0} - mult: {1} | ri: {2} | vf: {3}", Computer, multi, ri, vf);
        }

        void bgw_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ;
        }

        public void bgw_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if(WorkDone!=null) { WorkDone(this, e); }
        }



        /*
         * this.bw.WorkerReportsProgress = true;
         * this.bw.WorkerSupportsCancellation = true;
         * this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
         * this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
         */

    }
}
