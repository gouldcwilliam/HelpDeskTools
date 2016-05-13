using System.Collections.Generic;
using System.ComponentModel;
using Shared;

namespace Retail_HD.Forms.BGWorkers
{
    /// <summary>
    /// kills the pos
    /// </summary>
	public class KillPOS : Process
	{
        /// <summary>
        /// <see cref="KillPOS"/>
        /// </summary>
        /// <param name="computers"></param>
		public KillPOS(List<Computer> computers)
		{
			new Process();
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			bw.WorkerReportsProgress = true;
			bw.WorkerSupportsCancellation = true;
			bw.DoWork += new DoWorkEventHandler(bw_DoWork);
			bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
			bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
			_computers = computers;
		}

		private List<Computer> _computers { get; set; }

		private void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			int error = 0;

			worker.ReportProgress(0, "Killing the POS software");
			if (worker.CancellationPending) { e.Cancel = true; return; };

			foreach (Computer computer in _computers)
			{
				worker.ReportProgress(0, "Killing POS on: " + computer.name);
				if (worker.CancellationPending) { e.Cancel = true; return; };
				string args = string.Format("-r:{0} TASKKILL /F /IM POSW.EXE", computer.name);
				error = Shared.Functions.ExecuteCommand("WINRS", args, false);
			}
			if (error > 0) { e.Result = "Failed to Kill POS"; }
			else { e.Result = "Killed POS Successfully"; }
		}
	}
}
