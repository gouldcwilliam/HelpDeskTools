using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CiscoFinesseNET;
using System.IO;


namespace Retail_HD.Forms
{
    public partial class frmCiscoLogin : Form
    {
        //this is the output object
		public CiscoFinesseNET.CiscoSettings ciscoSettings { get; private set; }
        bool isPeoplesoftValid = false;
        bool isChangeSettings = false;

        public frmCiscoLogin()
        {
            InitializeComponent();

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public frmCiscoLogin(string settings)
        {
            InitializeComponent();

            //this constructor is for changing the settings
            isChangeSettings = true;
            txtUsername.Text = CiscoFinesseNET.Init.mainSettings.userName;
            txtPassword.Text = CiscoFinesseNET.Init.mainSettings.password;
            txtServerAddress.Text = CiscoFinesseNET.Init.mainSettings.GetNakedFQDN();
            txtPort.Text = CiscoFinesseNET.Init.mainSettings.port.ToString();
            txtDataStore.Text = CiscoFinesseNET.Init.mainSettings.GetSaveLocation(false);
            txtACD.Text = CiscoFinesseNET.Init.mainSettings.ACD;
            txtShoeboxUSR.Text = Shared.Settings.Default._PeoplesoftUsername;
            txtShoeboxPWD.Text = Shared.Settings.Default._PeoplesoftPassword;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog _fbd = new FolderBrowserDialog();
            _fbd.ShowNewFolderButton = true;
            //_fbd.RootFolder = Environment.SpecialFolder.MyDocuments;

            if (_fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDataStore.Text = _fbd.SelectedPath +"\\";
            }
        }

        private void btnSaveLogin_Click(object sender, EventArgs e)
        {
            //validate the settings
            //validate peopesoft first
            if (!isPeoplesoftValid && Shared.Settings.Default._PeoplesoftUpgrade) //ensure this doesn't fuck the world up until these changes go for real live.
            {
                if (txtShoeboxUSR.Text != string.Empty)
                {
                    if (txtShoeboxPWD.Text != string.Empty)
                    {
                        //try to log in, if successful save peoplesoft settings
                        if (Shared.Functions.LoginToPeoplesoft(txtShoeboxUSR.Text.ToUpper(), txtShoeboxPWD.Text.ToUpper()).ToLower().Contains("your user id and/or password are invalid."))
                        {
                            MessageBox.Show("Cannot login to Peoplesoft: Username or Password incorrect.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Shared.Functions.LogoutPeoplesoft();

                        Shared.Settings.Default._PeoplesoftPassword = txtShoeboxPWD.Text.ToUpper();
						Shared.Settings.Default._PeoplesoftUsername = txtShoeboxUSR.Text.ToUpper();
						Shared.Settings.Default.Save();

                        isPeoplesoftValid = true;
                    }
                    else
                    {
                        MessageBox.Show("Peoplesoft Password is not entered.", "Password Issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Peoplesoft Username is not entered.", "Username Issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (ciscoSettings != null) { }
            else
            {
				ciscoSettings = new CiscoFinesseNET.CiscoSettings();
            }

            if (ValidateSettings())
            {
                //continue to save
                if (!Directory.Exists(txtDataStore.Text))
                {
                    //create directory
                    Directory.CreateDirectory(txtDataStore.Text);
                }

                Helper.RunConfiguration(txtDataStore.Text, txtServerAddress.Text, int.Parse(txtPort.Text), ckbUseHTTPS.Checked);
                //this needs to be refactored into a return value for this form to allow for mulitple projects to get and use this information
                //this code is being left in currently for compatibility, but is depricated for new usage
                ciscoSettings.s_AgentACD = txtACD.Text;
                ciscoSettings.s_AgentPassword = txtPassword.Text;
                ciscoSettings.s_AgentUsername = txtUsername.Text;
                //compatibility below
                //=====FOR CHAD=====
                //uncomment the below variable assignments if stuff stops working
                //GlobalFunctions._pacd = txtACD.Text;
                //GlobalFunctions._ppas = txtPassword.Text;
                //GlobalFunctions._pusr = txtUsername.Text;
                //end refactoring needs

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else MessageBox.Show("Some settings entered in the Cisco area are incorrect, or incomplete.", "Error saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidateSettings()
        {
            int a, b; //useless
            if (txtUsername.Text != string.Empty)
            {
                if (txtServerAddress.Text != string.Empty)
                {
                    if(int.TryParse(txtPort.Text, out a))
                    {
                        if (txtPassword.Text != string.Empty)
                        {
                            if (txtDataStore.Text != string.Empty)
                            {
                                if(int.TryParse(txtACD.Text, out b))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        private void frmCiscoLogin_Load(object sender, EventArgs e)
        {
            //disable peoplesoft stuff for now
            txtShoeboxPWD.Enabled = Shared.Settings.Default._PeoplesoftUpgrade;
            txtShoeboxUSR.Enabled = Shared.Settings.Default._PeoplesoftUpgrade;

            if (txtUsername.Text == string.Empty)
            {
                try
                {
                    txtUsername.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
                }
                catch
                { return; }
            }
        }

        private void txtShoeboxUSR_TextChanged(object sender, EventArgs e)
        {
            if (isPeoplesoftValid) isPeoplesoftValid = false;
        }

        private void txtShoeboxPWD_TextChanged(object sender, EventArgs e)
        {
            if (isPeoplesoftValid) isPeoplesoftValid = false;
        }

        private void frmCiscoLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != System.Windows.Forms.DialogResult.OK && !isChangeSettings)
            {
                Application.Exit();
            }
        }
    }
}
