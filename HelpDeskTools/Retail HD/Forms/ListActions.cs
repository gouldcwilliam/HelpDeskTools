using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;
using System.Windows.Forms;

namespace Retail_HD.Forms
{
	public partial class ListActions : Form
	{
		public ListActions()
		{
			InitializeComponent();
		}



		private void btnClear_Click(object sender, EventArgs e)
		{
			ckb1.Checked = false;
			ckb2.Checked = false;
			ckb3.Checked = false;
			ckb4.Checked = false;
			ckbActivate.Checked = false;
			ckbBrowser.Checked = false;
			ckbRegister.Checked = false;
			ckbRestart.Checked = false;
			ckbService.Checked = false;

			txtList.Text = "";
			txtSuffix.Text = "";

			rbAll.Checked = false;
			rbCredit.Checked = false;
			rbRestart.Checked = false;
			rbSQL.Checked = false;
			rbStart.Checked = false;
			rbStop.Checked = false;

			ckbOpenProgram.Checked = false;
			ckbMulti.Checked = false;
			ckbCMD.Checked = false;
			ckbAltiris.Checked = false;

			ckbInstallEndpoint.Checked = false;
			ckbFastPrinter.Checked = false;
			ckbDisableStartupRepair.Checked = false;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
            string actionList = "Actions:" + Environment.NewLine;
			string computerList = "Computers:" + Environment.NewLine;

			// makes sure that input isn't blank
            if (txtList.Text.Trim() == string.Empty ||
				// makes sure one action is selected
				(!ckbActivate.Checked && 
				!ckbBrowser.Checked && 
				!ckbRegister.Checked && 
				!ckbRestart.Checked && 
				!ckbService.Checked && 
				!ckbOpenProgram.Checked && 
				!ckbDisableStartupRepair.Checked &&
				!ckbFastPrinter.Checked)
				) { return; }

			foreach (string stringStore in txtList.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
			{
				int store;
				if (!int.TryParse(stringStore, out store)) { continue; }

				List<string> computers = new List<string>();

				foreach(DataRow dr in Shared.SQL.dt_SelectComputers(store).Rows) { computers.Add(dr[0].ToString()); }

				if (ckbRegister.Checked) { computers = SpecificRegister(computers); }

				bool reboot = false;
				if(ckbRestart.Checked)
				{
					reboot = (MessageBox.Show("Are you sure you want to reboot?", "System Reboot", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK);
				}

				foreach (string computer in computers)
				{
					if (ckbService.Checked)
					{
						string action = getAction();
						string service = getService();

						if (action != string.Empty && service != string.Empty)
						{
							
                                if (!GlobalFunctions.b_CopyFile(computer, Shared.Settings.Default._BatServices)) { MessageBox.Show("An error occurred copying batch files.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break; }

								string args = string.Format("-r:{0} {1} {2}", computer, Shared.Settings.Default._BatServices, action + " " + service);
								GlobalFunctions.i_ExecuteCommand("WINRS", true, args, false);
							
						}

                        actionList += computer + " had services restarted.\n";
					}

					if (ckbBrowser.Checked)
					{
						string suffix = txtSuffix.Text.ToLower().Replace("c:", "");
						GlobalFunctions.v_BrowseComputer(computer, suffix);

                        actionList += computer + " had file browser opened.\n";
					}

					if (ckbOpenProgram.Checked)
					{
						if (ckbMulti.Checked) { GlobalFunctions.Multi(computer); actionList += " Opened Multi"; }
						if (ckbAltiris.Checked) { GlobalFunctions.v_ConnectWithAltiris(computer); actionList += " Opened Altiris"; }
						if (ckbCMD.Checked) { GlobalFunctions.v_LocalCMD(computer); actionList += " Opened CMD"; }
					}

					if (ckbActivate.Checked)
					{
						GlobalFunctions.i_ExecuteCommand("WINRS", true, String.Format("-r:{0} SLMGR.VBS /IPK FJ82H-XT6CR-J8D7P-XQJJ2-GPDD4 && SLMGR /ATO", computer), false);
                        actionList += computer + " had Windows activated.\n";
					}

					if (ckbInstallEndpoint.Checked)
					{
						GlobalFunctions.b_WriteBatFile(GlobalResources.batInstallEndpoint12);
						GlobalFunctions.b_CopyBatFile(computer);
						GlobalFunctions.v_InstallSemantic(computer);
					}

					if(reboot)
					{
						string args = string.Format("-r:{0} SHUTDOWN /f /r /t 0", computer);
						GlobalFunctions.i_ExecuteCommand("WINRS", true, args, false);
                        actionList += computer + " was restarted.\n";
					}
					if(ckbDisableStartupRepair.Checked)
					{
						int retCode = GlobalFunctions.i_ExecuteCommand("WINRS", true, String.Format("-r:{0} ",computer) + "bcdedit /set {default} recoveryenabled no && bcdedit /set {default} bootstatuspolicy ignoreallfailures", true);
						actionList += String.Format("{0} startup repair disable returned: {1}.\n",computer,retCode);
					}
					if(ckbFastPrinter.Checked)
					{
						string args = string.Format("-r:{0} TASKKILL /F /IM POSW.EXE", computer);
						GlobalFunctions.i_ExecuteCommand("WINRS", false, args, false);
						args = string.Format("\\\\{0} -s -d -i \"\\Program Files\\EPSON\\BA-T500II Software\\BA500IIUTL\\BA500IIUTL.EXE\"", computer);
                        GlobalFunctions.v_LocalCMD(computer);
						GlobalFunctions.i_ExecuteCommand("PSEXEC", true, args, false);
						args = string.Format("\\\\{0} -s -d -i \"\\Program Files\\OPOS\\Epson2\\SetupPOS.exe\"", computer);
						GlobalFunctions.i_ExecuteCommand("PSEXEC", true, args, false);
					}

					System.Threading.Thread.Sleep(500);
				}
			}
            //TODO implement action log window instead of a popup message.
            //MessageBox.Show(actionList, "Completed", MessageBoxButtons.OK);
		}

		private string getAction()
		{
			string value = string.Empty;

			if (rbStart.Checked) { value = rbStart.Tag.ToString(); }
			if (rbStop.Checked) { value = rbStop.Tag.ToString(); }
			if (rbRestart.Checked) { value = rbRestart.Tag.ToString(); }

			return value;
		}

		private string getService()
		{
			string value = string.Empty;

			if (rbAll.Checked) { value = rbAll.Tag.ToString(); }
			if (rbCredit.Checked) { value = rbCredit.Tag.ToString(); }
			if (rbSQL.Checked) { value = rbSQL.Tag.ToString(); }

			return value;
		}

		private List<string> SpecificRegister(List<string> Computers)
		{
			if (!ckb1.Checked) { Computers.Remove(Computers.Find(x => x.Contains("SAP" + ckb1.Text))); }
			if (!ckb2.Checked) { Computers.Remove(Computers.Find(x => x.Contains("SAP" + ckb2.Text))); }
			if (!ckb3.Checked) { Computers.Remove(Computers.Find(x => x.Contains("SAP" + ckb3.Text))); }
			if (!ckb4.Checked) { Computers.Remove(Computers.Find(x => x.Contains("SAP" + ckb4.Text))); }

			return Computers;
		}


		private void ckbService_CheckedChanged(object sender, EventArgs e)
		{
			gbAction.Visible = ckbService.Checked;
			gbServices.Visible = ckbService.Checked;
		}

		private void ckbRegister_CheckedChanged(object sender, EventArgs e)
		{
			gbRegister.Visible = ckbRegister.Checked;
		}

		private void ckbBrowser_CheckedChanged(object sender, EventArgs e)
		{
			txtSuffix.Visible = ckbBrowser.Checked;
			lblSuffix.Visible = ckbBrowser.Checked;
		}


		private void ckbOpenProgram_CheckedChanged(object sender, EventArgs e)
		{
			gbProgram.Visible = ckbOpenProgram.Checked;
		}

	}
}
