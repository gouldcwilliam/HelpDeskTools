﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows;
using System.IO;

namespace Retail_HD.Forms.BGWorkers
{
	public class KillPOS : Process
	{
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
				error = GlobalFunctions.i_ExecuteCommand("WINRS", false, args);
			}
			if (error > 0) { e.Result = "Failed to Kill POS"; }
			else { e.Result = "Killed POS Successfully"; }
		}
	}
}