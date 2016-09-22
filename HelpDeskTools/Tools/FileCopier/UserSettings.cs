using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCopier
{
    public partial class UserSettings : Form
    {
        public UserSettings()
        {
            InitializeComponent();
        }

        private void UserSettings_Load(object sender, EventArgs e)
        {
            this.textBoxEmail.Text = Properties.Settings.Default._To;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default._To = this.textBoxEmail.Text;
            Properties.Settings.Default.Save();
        }
    }
}
