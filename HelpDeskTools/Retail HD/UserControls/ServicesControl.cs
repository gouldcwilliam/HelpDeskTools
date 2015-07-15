using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retail_HD.UCs
{
	public partial class ServicesControl : UserControl
	{
		public ServicesControl()
		{
			InitializeComponent();
		}

		public void Clear()
		{
			this.rbCredit.Checked = false;
			this.rbRestart.Checked = false;
			this.rbSQL.Checked = false;
			this.rbStart.Checked = false;
			this.rbStop.Checked = false;
			this.rbPCA.Checked = false;
			this.rbCitrix.Checked = false;
            this.rbVerifone.Checked = false;
            this.rbTransnet.Checked = false;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
            string service = string.Empty;
            string action = string.Empty;

            foreach (RadioButton rb in gbServices.Controls.OfType<RadioButton>())
            {
                if (rb.Checked) { service = rb.Tag.ToString(); }
            }
            foreach (RadioButton rb in gbAction.Controls.OfType<RadioButton>())
            {
                if (rb.Checked) { action = rb.Tag.ToString(); }
            }
            if (action == string.Empty || service == string.Empty) { return; }

            
            if (!GlobalFunctions.b_WriteBatFile(GlobalResources.batServices)) { return; }

            foreach (Computer computer in Info.computers.FindAll(x => x.selected == true))
            {
                if (!GlobalFunctions.b_CopyBatFile(computer.name)) { return; }

                string args = string.Format("-r:{0} {1} {2}", computer.name, Shared.Settings.Default._TempFile, action + " " + service);
                
                GlobalFunctions.i_ExecuteCommand("WINRS", true, args, false);
            }
		}

        private void rbCitrix_CheckedChanged(object sender, EventArgs e)
        {
            rbRestart.Enabled = (!rbCitrix.Checked);
            rbStart.Enabled = (!rbCitrix.Checked);
        }

        private void rbVerifone_CheckedChanged(object sender, EventArgs e)
        {
            rbStart.Enabled = (!rbVerifone.Checked);
            rbStop.Enabled = (!rbVerifone.Checked);
        }

	}
}
