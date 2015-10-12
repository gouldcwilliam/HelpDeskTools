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
        /// <summary>
        /// 
        /// </summary>
		public ListActions()
		{
			InitializeComponent();
		}



        /// <summary>
        /// returns the service name of selected radio button
        /// </summary>
        private string _service
        {
            get
            {
                foreach (RadioButton rb in gbServices.Controls.OfType<RadioButton>())
                {
                    if (rb.Checked) { return rb.Tag.ToString(); }
                }
                return string.Empty;
            }
        }
        private string _action
        {
            get
            {
                foreach (RadioButton rb in gbAction.Controls.OfType<RadioButton>())
                {
                    if (rb.Checked) { return rb.Tag.ToString(); }
                }
                return string.Empty;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btnClear_Click(object sender, EventArgs e)
		{
            // clear all text
            foreach(TextBox tb in this.Controls.OfType<TextBox>()) { tb.Text = string.Empty; }
            // clear all check boxes outside of group boxes
            foreach (CheckBox cb in this.Controls.OfType<CheckBox>()) { cb.Checked = false; }
            // clear register# check boxes
            foreach (CheckBox cb in gbRegister.Controls.OfType<CheckBox>()) { cb.Checked = false; }
            // clear all service radios
            foreach (RadioButton rb in gbServices.Controls.OfType<RadioButton>()) { rb.Checked = false; }
            // clear all action radios
            foreach (RadioButton rb in gbAction.Controls.OfType<RadioButton>()) { rb.Checked = false; }
            // clear all program checkboxes
            foreach (CheckBox cb in gbProgram.Controls.OfType<CheckBox>()) { cb.Checked = false; }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            // exit if no store entered
            if (txtList.Text.Trim() == string.Empty) { return; }

            // load computers per store number entered
            List<string> computers = new List<string>();
            foreach (string stringStore in txtList.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
            {
                int store;
                if (!int.TryParse(stringStore, out store)) { continue; }
                // add each computer to list
                foreach (DataRow dr in Shared.SQL.dt_SelectComputers(store).Rows) { computers.Add(dr[0].ToString()); }
            }

            // only include specific computers list
            if (ckbRegister.Checked) { computers = SpecificRegister(computers); }

            // double check that a reboot is wanted
            bool reboot = false;
            if (ckbRestart.Checked) { reboot = (MessageBox.Show("Are you sure you want to reboot?", "System Reboot", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK); }

            // verify service actions selection
            bool bservices = false;
            if (ckbService.Checked && _action != string.Empty && _service != string.Empty)
            {
                bservices = true;
            }

            // perform specified actions on each computer
            foreach (string computer in computers)
            {
				Console.WriteLine(computer);
                // perform service actions
                if (bservices)
                {
					string args = string.Format("-r:{0} {1} {2}", computer, Shared.Settings.Default._BatServices, _action + " " + _service);
					if (!GlobalFunctions.b_CopyFile(computer, Shared.Settings.Default._BatServices))
					{
						// failed to copy services.bat
					}
					else
					{
						if (_service == "verifone" && !GlobalFunctions.copyArgsXML(computer))
						{
							// failed to copy args.xml
						}
						else
						{
							Console.WriteLine("WINRS {0}", args);
							GlobalFunctions.i_ExecuteCommand("WINRS", true, args, false);
						}
					}
				}


                if (ckbBrowser.Checked)
                {
                    string suffix = txtSuffix.Text.ToLower().Replace("c:", "");
                    GlobalFunctions.v_BrowseComputer(computer, suffix);
                }

                if (ckbOpenProgram.Checked)
                {
                    if (ckbMulti.Checked) { GlobalFunctions.Multi(computer); }
                    if (ckbDameware.Checked) { GlobalFunctions.v_ConnectWithDW(computer); }
                    if (ckbCMD.Checked) { GlobalFunctions.v_LocalCMD(computer); }
                }

                if (ckbActivate.Checked)
                {
                    GlobalFunctions.i_ExecuteCommand("WINRS", true, String.Format("-r:{0} SLMGR.VBS /IPK FJ82H-XT6CR-J8D7P-XQJJ2-GPDD4 && SLMGR /ATO", computer), false);
                }

                if (ckbInstallEndpoint.Checked)
                {
                    GlobalFunctions.b_WriteBatFile(GlobalResources.batInstallEndpoint12);
                    GlobalFunctions.b_CopyBatFile(computer);
                    GlobalFunctions.v_InstallSemantic(computer);
                }

                if (ckbDisableStartupRepair.Checked)
                {
                    int retCode = GlobalFunctions.i_ExecuteCommand("WINRS", true, String.Format("-r:{0} ", computer) + "bcdedit /set {default} recoveryenabled no && bcdedit /set {default} bootstatuspolicy ignoreallfailures", true);
                }

                if (ckbFastPrinter.Checked)
                {
                    string args = string.Format("-r:{0} TASKKILL /F /IM POSW.EXE", computer);
                    GlobalFunctions.i_ExecuteCommand("WINRS", false, args, false);
                    args = string.Format("\\\\{0} -s -d -i \"\\Program Files\\EPSON\\BA-T500II Software\\BA500IIUTL\\BA500IIUTL.EXE\"", computer);
                    GlobalFunctions.v_LocalCMD(computer);
                    GlobalFunctions.i_ExecuteCommand("PSEXEC", true, args, false);
                    args = string.Format("\\\\{0} -s -d -i \"\\Program Files\\OPOS\\Epson2\\SetupPOS.exe\"", computer);
                    GlobalFunctions.i_ExecuteCommand("PSEXEC", true, args, false);
                }

                if (reboot)
                {
                    string args = string.Format("-r:{0} SHUTDOWN /f /r /t 0", computer);
                    GlobalFunctions.i_ExecuteCommand("WINRS", true, args, false);
                }

                System.Threading.Thread.Sleep(500);
            }
            //TODO implement action log window instead of a popup message.
            //MessageBox.Show(actionList, "Completed", MessageBoxButtons.OK);
        }




        /// <summary>
        /// Removes unecessary registers from the computer list
        /// </summary>
        /// <param name="Computers"></param>
        /// <returns></returns>
		private List<string> SpecificRegister(List<string> Computers)
		{
			if (!ckb1.Checked) { Computers.RemoveAll(x => x.ToUpper().Contains("SAP" + ckb1.Text)); }
			if (!ckb2.Checked) { Computers.RemoveAll(x => x.ToUpper().Contains("SAP" + ckb2.Text)); }
			if (!ckb3.Checked) { Computers.RemoveAll(x => x.ToUpper().Contains("SAP" + ckb3.Text)); }
			if (!ckb4.Checked) { Computers.RemoveAll(x => x.ToUpper().Contains("SAP" + ckb4.Text)); }

			return Computers;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void ckbService_CheckedChanged(object sender, EventArgs e)
		{
			gbAction.Visible = ckbService.Checked;
			gbServices.Visible = ckbService.Checked;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void ckbRegister_CheckedChanged(object sender, EventArgs e)
		{
			gbRegister.Visible = ckbRegister.Checked;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void ckbBrowser_CheckedChanged(object sender, EventArgs e)
		{
			txtSuffix.Visible = ckbBrowser.Checked;
			lblSuffix.Visible = ckbBrowser.Checked;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void ckbOpenProgram_CheckedChanged(object sender, EventArgs e)
		{
			gbProgram.Visible = ckbOpenProgram.Checked;
		}

	}
}
