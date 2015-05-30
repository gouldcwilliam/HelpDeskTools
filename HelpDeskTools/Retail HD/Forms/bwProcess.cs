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
	/// <summary>
	/// Form container for background threads/processes
	/// </summary>
	public partial class Process : Form
	{
		/// <summary>
		/// Initializes new instance of Retail_HD.frmProcess Class
		/// </summary>
		/// <remarks>This is a framework containing controls</remarks>
		public Process()
		{
			this.InitializeComponent();

			this.result = "";

			bw.WorkerReportsProgress = true;
			bw.WorkerSupportsCancellation = true;
		}

		/// <summary>
		/// Runs on form load
		/// </summary>
		public BackgroundWorker bw = new BackgroundWorker();
		/// <summary>
		/// ProcessName property displays at top left of form
		/// </summary>
		public string progress
		{
			get
			{
				return this.txtProgress.Text;
			}
			set
			{
				this.txtProgress.Text = value;
			}
		}
		/// <summary>
		/// ProcessMessage property displays at top right of form
		/// </summary>
		public string result
		{
			get
			{
				return this.txtResults.Text;
			}
			set
			{
				this.txtResults.Text = value;
			}
		}
		/// <summary>
		/// Title property of the window
		/// </summary>
		public string title
		{
			get {
				return this.Text;
			}
			set {
				this.Text = value;
			}
		}

		/// <summary>
		/// Changes visibility of key items
		/// </summary>
		public void vProcessComplete()
		{
			this.btnOK.Enabled = true;
			this.pgbWorking.Visible = false;
			this.btnCancel.Enabled = false;
		}
		
		/// <summary>
		/// update this.status with user state reported by bw_DoWork
		/// </summary>
		public void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.progress = e.UserState.ToString();
		}
		/// <summary>
		/// shows all results in the form and invokes vProcessComplete
		/// </summary>
		public void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			string message;
			if ((e.Cancelled == true))
			{
				message = "Canceled!";
			}
			else
			{
				try
				{
					message = (string)e.Result;
				}
				catch (Exception ex)
				{
					message = ex.Message;
				}
			}
			this.result = message;
			this.vProcessComplete();
		}

		/// <summary>
		/// run background worker when shown
		/// </summary>
		private void frmProcess_Shown(object sender, EventArgs e)
		{
			bw.RunWorkerAsync();
		}

		/// <summary>
		/// Sets DialogResult to OK and close form
		/// </summary>
		public void btnOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		/// <summary>
		/// Sets DialogResult to Cancel and close form
		/// </summary>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (bw.WorkerSupportsCancellation)
			{
				bw.CancelAsync();
			}
		}

	}
}
