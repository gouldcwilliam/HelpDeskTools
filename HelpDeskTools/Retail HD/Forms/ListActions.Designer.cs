namespace Retail_HD.Forms
{
	partial class ListActions
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
			this.txtList = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.ckbBrowser = new System.Windows.Forms.CheckBox();
			this.txtSuffix = new System.Windows.Forms.TextBox();
			this.lblSuffix = new System.Windows.Forms.Label();
			this.gbRegister = new System.Windows.Forms.GroupBox();
			this.ckb3 = new System.Windows.Forms.CheckBox();
			this.ckb4 = new System.Windows.Forms.CheckBox();
			this.ckb2 = new System.Windows.Forms.CheckBox();
			this.ckb1 = new System.Windows.Forms.CheckBox();
			this.ckbService = new System.Windows.Forms.CheckBox();
			this.ckbRegister = new System.Windows.Forms.CheckBox();
			this.ckbRestart = new System.Windows.Forms.CheckBox();
			this.ckbActivate = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.ckbOpenProgram = new System.Windows.Forms.CheckBox();
			this.gbProgram = new System.Windows.Forms.GroupBox();
			this.ckbCMD = new System.Windows.Forms.CheckBox();
			this.ckbDameware = new System.Windows.Forms.CheckBox();
			this.ckbMulti = new System.Windows.Forms.CheckBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.ckbInstallEndpoint = new System.Windows.Forms.CheckBox();
			this.ckbDisableStartupRepair = new System.Windows.Forms.CheckBox();
			this.ckbFastPrinter = new System.Windows.Forms.CheckBox();
			this.gbAction = new System.Windows.Forms.GroupBox();
			this.rbStart = new System.Windows.Forms.RadioButton();
			this.rbRestart = new System.Windows.Forms.RadioButton();
			this.rbStop = new System.Windows.Forms.RadioButton();
			this.gbServices = new System.Windows.Forms.GroupBox();
			this.rbVerifone = new System.Windows.Forms.RadioButton();
			this.rbCitrix = new System.Windows.Forms.RadioButton();
			this.rbTransnet = new System.Windows.Forms.RadioButton();
			this.rbCredit = new System.Windows.Forms.RadioButton();
			this.rbSQL = new System.Windows.Forms.RadioButton();
			this.ckbRIMulti = new System.Windows.Forms.CheckBox();
			this.gbRegister.SuspendLayout();
			this.gbProgram.SuspendLayout();
			this.gbAction.SuspendLayout();
			this.gbServices.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtList
			// 
			this.txtList.Location = new System.Drawing.Point(12, 29);
			this.txtList.Multiline = true;
			this.txtList.Name = "txtList";
			this.txtList.Size = new System.Drawing.Size(276, 65);
			this.txtList.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(371, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Enter the list of store numbers separated by a space to execute command on:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(219, 492);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 12;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// ckbBrowser
			// 
			this.ckbBrowser.AutoSize = true;
			this.ckbBrowser.Location = new System.Drawing.Point(12, 292);
			this.ckbBrowser.Name = "ckbBrowser";
			this.ckbBrowser.Size = new System.Drawing.Size(93, 17);
			this.ckbBrowser.TabIndex = 6;
			this.ckbBrowser.Text = "Open Browser";
			this.ckbBrowser.UseVisualStyleBackColor = true;
			this.ckbBrowser.CheckedChanged += new System.EventHandler(this.ckbBrowser_CheckedChanged);
			// 
			// txtSuffix
			// 
			this.txtSuffix.Location = new System.Drawing.Point(112, 290);
			this.txtSuffix.Name = "txtSuffix";
			this.txtSuffix.Size = new System.Drawing.Size(263, 20);
			this.txtSuffix.TabIndex = 7;
			this.txtSuffix.Visible = false;
			// 
			// lblSuffix
			// 
			this.lblSuffix.AutoSize = true;
			this.lblSuffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSuffix.Location = new System.Drawing.Point(180, 313);
			this.lblSuffix.Name = "lblSuffix";
			this.lblSuffix.Size = new System.Drawing.Size(195, 13);
			this.lblSuffix.TabIndex = 15;
			this.lblSuffix.Text = "Location to browse ( leave blank for C: )";
			this.lblSuffix.Visible = false;
			// 
			// gbRegister
			// 
			this.gbRegister.Controls.Add(this.ckb3);
			this.gbRegister.Controls.Add(this.ckb4);
			this.gbRegister.Controls.Add(this.ckb2);
			this.gbRegister.Controls.Add(this.ckb1);
			this.gbRegister.Location = new System.Drawing.Point(261, 100);
			this.gbRegister.Name = "gbRegister";
			this.gbRegister.Size = new System.Drawing.Size(114, 71);
			this.gbRegister.TabIndex = 2;
			this.gbRegister.TabStop = false;
			this.gbRegister.Text = "Register #";
			this.gbRegister.Visible = false;
			// 
			// ckb3
			// 
			this.ckb3.AutoSize = true;
			this.ckb3.Location = new System.Drawing.Point(76, 19);
			this.ckb3.Name = "ckb3";
			this.ckb3.Size = new System.Drawing.Size(32, 17);
			this.ckb3.TabIndex = 2;
			this.ckb3.Text = "3";
			this.ckb3.UseVisualStyleBackColor = true;
			// 
			// ckb4
			// 
			this.ckb4.AutoSize = true;
			this.ckb4.Location = new System.Drawing.Point(76, 42);
			this.ckb4.Name = "ckb4";
			this.ckb4.Size = new System.Drawing.Size(32, 17);
			this.ckb4.TabIndex = 3;
			this.ckb4.Text = "4";
			this.ckb4.UseVisualStyleBackColor = true;
			// 
			// ckb2
			// 
			this.ckb2.AutoSize = true;
			this.ckb2.Location = new System.Drawing.Point(6, 42);
			this.ckb2.Name = "ckb2";
			this.ckb2.Size = new System.Drawing.Size(32, 17);
			this.ckb2.TabIndex = 1;
			this.ckb2.Text = "2";
			this.ckb2.UseVisualStyleBackColor = true;
			// 
			// ckb1
			// 
			this.ckb1.AutoSize = true;
			this.ckb1.Location = new System.Drawing.Point(6, 19);
			this.ckb1.Name = "ckb1";
			this.ckb1.Size = new System.Drawing.Size(32, 17);
			this.ckb1.TabIndex = 0;
			this.ckb1.Text = "1";
			this.ckb1.UseVisualStyleBackColor = true;
			// 
			// ckbService
			// 
			this.ckbService.AutoSize = true;
			this.ckbService.Location = new System.Drawing.Point(12, 219);
			this.ckbService.Name = "ckbService";
			this.ckbService.Size = new System.Drawing.Size(104, 17);
			this.ckbService.TabIndex = 3;
			this.ckbService.Text = "Manage Service";
			this.ckbService.UseVisualStyleBackColor = true;
			this.ckbService.CheckedChanged += new System.EventHandler(this.ckbService_CheckedChanged);
			// 
			// ckbRegister
			// 
			this.ckbRegister.AutoSize = true;
			this.ckbRegister.Location = new System.Drawing.Point(12, 128);
			this.ckbRegister.Name = "ckbRegister";
			this.ckbRegister.Size = new System.Drawing.Size(103, 17);
			this.ckbRegister.TabIndex = 1;
			this.ckbRegister.Text = "Specify Register";
			this.ckbRegister.UseVisualStyleBackColor = true;
			this.ckbRegister.CheckedChanged += new System.EventHandler(this.ckbRegister_CheckedChanged);
			// 
			// ckbRestart
			// 
			this.ckbRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ckbRestart.AutoSize = true;
			this.ckbRestart.Location = new System.Drawing.Point(12, 495);
			this.ckbRestart.Name = "ckbRestart";
			this.ckbRestart.Size = new System.Drawing.Size(61, 17);
			this.ckbRestart.TabIndex = 11;
			this.ckbRestart.Text = "Reboot";
			this.ckbRestart.UseVisualStyleBackColor = true;
			// 
			// ckbActivate
			// 
			this.ckbActivate.AutoSize = true;
			this.ckbActivate.Location = new System.Drawing.Point(12, 405);
			this.ckbActivate.Name = "ckbActivate";
			this.ckbActivate.Size = new System.Drawing.Size(112, 17);
			this.ckbActivate.TabIndex = 10;
			this.ckbActivate.Text = "Activate Windows";
			this.ckbActivate.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(300, 492);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ckbOpenProgram
			// 
			this.ckbOpenProgram.AutoSize = true;
			this.ckbOpenProgram.Location = new System.Drawing.Point(12, 356);
			this.ckbOpenProgram.Name = "ckbOpenProgram";
			this.ckbOpenProgram.Size = new System.Drawing.Size(94, 17);
			this.ckbOpenProgram.TabIndex = 8;
			this.ckbOpenProgram.Text = "Open Program";
			this.ckbOpenProgram.UseVisualStyleBackColor = true;
			this.ckbOpenProgram.CheckedChanged += new System.EventHandler(this.ckbOpenProgram_CheckedChanged);
			// 
			// gbProgram
			// 
			this.gbProgram.Controls.Add(this.ckbCMD);
			this.gbProgram.Controls.Add(this.ckbDameware);
			this.gbProgram.Controls.Add(this.ckbMulti);
			this.gbProgram.Location = new System.Drawing.Point(175, 337);
			this.gbProgram.Name = "gbProgram";
			this.gbProgram.Size = new System.Drawing.Size(200, 50);
			this.gbProgram.TabIndex = 9;
			this.gbProgram.TabStop = false;
			this.gbProgram.Text = "Program";
			this.gbProgram.Visible = false;
			// 
			// ckbCMD
			// 
			this.ckbCMD.AutoSize = true;
			this.ckbCMD.Location = new System.Drawing.Point(143, 19);
			this.ckbCMD.Name = "ckbCMD";
			this.ckbCMD.Size = new System.Drawing.Size(50, 17);
			this.ckbCMD.TabIndex = 2;
			this.ckbCMD.Text = "CMD";
			this.ckbCMD.UseVisualStyleBackColor = true;
			// 
			// ckbDameware
			// 
			this.ckbDameware.AutoSize = true;
			this.ckbDameware.Location = new System.Drawing.Point(60, 19);
			this.ckbDameware.Name = "ckbDameware";
			this.ckbDameware.Size = new System.Drawing.Size(77, 17);
			this.ckbDameware.TabIndex = 1;
			this.ckbDameware.Text = "Dameware";
			this.ckbDameware.UseVisualStyleBackColor = true;
			// 
			// ckbMulti
			// 
			this.ckbMulti.AutoSize = true;
			this.ckbMulti.Location = new System.Drawing.Point(6, 19);
			this.ckbMulti.Name = "ckbMulti";
			this.ckbMulti.Size = new System.Drawing.Size(48, 17);
			this.ckbMulti.TabIndex = 0;
			this.ckbMulti.Text = "Multi";
			this.ckbMulti.UseVisualStyleBackColor = true;
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Location = new System.Drawing.Point(300, 42);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 14;
			this.btnClear.Text = "< Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// ckbInstallEndpoint
			// 
			this.ckbInstallEndpoint.AutoSize = true;
			this.ckbInstallEndpoint.Location = new System.Drawing.Point(12, 428);
			this.ckbInstallEndpoint.Name = "ckbInstallEndpoint";
			this.ckbInstallEndpoint.Size = new System.Drawing.Size(113, 17);
			this.ckbInstallEndpoint.TabIndex = 16;
			this.ckbInstallEndpoint.Text = "Install Endpoint 12";
			this.ckbInstallEndpoint.UseVisualStyleBackColor = true;
			// 
			// ckbDisableStartupRepair
			// 
			this.ckbDisableStartupRepair.AutoSize = true;
			this.ckbDisableStartupRepair.Location = new System.Drawing.Point(175, 405);
			this.ckbDisableStartupRepair.Name = "ckbDisableStartupRepair";
			this.ckbDisableStartupRepair.Size = new System.Drawing.Size(132, 17);
			this.ckbDisableStartupRepair.TabIndex = 17;
			this.ckbDisableStartupRepair.Text = "Disable Startup Repair";
			this.ckbDisableStartupRepair.UseVisualStyleBackColor = true;
			// 
			// ckbFastPrinter
			// 
			this.ckbFastPrinter.AutoSize = true;
			this.ckbFastPrinter.Location = new System.Drawing.Point(175, 428);
			this.ckbFastPrinter.Name = "ckbFastPrinter";
			this.ckbFastPrinter.Size = new System.Drawing.Size(151, 17);
			this.ckbFastPrinter.TabIndex = 18;
			this.ckbFastPrinter.Text = "Super Fast Receipt d BOS";
			this.ckbFastPrinter.UseVisualStyleBackColor = true;
			// 
			// gbAction
			// 
			this.gbAction.Controls.Add(this.rbStart);
			this.gbAction.Controls.Add(this.rbRestart);
			this.gbAction.Controls.Add(this.rbStop);
			this.gbAction.Location = new System.Drawing.Point(301, 177);
			this.gbAction.Name = "gbAction";
			this.gbAction.Size = new System.Drawing.Size(74, 94);
			this.gbAction.TabIndex = 20;
			this.gbAction.TabStop = false;
			this.gbAction.Text = "Action";
			this.gbAction.Visible = false;
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
			// gbServices
			// 
			this.gbServices.Controls.Add(this.rbVerifone);
			this.gbServices.Controls.Add(this.rbCitrix);
			this.gbServices.Controls.Add(this.rbTransnet);
			this.gbServices.Controls.Add(this.rbCredit);
			this.gbServices.Controls.Add(this.rbSQL);
			this.gbServices.Location = new System.Drawing.Point(112, 177);
			this.gbServices.Name = "gbServices";
			this.gbServices.Size = new System.Drawing.Size(183, 94);
			this.gbServices.TabIndex = 19;
			this.gbServices.TabStop = false;
			this.gbServices.Text = "Service";
			this.gbServices.Visible = false;
			// 
			// rbVerifone
			// 
			this.rbVerifone.AutoSize = true;
			this.rbVerifone.Location = new System.Drawing.Point(107, 65);
			this.rbVerifone.Name = "rbVerifone";
			this.rbVerifone.Size = new System.Drawing.Size(64, 17);
			this.rbVerifone.TabIndex = 8;
			this.rbVerifone.TabStop = true;
			this.rbVerifone.Tag = "verifone";
			this.rbVerifone.Text = "Verifone";
			this.rbVerifone.UseVisualStyleBackColor = true;
			// 
			// rbCitrix
			// 
			this.rbCitrix.AutoSize = true;
			this.rbCitrix.Location = new System.Drawing.Point(107, 41);
			this.rbCitrix.Name = "rbCitrix";
			this.rbCitrix.Size = new System.Drawing.Size(47, 17);
			this.rbCitrix.TabIndex = 7;
			this.rbCitrix.TabStop = true;
			this.rbCitrix.Tag = "citrix";
			this.rbCitrix.Text = "Citrix";
			this.rbCitrix.UseVisualStyleBackColor = true;
			// 
			// rbTransnet
			// 
			this.rbTransnet.AutoSize = true;
			this.rbTransnet.Location = new System.Drawing.Point(6, 65);
			this.rbTransnet.Name = "rbTransnet";
			this.rbTransnet.Size = new System.Drawing.Size(67, 17);
			this.rbTransnet.TabIndex = 5;
			this.rbTransnet.TabStop = true;
			this.rbTransnet.Tag = "transnet";
			this.rbTransnet.Text = "Transnet";
			this.rbTransnet.UseVisualStyleBackColor = true;
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
			// ckbRIMulti
			// 
			this.ckbRIMulti.AutoSize = true;
			this.ckbRIMulti.Location = new System.Drawing.Point(12, 451);
			this.ckbRIMulti.Name = "ckbRIMulti";
			this.ckbRIMulti.Size = new System.Drawing.Size(120, 17);
			this.ckbRIMulti.TabIndex = 21;
			this.ckbRIMulti.Text = "RI and Multi version";
			this.ckbRIMulti.UseVisualStyleBackColor = true;
			// 
			// ListActions
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(387, 527);
			this.Controls.Add(this.ckbRIMulti);
			this.Controls.Add(this.gbAction);
			this.Controls.Add(this.gbServices);
			this.Controls.Add(this.ckbFastPrinter);
			this.Controls.Add(this.ckbDisableStartupRepair);
			this.Controls.Add(this.ckbInstallEndpoint);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.gbProgram);
			this.Controls.Add(this.ckbOpenProgram);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.ckbActivate);
			this.Controls.Add(this.ckbRestart);
			this.Controls.Add(this.ckbRegister);
			this.Controls.Add(this.ckbService);
			this.Controls.Add(this.gbRegister);
			this.Controls.Add(this.lblSuffix);
			this.Controls.Add(this.txtSuffix);
			this.Controls.Add(this.ckbBrowser);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = global::Retail_HD.GlobalResources.icoMain;
			this.MinimumSize = new System.Drawing.Size(403, 513);
			this.Name = "ListActions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "List Actions";
			this.gbRegister.ResumeLayout(false);
			this.gbRegister.PerformLayout();
			this.gbProgram.ResumeLayout(false);
			this.gbProgram.PerformLayout();
			this.gbAction.ResumeLayout(false);
			this.gbAction.PerformLayout();
			this.gbServices.ResumeLayout(false);
			this.gbServices.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtList;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.CheckBox ckbBrowser;
		private System.Windows.Forms.TextBox txtSuffix;
		private System.Windows.Forms.Label lblSuffix;
		private System.Windows.Forms.GroupBox gbRegister;
		private System.Windows.Forms.CheckBox ckb3;
		private System.Windows.Forms.CheckBox ckb4;
		private System.Windows.Forms.CheckBox ckb2;
		private System.Windows.Forms.CheckBox ckb1;
		private System.Windows.Forms.CheckBox ckbService;
		private System.Windows.Forms.CheckBox ckbRegister;
		private System.Windows.Forms.CheckBox ckbRestart;
		private System.Windows.Forms.CheckBox ckbActivate;
		public System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.CheckBox ckbOpenProgram;
		private System.Windows.Forms.GroupBox gbProgram;
		private System.Windows.Forms.CheckBox ckbMulti;
		private System.Windows.Forms.CheckBox ckbCMD;
		private System.Windows.Forms.CheckBox ckbDameware;
		public System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.CheckBox ckbInstallEndpoint;
		private System.Windows.Forms.CheckBox ckbDisableStartupRepair;
		private System.Windows.Forms.CheckBox ckbFastPrinter;
        public System.Windows.Forms.GroupBox gbAction;
        public System.Windows.Forms.RadioButton rbStart;
        public System.Windows.Forms.RadioButton rbRestart;
        public System.Windows.Forms.RadioButton rbStop;
        public System.Windows.Forms.GroupBox gbServices;
        public System.Windows.Forms.RadioButton rbTransnet;
        public System.Windows.Forms.RadioButton rbCredit;
        public System.Windows.Forms.RadioButton rbSQL;
        public System.Windows.Forms.RadioButton rbVerifone;
        public System.Windows.Forms.RadioButton rbCitrix;
		private System.Windows.Forms.CheckBox ckbRIMulti;
	}
}