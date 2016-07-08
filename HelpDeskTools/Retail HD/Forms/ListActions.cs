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

            gbOutput.Visible = false;
            btnClearOut.Visible = false;

            Size = new System.Drawing.Size(403, 604);
            btnShowOutput.Visible = true;
            
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


        private void ckbOpenProgram_CheckedChanged(object sender, EventArgs e)
        {
            gbProgram.Visible = ckbOpenProgram.Checked;
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

            if (gbOutput.Visible) { Size = new System.Drawing.Size(870, 604); }
            else { Size = new System.Drawing.Size(404, 604); }
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
                    if (gbOutput.Visible)
                    {
                        ServiceWorker serviceWorker = new ServiceWorker(computer, _service, _action);
                        serviceWorker.WorkDone += ServiceWorker_WorkDone;
                        serviceWorker.Start();
                    }
                    else
                    {
                        string args = string.Format("-r:{0} {1} {2}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, _action + " " + _service);

                        if (!Shared.Functions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices))
                        {
                            // failed to copy services.bat
                        }
                        else
                        {
                            if (_service == "verifone" && !Shared.Functions.CopyArgsXML(computer))
                            {
                                // failed to copy args.xml
                            }
                            else
                            {
                                string output = string.Format("WINRS {0}", args);
                                Console.WriteLine(output);
                                Shared.Functions.ExecuteCommand("WINRS", args, true, false);
                                Output(output);
                            }
                        }
                    }
                }


                if (ckbBrowser.Checked)
                {
                    Functions.BrowseComputer(computer, txtSuffix.Text);
                }

                if (ckbOpenProgram.Checked)
                {
                    if (ckbMulti.Checked) { Functions.Multi(computer); }
                    if (ckbDameware.Checked) { Functions.ConnectWithDW(computer); }
                    if (ckbCMD.Checked) { Functions.LocalCMD(computer); }
                }

                if (ckbActivate.Checked)
                {
                    Shared.Functions.ExecuteCommand("WINRS", String.Format("-r:{0} SLMGR.VBS /IPK FJ82H-XT6CR-J8D7P-XQJJ2-GPDD4 && SLMGR /ATO", computer), true, false);
                }

                if (ckbDisableStartupRepair.Checked)
                {
                    int retCode = Shared.Functions.ExecuteCommand("WINRS", String.Format("-r:{0} ", computer) + "bcdedit /set {default} recoveryenabled no && bcdedit /set {default} bootstatuspolicy ignoreallfailures", true, true);
                }

                if (ckbFastPrinter.Checked)
                {
                    string args = string.Format("-r:{0} TASKKILL /F /IM POSW.EXE", computer);
                    Shared.Functions.ExecuteCommand("WINRS", args, false, false);
                    args = string.Format("\\\\{0} -s -d -i \"\\Program Files\\EPSON\\BA-T500II Software\\BA500IIUTL\\BA500IIUTL.EXE\"", computer);
                    Functions.LocalCMD(computer);
                    Shared.Functions.ExecuteCommand(Shared.Settings.Default._TempPath + "PSEXEC", args, true, false);
                    args = string.Format("\\\\{0} -s -d -i \"\\Program Files\\OPOS\\Epson2\\SetupPOS.exe\"", computer);
                    Shared.Functions.ExecuteCommand(Shared.Settings.Default._TempPath + "PSEXEC", args, true, false);
                }

                // TODO - make each multi/ri check run async
                if (ckbRIMulti.Checked)
                {
                    LogCheck logCheck = new LogCheck(computer);

                    logCheck.WorkDone += LogCheck_WorkDone;
                    logCheck.Start();
                }

                if (ckbTrickle.Checked)
                {
                    if (computer.ToUpper().Contains("SAP1"))
                    {
                        if (Functions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices))
                        {
                            string args = string.Format("-r:{0} {1} {2}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, "restart transnet");
                            Console.WriteLine("WINRS {0}", args);
                            Functions.ExecuteCommand("WINRS", args, true, false);
                            args = string.Format("-r:{0} {1} {2}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, "restart sql");
                            Console.WriteLine("WINRS {0}", args);
                            Shared.Functions.ExecuteCommand("WINRS", args, true, false);
                            Functions.BrowseComputer(computer, "trickle");
                        }
                    }
                }

                if (ckbZip.Checked)
                {
                    if (Shared.Functions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatZip) && (Shared.Functions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._PSZip)))
                    {
                        Shared.Functions.ExecuteCommand("WINRS", string.Format("-r:{0} {1}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatZip), true, false);
                        Functions.BrowseComputer(computer, @"\temp");
                    }
                }

                if (ckbWSAdmin.Checked)
                {
                    if (Shared.Functions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._WSAdmin))
                    {
                        Shared.Functions.ExecuteCommand("WINRS", string.Format("-r:{0} {1}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._WSAdmin), true, false);
                    }
                }

                if (reboot)
                {
                    string args = string.Format("-r:{0} SHUTDOWN /f /r /t 0", computer);
                    Shared.Functions.ExecuteCommand("WINRS", args, true, false);

                }

                System.Threading.Thread.Sleep(250);
            }
            ClearChecks();

        }

        private void ServiceWorker_WorkDone(object sender, EventArgs e)
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
            foreach (CheckBox cb in gbRegister.Controls.OfType<CheckBox>()) { cb.Checked = false; }
            foreach (RadioButton rb in gbServices.Controls.OfType<RadioButton>()) { rb.Checked = false; }
            foreach (RadioButton rb in gbAction.Controls.OfType<RadioButton>()) { rb.Checked = false; }
            foreach (CheckBox cb in gbProgram.Controls.OfType<CheckBox>()) { cb.Checked = false; }
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
            if(txtOutput.Text=="")
            {
                if (txtOutput.InvokeRequired) { txtOutput.Invoke(new MethodInvoker(delegate { txtOutput.Text += output; })); }
                else { txtOutput.Text += output; }
            }
            else
            {
                if (txtOutput.InvokeRequired) { txtOutput.Invoke(new MethodInvoker(delegate { txtOutput.Text += Environment.NewLine + output; })); }
                else { txtOutput.Text += Environment.NewLine + output; }
            }
        }





        //if (ss_Bottom_.InvokeRequired) ss_Bottom_.Invoke(new MethodInvoker(delegate { ss_Bottom_ssl_Time.Text = _timeSinceStateChange.ToString(@"hh\:mm\:ss"); }));
        //else ss_Bottom_ssl_Time.Text = _timeSinceStateChange.ToString(@"hh\:mm\:ss");
        #endregion

    }
}
