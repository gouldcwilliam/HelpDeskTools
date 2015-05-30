namespace Retail_HD.UCs
{
	partial class ServicesControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.rbSQL = new System.Windows.Forms.RadioButton();
			this.gbServices = new System.Windows.Forms.GroupBox();
			this.rbCitrix = new System.Windows.Forms.RadioButton();
			this.rbPCA = new System.Windows.Forms.RadioButton();
			this.rbCredit = new System.Windows.Forms.RadioButton();
			this.gbAction = new System.Windows.Forms.GroupBox();
			this.rbStart = new System.Windows.Forms.RadioButton();
			this.rbRestart = new System.Windows.Forms.RadioButton();
			this.rbStop = new System.Windows.Forms.RadioButton();
			this.btnOK = new System.Windows.Forms.Button();
			this.gbServices.SuspendLayout();
			this.gbAction.SuspendLayout();
			this.SuspendLayout();
			// 
			// rbSQL
			// 
			this.rbSQL.AutoSize = true;
			this.rbSQL.Location = new System.Drawing.Point(6, 19);
			this.rbSQL.Name = "rbSQL";
			this.rbSQL.Size = new System.Drawing.Size(88, 17);
			this.rbSQL.TabIndex = 0;
			this.rbSQL.TabStop = true;
			this.rbSQL.Tag = "sql";
			this.rbSQL.Text = "SQL/Express";
			this.rbSQL.UseVisualStyleBackColor = true;
			// 
			// gbServices
			// 
			this.gbServices.Controls.Add(this.rbCitrix);
			this.gbServices.Controls.Add(this.rbPCA);
			this.gbServices.Controls.Add(this.rbCredit);
			this.gbServices.Controls.Add(this.rbSQL);
			this.gbServices.Location = new System.Drawing.Point(3, 3);
			this.gbServices.Name = "gbServices";
			this.gbServices.Size = new System.Drawing.Size(96, 123);
			this.gbServices.TabIndex = 0;
			this.gbServices.TabStop = false;
			this.gbServices.Text = "Service";
			// 
			// rbCitrix
			// 
			this.rbCitrix.AutoSize = true;
			this.rbCitrix.Location = new System.Drawing.Point(6, 88);
			this.rbCitrix.Name = "rbCitrix";
			this.rbCitrix.Size = new System.Drawing.Size(47, 17);
			this.rbCitrix.TabIndex = 4;
			this.rbCitrix.TabStop = true;
			this.rbCitrix.Tag = "citrix";
			this.rbCitrix.Text = "Citrix";
			this.rbCitrix.UseVisualStyleBackColor = true;
			// 
			// rbPCA
			// 
			this.rbPCA.AutoSize = true;
			this.rbPCA.Location = new System.Drawing.Point(6, 65);
			this.rbPCA.Name = "rbPCA";
			this.rbPCA.Size = new System.Drawing.Size(46, 17);
			this.rbPCA.TabIndex = 3;
			this.rbPCA.TabStop = true;
			this.rbPCA.Tag = "pca";
			this.rbPCA.Text = "PCA";
			this.rbPCA.UseVisualStyleBackColor = true;
			// 
			// rbCredit
			// 
			this.rbCredit.AutoSize = true;
			this.rbCredit.Location = new System.Drawing.Point(6, 42);
			this.rbCredit.Name = "rbCredit";
			this.rbCredit.Size = new System.Drawing.Size(82, 17);
			this.rbCredit.TabIndex = 1;
			this.rbCredit.TabStop = true;
			this.rbCredit.Tag = "credit";
			this.rbCredit.Text = "Credit/Debit";
			this.rbCredit.UseVisualStyleBackColor = true;
			// 
			// gbAction
			// 
			this.gbAction.Controls.Add(this.rbStart);
			this.gbAction.Controls.Add(this.rbRestart);
			this.gbAction.Controls.Add(this.rbStop);
			this.gbAction.Location = new System.Drawing.Point(105, 3);
			this.gbAction.Name = "gbAction";
			this.gbAction.Size = new System.Drawing.Size(74, 94);
			this.gbAction.TabIndex = 1;
			this.gbAction.TabStop = false;
			this.gbAction.Text = "Action";
			// 
			// rbStart
			// 
			this.rbStart.AutoSize = true;
			this.rbStart.Location = new System.Drawing.Point(6, 42);
			this.rbStart.Name = "rbStart";
			this.rbStart.Size = new System.Drawing.Size(47, 17);
			this.rbStart.TabIndex = 1;
			this.rbStart.TabStop = true;
			this.rbStart.Tag = "start";
			this.rbStart.Text = "Start";
			this.rbStart.UseVisualStyleBackColor = true;
			// 
			// rbRestart
			// 
			this.rbRestart.AutoSize = true;
			this.rbRestart.Location = new System.Drawing.Point(6, 65);
			this.rbRestart.Name = "rbRestart";
			this.rbRestart.Size = new System.Drawing.Size(59, 17);
			this.rbRestart.TabIndex = 2;
			this.rbRestart.TabStop = true;
			this.rbRestart.Tag = "restart";
			this.rbRestart.Text = "Restart";
			this.rbRestart.UseVisualStyleBackColor = true;
			// 
			// rbStop
			// 
			this.rbStop.AutoSize = true;
			this.rbStop.Location = new System.Drawing.Point(6, 19);
			this.rbStop.Name = "rbStop";
			this.rbStop.Size = new System.Drawing.Size(47, 17);
			this.rbStop.TabIndex = 0;
			this.rbStop.TabStop = true;
			this.rbStop.Tag = "stop";
			this.rbStop.Text = "Stop";
			this.rbStop.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(104, 103);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// ServicesControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.gbAction);
			this.Controls.Add(this.gbServices);
			this.Name = "ServicesControl";
			this.Size = new System.Drawing.Size(183, 135);
			this.gbServices.ResumeLayout(false);
			this.gbServices.PerformLayout();
			this.gbAction.ResumeLayout(false);
			this.gbAction.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.GroupBox gbServices;
		public System.Windows.Forms.GroupBox gbAction;
		public System.Windows.Forms.RadioButton rbSQL;
		public System.Windows.Forms.RadioButton rbCredit;
		public System.Windows.Forms.RadioButton rbStart;
		public System.Windows.Forms.RadioButton rbRestart;
		public System.Windows.Forms.RadioButton rbStop;
		public System.Windows.Forms.Button btnOK;
		public System.Windows.Forms.RadioButton rbPCA;
		public System.Windows.Forms.RadioButton rbCitrix;

	}
}
