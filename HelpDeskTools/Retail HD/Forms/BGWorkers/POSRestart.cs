using System.Collections.Generic;
using System.ComponentModel;

using Shared;

namespace Retail_HD.Forms.BGWorkers
{
    /// <summary>
    /// restarts computer
    /// </summary>
	public class Restart : Process
	{
        /// <summary>
        /// <see cref="Restart"/>
        /// </summary>
        /// <param name="computers"></param>
		public Restart(List<Computer> computers)
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

			worker.ReportProgress(0, "Restarting Computer");
			if (worker.CancellationPending) { e.Cancel = true; return; };

			foreach (Computer computer in _computers)
			{
				worker.ReportProgress(0, "Restarting: " + computer.name);
				if (worker.CancellationPending) { e.Cancel = true; return; };

				string args = string.Format("-r:{0} SHUTDOWN /f /r /t 0", computer.name);

				error += Shared.Functions.ExecuteCommand("WINRS", args, false);
			}
			if (error > 0) { e.Result = "Error code: " + error.ToString(); }
			else { e.Result = "Restarted Computer(s)"; }
		}

	}

}
