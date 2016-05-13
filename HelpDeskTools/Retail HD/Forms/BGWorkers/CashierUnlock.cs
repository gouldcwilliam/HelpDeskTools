using System.ComponentModel;

namespace Retail_HD.Forms.BGWorkers
{
    /// <summary>
    /// unlock cashier
    /// </summary>
	public class Unlock : Process
	{
        /// <summary>
        /// <see cref="Unlock"/>
        /// </summary>
        /// <param name="ComputerName"></param>
        /// <param name="CashierNumber"></param>
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

        // TODO - remove steps for copying bat files
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            worker.ReportProgress(0, string.Format("Copying {0} to machine {1}", Shared.Settings.Default._TempPath + Shared.Settings.Default._BatUnlock, this._computerName));
            if (worker.CancellationPending) { e.Cancel = true; return; };

            if (Shared.Functions.CopyFileRemote(this._computerName, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatUnlock))
            {
                worker.ReportProgress(0, string.Format("Executing unlock on {0} for cashier {1}", this._computerName, this._cashierNumber));
                if ((worker.CancellationPending == true)) { e.Cancel = true; return; };

                string args = string.Format("-r:{0} {1} {2}", this._computerName, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatUnlock, this._cashierNumber);

                if (Shared.Functions.ExecuteCommand("WINRS", args, false) == 0)
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
	}
}
