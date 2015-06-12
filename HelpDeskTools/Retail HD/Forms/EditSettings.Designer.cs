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
            this.ckbEnableShowMe = new System.Windows.Forms.CheckBox();
            this.ckbShowLoggedOut = new System.Windows.Forms.CheckBox();
            this.ckbEnableAutoReady = new System.Windows.Forms.CheckBox();
            this.ckbEnableAgentLogin = new System.Windows.Forms.CheckBox();
            this.btnPhoneSettings = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ckbEnableShowMe
            // 
            this.ckbEnableShowMe.AutoSize = true;
            this.ckbEnableShowMe.Checked = true;
            this.ckbEnableShowMe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbEnableShowMe.Location = new System.Drawing.Point(11, 58);
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
            this.ckbShowLoggedOut.Location = new System.Drawing.Point(11, 81);
            this.ckbShowLoggedOut.Name = "ckbShowLoggedOut";
            this.ckbShowLoggedOut.Size = new System.Drawing.Size(223, 17);
            this.ckbShowLoggedOut.TabIndex = 8;
            this.ckbShowLoggedOut.Text = "Show Logged Out Users in Agent Status?";
            this.ckbShowLoggedOut.UseVisualStyleBackColor = true;
            this.ckbShowLoggedOut.Visible = false;
            this.ckbShowLoggedOut.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // ckbEnableAutoReady
            // 
            this.ckbEnableAutoReady.AutoSize = true;
            this.ckbEnableAutoReady.Checked = true;
            this.ckbEnableAutoReady.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbEnableAutoReady.Location = new System.Drawing.Point(12, 35);
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
            this.ckbEnableAgentLogin.Location = new System.Drawing.Point(12, 12);
            this.ckbEnableAgentLogin.Name = "ckbEnableAgentLogin";
            this.ckbEnableAgentLogin.Size = new System.Drawing.Size(125, 17);
            this.ckbEnableAgentLogin.TabIndex = 11;
            this.ckbEnableAgentLogin.Text = "Enable Agent Login?";
            this.ckbEnableAgentLogin.UseVisualStyleBackColor = true;
            this.ckbEnableAgentLogin.CheckedChanged += new System.EventHandler(this.SettingChanged);
            // 
            // btnPhoneSettings
            // 
            this.btnPhoneSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhoneSettings.Location = new System.Drawing.Point(13, 178);
            this.btnPhoneSettings.Name = "btnPhoneSettings";
            this.btnPhoneSettings.Size = new System.Drawing.Size(235, 23);
            this.btnPhoneSettings.TabIndex = 15;
            this.btnPhoneSettings.Text = "Cisco Call Center Settings";
            this.btnPhoneSettings.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(173, 211);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 14;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(91, 211);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(11, 211);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // EditSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 246);
            this.Controls.Add(this.btnPhoneSettings);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ckbEnableAgentLogin);
            this.Controls.Add(this.ckbEnableAutoReady);
            this.Controls.Add(this.ckbShowLoggedOut);
            this.Controls.Add(this.ckbEnableShowMe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = global::Retail_HD.GlobalResources.icoMain;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(272, 280);
            this.Name = "EditSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.EditSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.CheckBox ckbEnableShowMe;
        private System.Windows.Forms.CheckBox ckbShowLoggedOut;
        private System.Windows.Forms.CheckBox ckbEnableAutoReady;
		private System.Windows.Forms.CheckBox ckbEnableAgentLogin;
        private System.Windows.Forms.Button btnPhoneSettings;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
	}
}