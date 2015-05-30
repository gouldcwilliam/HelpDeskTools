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

namespace Retail_HD.Forms
{
	public class Exporting : Process
	{
		private DataTable _dt = new System.Data.DataTable();
		private string _saveLocation = string.Empty;


		public Exporting(System.Data.DataTable dataTable, string saveLocation)
		{
			new Process();

			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			bw.WorkerReportsProgress = true;
			bw.WorkerSupportsCancellation = true;
			bw.DoWork += bw_DoWork;
			bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
			bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
			_dt = dataTable;
			_saveLocation = saveLocation;
		}

		void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			worker.ReportProgress(0, "Exporting data to File");
			if (_dt.Rows.Count == 0) 
			{ 
				worker.ReportProgress(100, "No data to write!");
				e.Result = "No data to write!"; 
			}

			if (worker.CancellationPending) { e.Cancel = true; return; };

			if (HDSharedServices.Functions.Excel_WriteDataTableToFile(_dt, "Call History Export", _saveLocation, "Call History"))
			{
				worker.ReportProgress(100, "Data Exported to: ");
				e.Result = _saveLocation;
			}
			else
			{
				worker.ReportProgress(100, "Error exporting data to: ");
				e.Result = _saveLocation;
			}
		}
	}
}
