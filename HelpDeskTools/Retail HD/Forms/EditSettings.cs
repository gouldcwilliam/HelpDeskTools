using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retail_HD.Forms
{
	public partial class EditSettings : Form
	{
        private bool hasSettingsChanged = false;
        private bool isLoading = false;

		public EditSettings()
		{
            isLoading = true;
			InitializeComponent();

			this.txtServerName.Text = Setting.SQL.Default._ServerName;
			this.txtDatabase.Text = Setting.SQL.Default._Database;
			this.txtTempBatFile.Text = HDSharedServices.Settings.Default._TempFile;
            this.ckbShowLoggedOut.Checked = HDSharedServices.Settings.Default._ShowLoggedOutUsers;
            this.ckbEnableShowMe.Checked = HDSharedServices.Settings.Default._ShowMeInAgentStatus;
            this.ckbEnableAutoReady.Checked = HDSharedServices.Settings.Default._EnableAutoReady;
			this.ckbEnableAgentLogin.Checked = HDSharedServices.Settings.Default._LoginEnabled;
            isLoading = false;
		}

		private void vSaveChanges()
		{
			Setting.SQL.Default._ServerName = this.txtServerName.Text;
			Setting.SQL.Default._Database = this.txtDatabase.Text;
			HDSharedServices.Settings.Default._TempFile = this.txtTempBatFile.Text;
            HDSharedServices.Settings.Default._ShowLoggedOutUsers = this.ckbShowLoggedOut.Checked;
            HDSharedServices.Settings.Default._ShowMeInAgentStatus = this.ckbEnableShowMe.Checked;
            HDSharedServices.Settings.Default._EnableAutoReady = this.ckbEnableAutoReady.Checked;
			HDSharedServices.Settings.Default._LoginEnabled = this.ckbEnableAgentLogin.Checked;
			HDSharedServices.Settings.Default.Save();

            btnApply.Enabled = false;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if(hasSettingsChanged) this.vSaveChanges(); //prevents multiple executions of saving

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			this.vSaveChanges();
		}

        private void btnPhoneSettings_Click(object sender, EventArgs e)
        {
            HDSharedServices.Forms.frmCiscoLogin loginSettings = new HDSharedServices.Forms.frmCiscoLogin("");
            //frmCiscoLogin loginSettings = new frmCiscoLogin("");
            loginSettings.ShowDialog();
        }

        private void EditSettings_Load(object sender, EventArgs e)
        {
            //check for supervisor switch
            //if ((CiscoFinesseNET.Helper.loggedInUser.role & CiscoFinesseNET.Role.Supervisor) == CiscoFinesseNET.Role.Supervisor)
            //{
            //    ckbShowLoggedOut.Visible = true;
            //}
            //else
            //{
            //    ckbShowLoggedOut.Visible = false;
            //}

            //this does the same as above, but on one line
            ckbShowLoggedOut.Visible = ((CiscoFinesseNET.Helper.loggedInUser.role & CiscoFinesseNET.Role.Supervisor) == CiscoFinesseNET.Role.Supervisor) ? true : false;
        }

        private void SettingChanged(object sender, EventArgs e)
        {
            //if we are loading initial values, don't enable the apply button
            if (isLoading) return;

            //set to false, so if nothing has changed, it is still false
            hasSettingsChanged = false;
            //check if any settings is different
            if (this.txtServerName.Text == Setting.SQL.Default._ServerName) hasSettingsChanged = true;
            if (this.txtDatabase.Text == Setting.SQL.Default._Database) hasSettingsChanged = true;
            if (this.txtTempBatFile.Text == HDSharedServices.Settings.Default._TempFile) hasSettingsChanged = true;
            if (this.ckbShowLoggedOut.Checked == HDSharedServices.Settings.Default._ShowLoggedOutUsers) hasSettingsChanged = true;
            if (this.ckbEnableShowMe.Checked == HDSharedServices.Settings.Default._ShowMeInAgentStatus) hasSettingsChanged = true;
            if (this.ckbEnableAutoReady.Checked == HDSharedServices.Settings.Default._EnableAutoReady) hasSettingsChanged = true;
			if (this.ckbEnableAgentLogin.Checked == HDSharedServices.Settings.Default._LoginEnabled) hasSettingsChanged = true;

            btnApply.Enabled = hasSettingsChanged;
        }
	}
}
