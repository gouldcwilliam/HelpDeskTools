using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Retail_HD.Forms
{
    // TODO - merge this with EditSettings form
    /// <summary>
    /// Settings window for cisco
    /// </summary>
    public partial class CiscoSettings : Form
    {
        /// <summary>
        /// this is the output object
        /// </summary>
		public Classes.CiscoSettings ciscoSettings { get; private set; }
        bool isChangeSettings = false;

        /// <summary>
        /// Form for Cisco call center's user settings
        /// </summary>
        public CiscoSettings()
        {
            InitializeComponent();

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// Form for Cisco call center's user settings
        /// </summary>
        /// <seealso cref="CiscoSettings()">
        /// </seealso>
        /// <param name="settings">location of file?..</param>
        public CiscoSettings(string settings)
        {
            InitializeComponent();

            //this constructor is for changing the settings
            isChangeSettings = true;
            txtUsername.Text = CiscoFinesseNET.Init.mainSettings.userName;
            //txtPassword.Text = CiscoFinesseNET.Init.mainSettings.password;
            txtServerAddress.Text = CiscoFinesseNET.Init.mainSettings.GetNakedFQDN();
            txtPort.Text = CiscoFinesseNET.Init.mainSettings.port.ToString();
            txtDataStore.Text = CiscoFinesseNET.Init.mainSettings.GetSaveLocation(false);
            txtACD.Text = CiscoFinesseNET.Init.mainSettings.ACD;
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
            if (ciscoSettings != null) { }
            else
            {
				ciscoSettings = new Classes.CiscoSettings();
            }

            if (ValidateSettings())
            {
                //continue to save
                if (!Directory.Exists(txtDataStore.Text))
                {
                    //create directory
                    Directory.CreateDirectory(txtDataStore.Text);
                }

                CiscoFinesseNET.Helper.RunConfiguration(txtDataStore.Text, txtServerAddress.Text, int.Parse(txtPort.Text), ckbUseHTTPS.Checked);
                //this needs to be refactored into a return value for this form to allow for mulitple projects to get and use this information
                //this code is being left in currently for compatibility, but is depricated for new usage
                ciscoSettings.s_AgentACD = txtACD.Text;
                ciscoSettings.s_AgentPassword = txtPassword.Text;
                ciscoSettings.s_AgentUsername = txtUsername.Text;

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

        private void frmCiscoLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != System.Windows.Forms.DialogResult.OK && !isChangeSettings)
            {
                Application.Exit();
            }
        }
    }
}
