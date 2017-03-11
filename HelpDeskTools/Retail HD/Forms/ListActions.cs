using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


using Shared;

namespace Retail_HD.Forms
{
    // TODO - implement action log window instead of a popup message.
    /// <summary>
    /// form for performing random/multi step fixes to many registers
    /// </summary>
    public partial class ListActions : Form
	{
        
        /// <summary>
        /// <see cref="ListActions"/>
        /// </summary>
		public ListActions()
		{
			InitializeComponent();
		}

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




        //
        #region Form Handlers



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



        #endregion




        //
        #region Button Handlers


        // TODO - remove steps for copying bat file



        private void btnClearOut_Click(object sender, EventArgs e)
        {
            if (txtOutput.InvokeRequired) { txtOutput.Invoke(new MethodInvoker(delegate { txtOutput.Text = ""; })); }
            else { txtOutput.Text = ""; }
        }


        private void btnShowOutput_Click(object sender, EventArgs e)
        {
            gbOutput.Visible = (!gbOutput.Visible);
            btnClearOut.Visible = (!btnClearOut.Visible);

            if (gbOutput.Visible) { Size = MaximumSize; }
            else { Size = MinimumSize; }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>()) { tb.Text = string.Empty; }
            ClearChecks();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            // exit if no store entered
            if (txtList.Text.Trim() == string.Empty) { return; }

            // load computers per store number entered
            List<string> computers = new List<string>();
            foreach (string stringStore in txtList.Text.Split(new string[] { " ","\n","\r" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (stringStore.Length > 4)
                {
                    computers.Add(stringStore);
                }
                else
                {
                    int store;
                    if (!int.TryParse(stringStore, out store)) { continue; }
                    // add each computer to list
                    foreach (DataRow dr in Shared.SQL.dt_SelectComputers(store).Rows) { computers.Add(dr[0].ToString()); }
                }
            }
            

            // only include specific computers list
            if (ckbRegister.Checked) { computers = SpecificRegister(computers); }


            // double check that a reboot is wanted
            bool reboot = false;
            if (ckbRestart.Checked) { reboot = (MessageBox.Show("Are you sure you want to reboot?\nOther actions will not run", "System Reboot", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK); }

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

                if (reboot) { Functions.RestartComputer(computer); continue; }

                if (bservices)
                {
                    if (gbOutput.Visible)
                    {
                        ServiceWorker serviceWorker = new ServiceWorker(computer, _service, _action);
                        serviceWorker.OutputUpdate += ServiceWorker_OutputUpdate;
                        serviceWorker.Start();
                    }
                    else
                    {
                        string args = string.Format("-r:{0} {1} {2}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, _action + " " + _service);

                        if (!Functions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices))
                        {
                            // failed to copy services.bat
                        }
                        else
                        {
                            if (_service == "verifone" && !Functions.CopyArgsXML(computer))
                            {
                                // failed to copy args.xml
                            }
                            if(_service=="verifone")
                            {
                                Forms.VerifoneConfirm sfv = new Forms.VerifoneConfirm(computer);
                                string output = string.Format("WINRS {0}", args);
                                Console.WriteLine(output);
                                Functions.ExecuteCommand("WINRS", args, true, false);
                                Output(output);
                                sfv.Show();
                            }
                            else
                            {
                                string output = string.Format("WINRS {0}", args);
                                Console.WriteLine(output);
                                Functions.ExecuteCommand("WINRS", args, true, false);
                                Output(output);
                            }
                        }
                    }
                }

                if (ckbBrowser.Checked)
                {
                    Functions.BrowseComputer(computer, txtSuffix.Text);
                }

                
                if (ckbMulti.Checked) { Functions.Multi(computer); }
                if (ckbDameware.Checked) { Functions.ConnectWithDW(computer); }
                if (ckbCMD.Checked) { Functions.LocalCMD(computer); }
                if (ckbPing.Checked) { Functions.Pinger(computer); }

                if (ckbSEPUpdateComms.Checked) { Functions.SEPUpdateComms(computer); }
                if (ckbSEPUpdateConfig.Checked) { Functions.SEPUpdateConfig(computer); }
                if (ckbSEPOpenGUI.Checked) { Functions.SEPOpenGUI(computer); }
                if (ckbSEPRunInstall.Checked)
                {
                    ServiceWorker serviceWorker = new ServiceWorker(computer, "sep", "stop");
                    serviceWorker.OutputUpdate += ServiceWorker_OutputUpdate;
                    serviceWorker.Start();
                    Functions.SEPRunInstall(computer);
                }

                if (ckbTrickle.Checked)
                {
                    if (computer.ToUpper().Contains("SAP1"))
                    {
                        if (Functions.CopyServicesBatFile(computer))
                        {
                            ServiceWorker swTransnetRestart = new ServiceWorker(computer, "transnet", "restart", false);
                            swTransnetRestart.OutputUpdate += ServiceWorker_OutputUpdate;
                            swTransnetRestart.Start();

                            ServiceWorker swSQLRestart = new ServiceWorker(computer, "sql", "restart", false);
                            swSQLRestart.OutputUpdate += ServiceWorker_OutputUpdate;
                            swSQLRestart.Start();

                            Functions.BrowseComputer(computer, "trickle");
                        }
                        else { Output("Failed to copy services.bat to " + computer); }
                        
                    }
                }

                if (ckbActivate.Checked) { Functions.ActivateWindows(computer); }

                if (ckbRIMulti.Checked)
                {
                    LogCheck logCheck = new LogCheck(computer);
                    logCheck.WorkDone += LogCheck_WorkDone;
                    logCheck.Start();
                }

                if (ckbZip.Checked)
                {
                    if (Functions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatZip) && (Functions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._PSZip)))
                    {
                        Functions.ExecuteCommand("WINRS", string.Format("-r:{0} {1}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatZip), true, false);
                        Functions.BrowseComputer(computer, @"\temp");
                    }
                }

                if (ckbDisableStartupRepair.Checked) { int retCode = Functions.DisableStartupRepair(computer); }

                if (ckbFastPrinter.Checked)
                {
                    Functions.KillPOS(computer);
                    Functions.LocalCMD(computer);
                    Functions.OpenBA500IIUTL(computer);
                    Functions.OpenOPOS(computer);
                }

                if (ckbWSAdmin.Checked)
                {
                    if (Functions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._WSAdmin))
                    {
                        Functions.ExecuteCommand("WINRS", string.Format("-r:{0} {1}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._WSAdmin), true, false);
                    }
                }

                

                System.Threading.Thread.Sleep(250);
            }

            ClearChecks();

        }

        private void ServiceWorker_OutputUpdate(object sender, EventArgs e)
        {
            Output(((ServiceWorker)sender).Output);
        }


        private void LogCheck_WorkDone(object sender, EventArgs e)
        {
            Output(((LogCheck)sender).Output);
        }


        #endregion



        //
        #region Methods/Functions


        private void ClearChecks()
        {
            foreach (CheckBox cb in this.Controls.OfType<CheckBox>()) { cb.Checked = false; }
            foreach (RadioButton rb in this.Controls.OfType<RadioButton>()) { rb.Checked = false; }
            foreach (GroupBox gb in this.Controls.OfType<GroupBox>())
            {
                foreach (CheckBox cb in gb.Controls.OfType<CheckBox>()) { cb.Checked = false; }
                foreach (RadioButton rb in gb.Controls.OfType<RadioButton>()) { rb.Checked = false; }
            }
        }


        private List<string> SpecificRegister(List<string> Computers)
		{
			if (!ckb1.Checked) { Computers.RemoveAll(x => x.ToUpper().Contains("SAP1")); }
			if (!ckb2.Checked) { Computers.RemoveAll(x => x.ToUpper().Contains("SAP2")); }
			if (!ckb3.Checked) { Computers.RemoveAll(x => x.ToUpper().Contains("SAP3")); }
			if (!ckb4.Checked) { Computers.RemoveAll(x => x.ToUpper().Contains("SAP4")); }
			if (!ckb5.Checked) { Computers.RemoveAll(x => x.ToUpper().Contains("SAP5")); }
			if (!ckb6.Checked) { Computers.RemoveAll(x => x.ToUpper().Contains("SAP6")); }
            return Computers;
		}


        private string getLatestMulti(string path, string find)
        {
            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
                System.IO.FileInfo[] files = dir.GetFiles(find).OrderByDescending(p => p.CreationTime).ToArray();
                Console.WriteLine(files[0].FullName);
                return files[0].FullName;
            }
            catch (Exception) { return ""; }
        }


        private void Output(string output)
        {
            if (txtOutput.InvokeRequired) { txtOutput.Invoke(new MethodInvoker(delegate { txtOutput.Text += output + Environment.NewLine; })); }
            else { txtOutput.Text += output + Environment.NewLine; }
        }


        #endregion

    }
}
