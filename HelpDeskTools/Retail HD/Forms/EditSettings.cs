using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;

namespace Retail_HD.Forms
{
	public partial class EditSettings : Form
	{
        private bool hasSettingsChanged = false;
        private bool isLoading = false;
		//private Shared.Config.PerUser userPrefs = Shared.Config.PerUser.Load();
		public EditSettings()
		{
            isLoading = true;
			InitializeComponent();

			
			this.ckbShowLoggedOut.Checked = Properties.Settings.Default._ShowLoggedOutUsers;
			//this.ckbShowLoggedOut.Checked = userPrefs.ShowLoggedOutUsers;
			this.ckbEnableShowMe.Checked = Properties.Settings.Default._ShowMeInAgentStatus;
			//this.ckbEnableShowMe.Checked = userPrefs.ShownInAgentStatus;
			this.ckbEnableAutoReady.Checked = Properties.Settings.Default._EnableAutoReady;
			//this.ckbEnableAutoReady.Checked = userPrefs.AutoReady;
			this.ckbEnableAgentLogin.Checked = Properties.Settings.Default._LoginEnabled;
			//this.ckbEnableAgentLogin.Checked = userPrefs.AutoLogin;
            isLoading = false;
		}

		private void vSaveChanges()
		{

            Properties.Settings.Default._ShowLoggedOutUsers = this.ckbShowLoggedOut.Checked;
            Properties.Settings.Default._ShowMeInAgentStatus = this.ckbEnableShowMe.Checked;
            Properties.Settings.Default._EnableAutoReady = this.ckbEnableAutoReady.Checked;
			Properties.Settings.Default._LoginEnabled = this.ckbEnableAgentLogin.Checked;
			Properties.Settings.Default.Save();
			//userPrefs.Save();
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
            Forms.frmCiscoLogin loginSettings = new Forms.frmCiscoLogin("");
            //frmCiscoLogin loginSettings = new frmCiscoLogin("");
            loginSettings.ShowDialog();
        }

        private void EditSettings_Load(object sender, EventArgs e)
        {
            //this does the same as above, but on one line
//            ckbShowLoggedOut.Visible = ((CiscoFinesseNET.Helper.loggedInUser.role & CiscoFinesseNET.Role.Supervisor) == CiscoFinesseNET.Role.Supervisor) ? true : false;
        }

        private void SettingChanged(object sender, EventArgs e)
        {
            //if we are loading initial values, don't enable the apply button
            if (isLoading) return;

            //set to false, so if nothing has changed, it is still false
            hasSettingsChanged = false;
            //check if any settings is different
 			if (this.ckbShowLoggedOut.Checked == Properties.Settings.Default._ShowLoggedOutUsers) hasSettingsChanged = true;
			//if (this.ckbShowLoggedOut.Checked == userPrefs.ShowLoggedOutUsers) hasSettingsChanged = true;
			if (this.ckbEnableShowMe.Checked == Properties.Settings.Default._ShowMeInAgentStatus) hasSettingsChanged = true;
			//if (this.ckbEnableShowMe.Checked == userPrefs.ShownInAgentStatus) hasSettingsChanged = true;
			if (this.ckbEnableAutoReady.Checked == Properties.Settings.Default._EnableAutoReady) hasSettingsChanged = true;
			//if (this.ckbEnableAutoReady.Checked == userPrefs.AutoReady) hasSettingsChanged = true;
			if (this.ckbEnableAgentLogin.Checked == Properties.Settings.Default._LoginEnabled) hasSettingsChanged = true;
			//if (this.ckbEnableAgentLogin.Checked == userPrefs.AutoLogin) hasSettingsChanged = true;

            btnApply.Enabled = hasSettingsChanged;
        }
	}
}
