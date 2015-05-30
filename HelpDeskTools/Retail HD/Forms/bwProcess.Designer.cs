namespace Retail_HD.Forms
{
	partial class Process
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.pgbWorking = new System.Windows.Forms.ProgressBar();
			this.txtResults = new System.Windows.Forms.TextBox();
			this.txtProgress = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.Location = new System.Drawing.Point(206, 91);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(125, 91);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// pgbWorking
			// 
			this.pgbWorking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pgbWorking.Location = new System.Drawing.Point(12, 50);
			this.pgbWorking.Name = "pgbWorking";
			this.pgbWorking.Size = new System.Drawing.Size(269, 27);
			this.pgbWorking.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.pgbWorking.TabIndex = 10;
			// 
			// txtResults
			// 
			this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResults.BackColor = System.Drawing.SystemColors.Control;
			this.txtResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtResults.Location = new System.Drawing.Point(12, 31);
			this.txtResults.Name = "txtResults";
			this.txtResults.Size = new System.Drawing.Size(269, 13);
			this.txtResults.TabIndex = 9;
			this.txtResults.TabStop = false;
			this.txtResults.Text = "BW Results";
			this.txtResults.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtResults.WordWrap = false;
			// 
			// txtProgress
			// 
			this.txtProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProgress.BackColor = System.Drawing.SystemColors.Control;
			this.txtProgress.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtProgress.Location = new System.Drawing.Point(12, 12);
			this.txtProgress.Name = "txtProgress";
			this.txtProgress.Size = new System.Drawing.Size(269, 13);
			this.txtProgress.TabIndex = 8;
			this.txtProgress.TabStop = false;
			this.txtProgress.Text = "BW Progress";
			// 
			// Process
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(293, 126);
			this.Controls.Add(this.pgbWorking);
			this.Controls.Add(this.txtResults);
			this.Controls.Add(this.txtProgress);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = global::Retail_HD.GlobalResources.icoMain;
			this.MaximizeBox = false;
			this.Name = "Process";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Process:";
			this.Shown += new System.EventHandler(this.frmProcess_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ProgressBar pgbWorking;
		private System.Windows.Forms.TextBox txtResults;
		private System.Windows.Forms.TextBox txtProgress;
		//private Retail_HD.ucProcessStatus ProcessStatus;
	}
}