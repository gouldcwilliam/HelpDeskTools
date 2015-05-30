using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shared.Forms
{
    public partial class frmPasswordChange : Form
    {
        string username = string.Empty;

        public frmPasswordChange(string usr)
        {
            InitializeComponent();
            username = usr;
            this.Text = "Change Password for: " + username;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //verify they actually want to do this first
            if (MessageBox.Show(string.Format("Are you sure you want to change the password to: {0}", txtPWD.Text), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (Functions.ResetUserPWDAD(username, txtPWD.Text))
                {
                    if (MessageBox.Show("Password has been changed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else MessageBox.Show("Unable to change password, due to an Active Directory error (not specified)", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PasswordChange_Load(object sender, EventArgs e)
        {
            this.Text = "Change Password for: " + username;
            txtPWD.Focus();
        }
    }
}
