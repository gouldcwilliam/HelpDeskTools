using System;
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
	public class Unlock : Process
	{
		public Unlock(string ComputerName, string CashierNumber)
		{
			new Process();
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.progress = "";
			this.result = CashierNumber;
			this.title = "Machine: " + ComputerName.ToUpper();

			this._computerName = ComputerName;
			this._cashierNumber = CashierNumber;
			bw.DoWork += new DoWorkEventHandler(this.bw_DoWork);
			bw.ProgressChanged += new ProgressChangedEventHandler(this.bw_ProgressChanged);
			bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

			//InitializeBackgroundWorker();
			//this.Shown += new System.EventHandler(this.frmUnlock_Shown);
			//this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
		}

		string _computerName { get; set; }
		string _cashierNumber { get; set; }
		string _file
		{
			get { return Shared.Settings.Default._TempFile; }
		}

		private void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;

			worker.ReportProgress(0, "Writing file to " + this._file);
			if (worker.CancellationPending) { e.Cancel = true; return; };

			if (GlobalFunctions.b_WriteBatFile(GlobalResources.batUnlock))
			{
				worker.ReportProgress(0, string.Format("Copying {0} to machine {1}", this._file, this._computerName));
				if (worker.CancellationPending) { e.Cancel = true; return; };

				if (GlobalFunctions.b_CopyBatFile(this._computerName))
				{
					worker.ReportProgress(0, string.Format("Executing unlock on {0} for cashier {1}", this._computerName, this._cashierNumber));
					if ((worker.CancellationPending == true)) { e.Cancel = true; return; };

					string args = string.Format("-r:{0} {1} {2}", this._computerName, this._file, this._cashierNumber);

					if (GlobalFunctions.i_ExecuteCommand("WINRS", false, args) == 0)
					{
						worker.ReportProgress(0, "Done!");
						e.Result = "Unlocked " + this._cashierNumber;
					}
					else
					{
						e.Result = "Failed to Unlock " + this._cashierNumber;
					}
				}
				else
				{
					e.Result = "Failed to connect to " + this._computerName;
				}
			}
			else
			{
				e.Result = "Error occured on local computer" + this._file;
			}
		}
	}
}
