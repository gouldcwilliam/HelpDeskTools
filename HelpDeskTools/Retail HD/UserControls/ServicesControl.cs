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

		List<Computer> _computers
		{
			get
			{
				List<Computer> retList = Info.computers.FindAll(x => x.selected == true);
				if (retList.Count < 1)
				{
					if (Info.computers.Count == 1) { return Info.computers; }
					Forms.Confirm confirm = new Forms.Confirm("Perform on all computers?", "No computers selected", true);
					if (confirm.ShowDialog() == System.Windows.Forms.DialogResult.OK) { return Info.computers; }
					return new List<Computer>();
				}
				else { return retList; }
			}
		}

		public void Clear()
		{
            foreach (RadioButton rb in gbServices.Controls.OfType<RadioButton>())
            {
                rb.Checked = false;
            }
            foreach (RadioButton rb in gbAction.Controls.OfType<RadioButton>())
            {
                rb.Checked = false;
            }
        }

		private void btnOK_Click(object sender, EventArgs e)
		{
            string service = string.Empty;
            string action = string.Empty;
			List<Computer> computers = new List<Computer>();

            foreach (RadioButton rb in gbServices.Controls.OfType<RadioButton>()) { if (rb.Checked) { service = rb.Tag.ToString(); } }
            foreach (RadioButton rb in gbAction.Controls.OfType<RadioButton>()) { if (rb.Checked) { action = rb.Tag.ToString(); } }

            Console.WriteLine("action: " + action + " service: " + service);
            if (action == string.Empty || service == string.Empty) { return; }
            
			if (service == "sql") { computers.Add(new Computer(Info.reg1)); }
			else { computers = _computers; }

            foreach (string computer in computers)
            {
                if (!Shared.Functions.DnsLookup(computer)) { continue; }
                if (!GlobalFunctions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices)) { return; }
                if (service == "verifone") 
                {
                    Forms.VerifoneConfirm sfv = new Forms.VerifoneConfirm(computer);
					if (!GlobalFunctions.CopyArgsXML(computer)) { return; };
					string args = string.Format("-r:{0} {1} {2}",computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, "restart verifone");
					GlobalFunctions.ExecuteCommand("WINRS", args, true, false);
					sfv.Show();
                }
                else
                {
                    string args = string.Format("-r:{0} {1} {2}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, action + " " + service);
                    GlobalFunctions.ExecuteCommand("WINRS", args, true, false);
                }
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
