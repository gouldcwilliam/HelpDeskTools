using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Shared;

namespace Retail_HD.UCs
{
    /// <summary>
    /// User control for the services sub menu
    /// </summary>
	public partial class ServicesControl : UserControl
	{
		/// <summary>
		/// <see cref=" ServicesControl"/>
		/// </summary>
		public ServicesControl()
		{
			InitializeComponent();
		}

		List<Computer> _computers
		{
			get
			{
				return Info.selectedComputers;
			}
		}

		/// <summary>
		/// clears the user control
		/// </summary>
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

        // TODO - remove steps for copying bat file

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
                if (!Shared.Functions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices)) { return; }
                if (service == "verifone") 
                {
                    Forms.VerifoneConfirm sfv = new Forms.VerifoneConfirm(computer);
					if (!Shared.Functions.CopyArgsXML(computer)) { return; };
					string args = string.Format("-r:{0} {1} {2}",computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, "restart verifone");
					Shared.Functions.ExecuteCommand("WINRS", args, true, false);
					sfv.Show();
                }
                else
                {
                    string args = string.Format("-r:{0} {1} {2}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, action + " " + service);
					Shared.Functions.ExecuteCommand("WINRS", args, true, false);
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
