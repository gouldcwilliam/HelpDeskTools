namespace Retail_HD.Forms
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	partial class ListActions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListActions));
            this.txtList = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.ckbBrowser = new System.Windows.Forms.CheckBox();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.lblSuffix = new System.Windows.Forms.Label();
            this.gbRegister = new System.Windows.Forms.GroupBox();
            this.ckb5 = new System.Windows.Forms.CheckBox();
            this.ckb6 = new System.Windows.Forms.CheckBox();
            this.ckb3 = new System.Windows.Forms.CheckBox();
            this.ckb4 = new System.Windows.Forms.CheckBox();
            this.ckb2 = new System.Windows.Forms.CheckBox();
            this.ckb1 = new System.Windows.Forms.CheckBox();
            this.ckbService = new System.Windows.Forms.CheckBox();
            this.ckbRegister = new System.Windows.Forms.CheckBox();
            this.ckbRestart = new System.Windows.Forms.CheckBox();
            this.ckbActivate = new System.Windows.Forms.CheckBox();
            this.gbProgram = new System.Windows.Forms.GroupBox();
            this.ckbPing = new System.Windows.Forms.CheckBox();
            this.ckbCMD = new System.Windows.Forms.CheckBox();
            this.ckbDameware = new System.Windows.Forms.CheckBox();
            this.ckbMulti = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.ckbDisableStartupRepair = new System.Windows.Forms.CheckBox();
            this.ckbFastPrinter = new System.Windows.Forms.CheckBox();
            this.gbAction = new System.Windows.Forms.GroupBox();
            this.rbStart = new System.Windows.Forms.RadioButton();
            this.rbRestart = new System.Windows.Forms.RadioButton();
            this.rbStop = new System.Windows.Forms.RadioButton();
            this.gbServices = new System.Windows.Forms.GroupBox();
            this.rbSep = new System.Windows.Forms.RadioButton();
            this.rbTripwire = new System.Windows.Forms.RadioButton();
            this.rbBit9 = new System.Windows.Forms.RadioButton();
            this.rbVerifone = new System.Windows.Forms.RadioButton();
            this.rbCitrix = new System.Windows.Forms.RadioButton();
            this.rbTransnet = new System.Windows.Forms.RadioButton();
            this.rbCredit = new System.Windows.Forms.RadioButton();
            this.rbSQL = new System.Windows.Forms.RadioButton();
            this.ckbRIMulti = new System.Windows.Forms.CheckBox();
            this.ckbTrickle = new System.Windows.Forms.CheckBox();
            this.ckbZip = new System.Windows.Forms.CheckBox();
            this.ckbWSAdmin = new System.Windows.Forms.CheckBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.btnClearOut = new System.Windows.Forms.Button();
            this.ckbSEPOpenGUI = new System.Windows.Forms.CheckBox();
            this.gbSEP = new System.Windows.Forms.GroupBox();
            this.ckbSEPUpdateConfig = new System.Windows.Forms.CheckBox();
            this.ckbSEPUpdateComms = new System.Windows.Forms.CheckBox();
            this.ckbSEPRunInstall = new System.Windows.Forms.CheckBox();
            this.gbRegister.SuspendLayout();
            this.gbProgram.SuspendLayout();
            this.gbAction.SuspendLayout();
            this.gbServices.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.gbSEP.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(12, 29);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.Size = new System.Drawing.Size(319, 188);
            this.txtList.TabIndex = 0;
            // 
            // label1
            // 
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
            this.btnOK.Location = new System.Drawing.Point(297, 628);
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
            this.ckbBrowser.Location = new System.Drawing.Point(12, 376);
            this.ckbBrowser.Name = "ckbBrowser";
            this.ckbBrowser.Size = new System.Drawing.Size(93, 17);
            this.ckbBrowser.TabIndex = 6;
            this.ckbBrowser.Text = "Open Browser";
            this.ckbBrowser.UseVisualStyleBackColor = true;
            this.ckbBrowser.CheckedChanged += new System.EventHandler(this.ckbBrowser_CheckedChanged);
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(112, 374);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(263, 20);
            this.txtSuffix.TabIndex = 7;
            this.txtSuffix.Visible = false;
            // 
            // lblSuffix
            // 
            this.lblSuffix.AutoSize = true;
            this.lblSuffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuffix.Location = new System.Drawing.Point(180, 397);
            this.lblSuffix.Name = "lblSuffix";
            this.lblSuffix.Size = new System.Drawing.Size(195, 13);
            this.lblSuffix.TabIndex = 15;
            this.lblSuffix.Text = "Location to browse ( leave blank for C: )";
            this.lblSuffix.Visible = false;
            // 
            // gbRegister
            // 
            this.gbRegister.Controls.Add(this.ckb5);
            this.gbRegister.Controls.Add(this.ckb6);
            this.gbRegister.Controls.Add(this.ckb3);
            this.gbRegister.Controls.Add(this.ckb4);
            this.gbRegister.Controls.Add(this.ckb2);
            this.gbRegister.Controls.Add(this.ckb1);
            this.gbRegister.Location = new System.Drawing.Point(132, 223);
            this.gbRegister.Name = "gbRegister";
            this.gbRegister.Size = new System.Drawing.Size(243, 45);
            this.gbRegister.TabIndex = 2;
            this.gbRegister.TabStop = false;
            this.gbRegister.Text = "Register #";
            this.gbRegister.Visible = false;
            // 
            // ckb5
            // 
            this.ckb5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckb5.AutoSize = true;
            this.ckb5.Location = new System.Drawing.Point(167, 19);
            this.ckb5.Name = "ckb5";
            this.ckb5.Size = new System.Drawing.Size(32, 17);
            this.ckb5.TabIndex = 4;
            this.ckb5.Text = "5";
            this.ckb5.UseVisualStyleBackColor = true;
            // 
            // ckb6
            // 
            this.ckb6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckb6.AutoSize = true;
            this.ckb6.Location = new System.Drawing.Point(205, 19);
            this.ckb6.Name = "ckb6";
            this.ckb6.Size = new System.Drawing.Size(32, 17);
            this.ckb6.TabIndex = 5;
            this.ckb6.Text = "6";
            this.ckb6.UseVisualStyleBackColor = true;
            // 
            // ckb3
            // 
            this.ckb3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckb3.AutoSize = true;
            this.ckb3.Location = new System.Drawing.Point(91, 19);
            this.ckb3.Name = "ckb3";
            this.ckb3.Size = new System.Drawing.Size(32, 17);
            this.ckb3.TabIndex = 2;
            this.ckb3.Text = "3";
            this.ckb3.UseVisualStyleBackColor = true;
            // 
            // ckb4
            // 
            this.ckb4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckb4.AutoSize = true;
            this.ckb4.Location = new System.Drawing.Point(129, 19);
            this.ckb4.Name = "ckb4";
            this.ckb4.Size = new System.Drawing.Size(32, 17);
            this.ckb4.TabIndex = 3;
            this.ckb4.Text = "4";
            this.ckb4.UseVisualStyleBackColor = true;
            // 
            // ckb2
            // 
            this.ckb2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckb2.AutoSize = true;
            this.ckb2.Location = new System.Drawing.Point(53, 19);
            this.ckb2.Name = "ckb2";
            this.ckb2.Size = new System.Drawing.Size(32, 17);
            this.ckb2.TabIndex = 1;
            this.ckb2.Text = "2";
            this.ckb2.UseVisualStyleBackColor = true;
            // 
            // ckb1
            // 
            this.ckb1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckb1.AutoSize = true;
            this.ckb1.Location = new System.Drawing.Point(15, 19);
            this.ckb1.Name = "ckb1";
            this.ckb1.Size = new System.Drawing.Size(32, 17);
            this.ckb1.TabIndex = 0;
            this.ckb1.Text = "1";
            this.ckb1.UseVisualStyleBackColor = true;
            // 
            // ckbService
            // 
            this.ckbService.AutoSize = true;
            this.ckbService.Location = new System.Drawing.Point(12, 303);
            this.ckbService.Name = "ckbService";
            this.ckbService.Size = new System.Drawing.Size(62, 17);
            this.ckbService.TabIndex = 3;
            this.ckbService.Text = "Service";
            this.ckbService.UseVisualStyleBackColor = true;
            this.ckbService.CheckedChanged += new System.EventHandler(this.ckbService_CheckedChanged);
            // 
            // ckbRegister
            // 
            this.ckbRegister.AutoSize = true;
            this.ckbRegister.Location = new System.Drawing.Point(12, 242);
            this.ckbRegister.Name = "ckbRegister";
            this.ckbRegister.Size = new System.Drawing.Size(103, 17);
            this.ckbRegister.TabIndex = 1;
            this.ckbRegister.Text = "Specify Register";
            this.ckbRegister.UseVisualStyleBackColor = true;
            this.ckbRegister.CheckedChanged += new System.EventHandler(this.ckbRegister_CheckedChanged);
            // 
            // ckbRestart
            // 
            this.ckbRestart.AutoSize = true;
            this.ckbRestart.Location = new System.Drawing.Point(12, 628);
            this.ckbRestart.Name = "ckbRestart";
            this.ckbRestart.Size = new System.Drawing.Size(61, 17);
            this.ckbRestart.TabIndex = 11;
            this.ckbRestart.Text = "Reboot";
            this.ckbRestart.UseVisualStyleBackColor = true;
            // 
            // ckbActivate
            // 
            this.ckbActivate.AutoSize = true;
            this.ckbActivate.Location = new System.Drawing.Point(12, 561);
            this.ckbActivate.Name = "ckbActivate";
            this.ckbActivate.Size = new System.Drawing.Size(112, 17);
            this.ckbActivate.TabIndex = 10;
            this.ckbActivate.Text = "Activate Windows";
            this.ckbActivate.UseVisualStyleBackColor = true;
            // 
            // gbProgram
            // 
            this.gbProgram.Controls.Add(this.ckbPing);
            this.gbProgram.Controls.Add(this.ckbCMD);
            this.gbProgram.Controls.Add(this.ckbDameware);
            this.gbProgram.Controls.Add(this.ckbMulti);
            this.gbProgram.Location = new System.Drawing.Point(122, 413);
            this.gbProgram.Name = "gbProgram";
            this.gbProgram.Size = new System.Drawing.Size(253, 50);
            this.gbProgram.TabIndex = 9;
            this.gbProgram.TabStop = false;
            this.gbProgram.Text = "Program";
            // 
            // ckbPing
            // 
            this.ckbPing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbPing.AutoSize = true;
            this.ckbPing.Location = new System.Drawing.Point(200, 19);
            this.ckbPing.Name = "ckbPing";
            this.ckbPing.Size = new System.Drawing.Size(47, 17);
            this.ckbPing.TabIndex = 3;
            this.ckbPing.Text = "Ping";
            this.ckbPing.UseVisualStyleBackColor = true;
            // 
            // ckbCMD
            // 
            this.ckbCMD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbCMD.AutoSize = true;
            this.ckbCMD.Location = new System.Drawing.Point(148, 19);
            this.ckbCMD.Name = "ckbCMD";
            this.ckbCMD.Size = new System.Drawing.Size(50, 17);
            this.ckbCMD.TabIndex = 2;
            this.ckbCMD.Text = "CMD";
            this.ckbCMD.UseVisualStyleBackColor = true;
            // 
            // ckbDameware
            // 
            this.ckbDameware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbDameware.AutoSize = true;
            this.ckbDameware.Location = new System.Drawing.Point(65, 19);
            this.ckbDameware.Name = "ckbDameware";
            this.ckbDameware.Size = new System.Drawing.Size(77, 17);
            this.ckbDameware.TabIndex = 1;
            this.ckbDameware.Text = "Dameware";
            this.ckbDameware.UseVisualStyleBackColor = true;
            // 
            // ckbMulti
            // 
            this.ckbMulti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbMulti.AutoSize = true;
            this.ckbMulti.Location = new System.Drawing.Point(11, 19);
            this.ckbMulti.Name = "ckbMulti";
            this.ckbMulti.Size = new System.Drawing.Size(48, 17);
            this.ckbMulti.TabIndex = 0;
            this.ckbMulti.Text = "Multi";
            this.ckbMulti.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(337, 43);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(54, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "< Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ckbDisableStartupRepair
            // 
            this.ckbDisableStartupRepair.AutoSize = true;
            this.ckbDisableStartupRepair.Location = new System.Drawing.Point(175, 538);
            this.ckbDisableStartupRepair.Name = "ckbDisableStartupRepair";
            this.ckbDisableStartupRepair.Size = new System.Drawing.Size(132, 17);
            this.ckbDisableStartupRepair.TabIndex = 17;
            this.ckbDisableStartupRepair.Text = "Disable Startup Repair";
            this.ckbDisableStartupRepair.UseVisualStyleBackColor = true;
            // 
            // ckbFastPrinter
            // 
            this.ckbFastPrinter.AutoSize = true;
            this.ckbFastPrinter.Location = new System.Drawing.Point(175, 561);
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
            this.gbAction.Location = new System.Drawing.Point(301, 274);
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
            this.gbServices.Controls.Add(this.rbSep);
            this.gbServices.Controls.Add(this.rbTripwire);
            this.gbServices.Controls.Add(this.rbBit9);
            this.gbServices.Controls.Add(this.rbVerifone);
            this.gbServices.Controls.Add(this.rbCitrix);
            this.gbServices.Controls.Add(this.rbTransnet);
            this.gbServices.Controls.Add(this.rbCredit);
            this.gbServices.Controls.Add(this.rbSQL);
            this.gbServices.Location = new System.Drawing.Point(72, 274);
            this.gbServices.Name = "gbServices";
            this.gbServices.Size = new System.Drawing.Size(223, 94);
            this.gbServices.TabIndex = 19;
            this.gbServices.TabStop = false;
            this.gbServices.Text = "Service";
            this.gbServices.Visible = false;
            // 
            // rbSep
            // 
            this.rbSep.AutoSize = true;
            this.rbSep.Location = new System.Drawing.Point(170, 19);
            this.rbSep.Name = "rbSep";
            this.rbSep.Size = new System.Drawing.Size(46, 17);
            this.rbSep.TabIndex = 11;
            this.rbSep.TabStop = true;
            this.rbSep.Tag = "sep";
            this.rbSep.Text = "SEP";
            this.rbSep.UseVisualStyleBackColor = true;
            // 
            // rbTripwire
            // 
            this.rbTripwire.AutoSize = true;
            this.rbTripwire.Location = new System.Drawing.Point(100, 65);
            this.rbTripwire.Name = "rbTripwire";
            this.rbTripwire.Size = new System.Drawing.Size(62, 17);
            this.rbTripwire.TabIndex = 10;
            this.rbTripwire.TabStop = true;
            this.rbTripwire.Tag = "tripwire";
            this.rbTripwire.Text = "Tripwire";
            this.rbTripwire.UseVisualStyleBackColor = true;
            // 
            // rbBit9
            // 
            this.rbBit9.AutoSize = true;
            this.rbBit9.Location = new System.Drawing.Point(170, 42);
            this.rbBit9.Name = "rbBit9";
            this.rbBit9.Size = new System.Drawing.Size(43, 17);
            this.rbBit9.TabIndex = 9;
            this.rbBit9.TabStop = true;
            this.rbBit9.Tag = "bit9";
            this.rbBit9.Text = "Bit9";
            this.rbBit9.UseVisualStyleBackColor = true;
            // 
            // rbVerifone
            // 
            this.rbVerifone.AutoSize = true;
            this.rbVerifone.Location = new System.Drawing.Point(100, 42);
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
            this.rbCitrix.Location = new System.Drawing.Point(100, 19);
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
            this.ckbRIMulti.Location = new System.Drawing.Point(12, 584);
            this.ckbRIMulti.Name = "ckbRIMulti";
            this.ckbRIMulti.Size = new System.Drawing.Size(120, 17);
            this.ckbRIMulti.TabIndex = 21;
            this.ckbRIMulti.Text = "RI and Multi version";
            this.ckbRIMulti.UseVisualStyleBackColor = true;
            // 
            // ckbTrickle
            // 
            this.ckbTrickle.AutoSize = true;
            this.ckbTrickle.Location = new System.Drawing.Point(12, 538);
            this.ckbTrickle.Name = "ckbTrickle";
            this.ckbTrickle.Size = new System.Drawing.Size(74, 17);
            this.ckbTrickle.TabIndex = 22;
            this.ckbTrickle.Text = "Fix Trickle";
            this.ckbTrickle.UseVisualStyleBackColor = true;
            // 
            // ckbZip
            // 
            this.ckbZip.AutoSize = true;
            this.ckbZip.Location = new System.Drawing.Point(12, 605);
            this.ckbZip.Name = "ckbZip";
            this.ckbZip.Size = new System.Drawing.Size(106, 17);
            this.ckbZip.TabIndex = 23;
            this.ckbZip.Text = "Zip All The Logs!";
            this.ckbZip.UseVisualStyleBackColor = true;
            // 
            // ckbWSAdmin
            // 
            this.ckbWSAdmin.AutoSize = true;
            this.ckbWSAdmin.Location = new System.Drawing.Point(175, 584);
            this.ckbWSAdmin.Name = "ckbWSAdmin";
            this.ckbWSAdmin.Size = new System.Drawing.Size(105, 17);
            this.ckbWSAdmin.TabIndex = 24;
            this.ckbWSAdmin.Text = "WSAdmin Adjust";
            this.ckbWSAdmin.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 16);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(447, 623);
            this.txtOutput.TabIndex = 25;
            this.txtOutput.WordWrap = false;
            // 
            // gbOutput
            // 
            this.gbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOutput.Controls.Add(this.txtOutput);
            this.gbOutput.Location = new System.Drawing.Point(394, 9);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(453, 642);
            this.gbOutput.TabIndex = 26;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output";
            // 
            // btnClearOut
            // 
            this.btnClearOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClearOut.Location = new System.Drawing.Point(337, 72);
            this.btnClearOut.Name = "btnClearOut";
            this.btnClearOut.Size = new System.Drawing.Size(54, 23);
            this.btnClearOut.TabIndex = 28;
            this.btnClearOut.Text = "Clear >";
            this.btnClearOut.UseVisualStyleBackColor = true;
            this.btnClearOut.Click += new System.EventHandler(this.btnClearOut_Click);
            // 
            // ckbSEPOpenGUI
            // 
            this.ckbSEPOpenGUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbSEPOpenGUI.AutoSize = true;
            this.ckbSEPOpenGUI.Location = new System.Drawing.Point(120, 19);
            this.ckbSEPOpenGUI.Name = "ckbSEPOpenGUI";
            this.ckbSEPOpenGUI.Size = new System.Drawing.Size(74, 17);
            this.ckbSEPOpenGUI.TabIndex = 4;
            this.ckbSEPOpenGUI.Text = "Open GUI";
            this.ckbSEPOpenGUI.UseVisualStyleBackColor = true;
            // 
            // gbSEP
            // 
            this.gbSEP.Controls.Add(this.ckbSEPUpdateConfig);
            this.gbSEP.Controls.Add(this.ckbSEPUpdateComms);
            this.gbSEP.Controls.Add(this.ckbSEPRunInstall);
            this.gbSEP.Controls.Add(this.ckbSEPOpenGUI);
            this.gbSEP.Location = new System.Drawing.Point(172, 469);
            this.gbSEP.Name = "gbSEP";
            this.gbSEP.Size = new System.Drawing.Size(200, 63);
            this.gbSEP.TabIndex = 10;
            this.gbSEP.TabStop = false;
            this.gbSEP.Text = "SEP";
            // 
            // ckbSEPUpdateConfig
            // 
            this.ckbSEPUpdateConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbSEPUpdateConfig.AutoSize = true;
            this.ckbSEPUpdateConfig.Location = new System.Drawing.Point(16, 40);
            this.ckbSEPUpdateConfig.Name = "ckbSEPUpdateConfig";
            this.ckbSEPUpdateConfig.Size = new System.Drawing.Size(94, 17);
            this.ckbSEPUpdateConfig.TabIndex = 7;
            this.ckbSEPUpdateConfig.Text = "Update Config";
            this.ckbSEPUpdateConfig.UseVisualStyleBackColor = true;
            // 
            // ckbSEPUpdateComms
            // 
            this.ckbSEPUpdateComms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbSEPUpdateComms.AutoSize = true;
            this.ckbSEPUpdateComms.Location = new System.Drawing.Point(16, 19);
            this.ckbSEPUpdateComms.Name = "ckbSEPUpdateComms";
            this.ckbSEPUpdateComms.Size = new System.Drawing.Size(98, 17);
            this.ckbSEPUpdateComms.TabIndex = 6;
            this.ckbSEPUpdateComms.Text = "Update Comms";
            this.ckbSEPUpdateComms.UseVisualStyleBackColor = true;
            // 
            // ckbSEPRunInstall
            // 
            this.ckbSEPRunInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbSEPRunInstall.AutoSize = true;
            this.ckbSEPRunInstall.Location = new System.Drawing.Point(120, 40);
            this.ckbSEPRunInstall.Name = "ckbSEPRunInstall";
            this.ckbSEPRunInstall.Size = new System.Drawing.Size(76, 17);
            this.ckbSEPRunInstall.TabIndex = 5;
            this.ckbSEPRunInstall.Text = "Run Install";
            this.ckbSEPRunInstall.UseVisualStyleBackColor = true;
            // 
            // ListActions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 661);
            this.Controls.Add(this.gbSEP);
            this.Controls.Add(this.btnClearOut);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.ckbWSAdmin);
            this.Controls.Add(this.ckbZip);
            this.Controls.Add(this.ckbTrickle);
            this.Controls.Add(this.ckbRIMulti);
            this.Controls.Add(this.gbAction);
            this.Controls.Add(this.gbServices);
            this.Controls.Add(this.ckbFastPrinter);
            this.Controls.Add(this.ckbDisableStartupRepair);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.gbProgram);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(875, 700);
            this.MinimumSize = new System.Drawing.Size(875, 700);
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
            this.gbOutput.ResumeLayout(false);
            this.gbOutput.PerformLayout();
            this.gbSEP.ResumeLayout(false);
            this.gbSEP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtList;
		private System.Windows.Forms.Label label1;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public System.Windows.Forms.Button btnOK;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		private System.Windows.Forms.GroupBox gbProgram;
		private System.Windows.Forms.CheckBox ckbMulti;
		private System.Windows.Forms.CheckBox ckbCMD;
		private System.Windows.Forms.CheckBox ckbDameware;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public System.Windows.Forms.Button btnClear;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		private System.Windows.Forms.CheckBox ckbDisableStartupRepair;
		private System.Windows.Forms.CheckBox ckbFastPrinter;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public System.Windows.Forms.GroupBox gbAction;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public System.Windows.Forms.RadioButton rbStart;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public System.Windows.Forms.RadioButton rbRestart;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public System.Windows.Forms.RadioButton rbStop;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public System.Windows.Forms.GroupBox gbServices;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public System.Windows.Forms.RadioButton rbTransnet;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public System.Windows.Forms.RadioButton rbCredit;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public System.Windows.Forms.RadioButton rbSQL;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public System.Windows.Forms.RadioButton rbVerifone;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public System.Windows.Forms.RadioButton rbCitrix;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		private System.Windows.Forms.CheckBox ckbRIMulti;
		private System.Windows.Forms.CheckBox ckbTrickle;
		private System.Windows.Forms.CheckBox ckbZip;
		private System.Windows.Forms.CheckBox ckbWSAdmin;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.GroupBox gbOutput;
        public System.Windows.Forms.Button btnClearOut;
        private System.Windows.Forms.CheckBox ckb5;
        private System.Windows.Forms.CheckBox ckb6;
        private System.Windows.Forms.CheckBox ckbPing;
        public System.Windows.Forms.RadioButton rbSep;
        public System.Windows.Forms.RadioButton rbTripwire;
        public System.Windows.Forms.RadioButton rbBit9;
        private System.Windows.Forms.CheckBox ckbSEPOpenGUI;
        private System.Windows.Forms.GroupBox gbSEP;
        private System.Windows.Forms.CheckBox ckbSEPRunInstall;
        private System.Windows.Forms.CheckBox ckbSEPUpdateConfig;
        private System.Windows.Forms.CheckBox ckbSEPUpdateComms;
    }
}