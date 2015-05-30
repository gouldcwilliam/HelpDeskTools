namespace Retail_HD.Forms
{
	partial class EditSettings
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
			this.gbSQL = new System.Windows.Forms.GroupBox();
			this.lblDatabase = new System.Windows.Forms.Label();
			this.lblServerName = new System.Windows.Forms.Label();
			this.txtDatabase = new System.Windows.Forms.TextBox();
			this.txtServerName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtTempBatFile = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.ckbEnableShowMe = new System.Windows.Forms.CheckBox();
			this.ckbShowLoggedOut = new System.Windows.Forms.CheckBox();
			this.btnPhoneSettings = new System.Windows.Forms.Button();
			this.ckbEnableAutoReady = new System.Windows.Forms.CheckBox();
			this.ckbEnableAgentLogin = new System.Windows.Forms.CheckBox();
			this.gbSQL.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbSQL
			// 
			this.gbSQL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbSQL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.gbSQL.Controls.Add(this.lblDatabase);
			this.gbSQL.Controls.Add(this.lblServerName);
			this.gbSQL.Controls.Add(this.txtDatabase);
			this.gbSQL.Controls.Add(this.txtServerName);
			this.gbSQL.Location = new System.Drawing.Point(12, 12);
			this.gbSQL.Name = "gbSQL";
			this.gbSQL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.gbSQL.Size = new System.Drawing.Size(241, 123);
			this.gbSQL.TabIndex = 0;
			this.gbSQL.TabStop = false;
			this.gbSQL.Text = "SQL";
			// 
			// lblDatabase
			// 
			this.lblDatabase.AutoSize = true;
			this.lblDatabase.Location = new System.Drawing.Point(6, 68);
			this.lblDatabase.Name = "lblDatabase";
			this.lblDatabase.Size = new System.Drawing.Size(53, 13);
			this.lblDatabase.TabIndex = 4;
			this.lblDatabase.Text = "Database";
			// 
			// lblServerName
			// 
			this.lblServerName.AutoSize = true;
			this.lblServerName.Location = new System.Drawing.Point(6, 16);
			this.lblServerName.Name = "lblServerName";
			this.lblServerName.Size = new System.Drawing.Size(69, 13);
			this.lblServerName.TabIndex = 2;
			this.lblServerName.Text = "Server Name";
			// 
			// txtDatabase
			// 
			this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDatabase.Location = new System.Drawing.Point(6, 84);
			this.txtDatabase.MinimumSize = new System.Drawing.Size(127, 20);
			this.txtDatabase.Name = "txtDatabase";
			this.txtDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtDatabase.Size = new System.Drawing.Size(229, 20);
			this.txtDatabase.TabIndex = 1;
			this.txtDatabase.TextChanged += new System.EventHandler(this.SettingChanged);
			// 
			// txtServerName
			// 
			this.txtServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtServerName.Location = new System.Drawing.Point(6, 32);
			this.txtServerName.MinimumSize = new System.Drawing.Size(146, 20);
			this.txtServerName.Name = "txtServerName";
			this.txtServerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtServerName.Size = new System.Drawing.Size(229, 20);
			this.txtServerName.TabIndex = 0;
			this.txtServerName.TextChanged += new System.EventHandler(this.SettingChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 148);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(139, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Temporary Bat File Location";
			// 
			// txtTempBatFile
			// 
			this.txtTempBatFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTempBatFile.Location = new System.Drawing.Point(18, 163);
			this.txtTempBatFile.Name = "txtTempBatFile";
			this.txtTempBatFile.Size = new System.Drawing.Size(229, 20);
			this.txtTempBatFile.TabIndex = 2;
			this.txtTempBatFile.TextChanged += new System.EventHandler(this.SettingChanged);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(16, 371);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(96, 371);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.Enabled = false;
			this.btnApply.Location = new System.Drawing.Point(178, 371);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 5;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// ckbEnableShowMe
			// 
			this.ckbEnableShowMe.AutoSize = true;
			this.ckbEnableShowMe.Checked = true;
			this.ckbEnableShowMe.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbEnableShowMe.Location = new System.Drawing.Point(18, 253);
			this.ckbEnableShowMe.Name = "ckbEnableShowMe";
			this.ckbEnableShowMe.Size = new System.Drawing.Size(151, 17);
			this.ckbEnableShowMe.TabIndex = 7;
			this.ckbEnableShowMe.Text = "Show me in Agent Status?";
			this.ckbEnableShowMe.UseVisualStyleBackColor = true;
			this.ckbEnableShowMe.CheckedChanged += new System.EventHandler(this.SettingChanged);
			// 
			// ckbShowLoggedOut
			// 
			this.ckbShowLoggedOut.AutoSize = true;
			this.ckbShowLoggedOut.Location = new System.Drawing.Point(18, 276);
			this.ckbShowLoggedOut.Name = "ckbShowLoggedOut";
			this.ckbShowLoggedOut.Size = new System.Drawing.Size(223, 17);
			this.ckbShowLoggedOut.TabIndex = 8;
			this.ckbShowLoggedOut.Text = "Show Logged Out Users in Agent Status?";
			this.ckbShowLoggedOut.UseVisualStyleBackColor = true;
			this.ckbShowLoggedOut.Visible = false;
			this.ckbShowLoggedOut.CheckedChanged += new System.EventHandler(this.SettingChanged);
			// 
			// btnPhoneSettings
			// 
			this.btnPhoneSettings.Location = new System.Drawing.Point(18, 322);
			this.btnPhoneSettings.Name = "btnPhoneSettings";
			this.btnPhoneSettings.Size = new System.Drawing.Size(235, 23);
			this.btnPhoneSettings.TabIndex = 9;
			this.btnPhoneSettings.Text = "Cisco Call Center Settings";
			this.btnPhoneSettings.UseVisualStyleBackColor = true;
			this.btnPhoneSettings.Click += new System.EventHandler(this.btnPhoneSettings_Click);
			// 
			// ckbEnableAutoReady
			// 
			this.ckbEnableAutoReady.AutoSize = true;
			this.ckbEnableAutoReady.Checked = true;
			this.ckbEnableAutoReady.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbEnableAutoReady.Location = new System.Drawing.Point(19, 230);
			this.ckbEnableAutoReady.Name = "ckbEnableAutoReady";
			this.ckbEnableAutoReady.Size = new System.Drawing.Size(124, 17);
			this.ckbEnableAutoReady.TabIndex = 10;
			this.ckbEnableAutoReady.Text = "Enable Auto-Ready?";
			this.ckbEnableAutoReady.UseVisualStyleBackColor = true;
			this.ckbEnableAutoReady.CheckedChanged += new System.EventHandler(this.SettingChanged);
			// 
			// ckbEnableAgentLogin
			// 
			this.ckbEnableAgentLogin.AutoSize = true;
			this.ckbEnableAgentLogin.Checked = true;
			this.ckbEnableAgentLogin.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbEnableAgentLogin.Location = new System.Drawing.Point(19, 207);
			this.ckbEnableAgentLogin.Name = "ckbEnableAgentLogin";
			this.ckbEnableAgentLogin.Size = new System.Drawing.Size(125, 17);
			this.ckbEnableAgentLogin.TabIndex = 11;
			this.ckbEnableAgentLogin.Text = "Enable Agent Login?";
			this.ckbEnableAgentLogin.UseVisualStyleBackColor = true;
			this.ckbEnableAgentLogin.CheckedChanged += new System.EventHandler(this.SettingChanged);
			// 
			// EditSettings
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(265, 406);
			this.Controls.Add(this.ckbEnableAgentLogin);
			this.Controls.Add(this.ckbEnableAutoReady);
			this.Controls.Add(this.btnPhoneSettings);
			this.Controls.Add(this.ckbShowLoggedOut);
			this.Controls.Add(this.ckbEnableShowMe);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtTempBatFile);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.gbSQL);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = global::Retail_HD.GlobalResources.icoMain;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(272, 280);
			this.Name = "EditSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.EditSettings_Load);
			this.gbSQL.ResumeLayout(false);
			this.gbSQL.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbSQL;
		private System.Windows.Forms.TextBox txtServerName;
		private System.Windows.Forms.Label lblServerName;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.Label lblDatabase;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTempBatFile;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox ckbEnableShowMe;
        private System.Windows.Forms.CheckBox ckbShowLoggedOut;
        private System.Windows.Forms.Button btnPhoneSettings;
        private System.Windows.Forms.CheckBox ckbEnableAutoReady;
		private System.Windows.Forms.CheckBox ckbEnableAgentLogin;
	}
}