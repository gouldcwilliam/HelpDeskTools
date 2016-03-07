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


		private string dateString
		{
			get
			{
				string year = DateTime.Today.Year.ToString();
				string month = DateTime.Today.Month.ToString();
				if (month.Length < 2) { month = 0 + month; }
				string day = DateTime.Today.Day.ToString();
				if (day.Length < 2) { day = 0 + day; }

				return year + month + day;
			}
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
					string args = string.Format("-r:{0} {1} {2}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, _action + " " + _service);
					if (!GlobalFunctions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices))
					{
						// failed to copy services.bat
					}
					else
					{
						if (_service == "verifone" && !GlobalFunctions.CopyArgsXML(computer))
						{
							// failed to copy args.xml
						}
						else
						{
							Console.WriteLine("WINRS {0}", args);
							GlobalFunctions.ExecuteCommand("WINRS", args, true, false);
						}
					}
				}


                if (ckbBrowser.Checked)
                {
                    GlobalFunctions.BrowseComputer(computer, txtSuffix.Text);
                }

                if (ckbOpenProgram.Checked)
                {
                    if (ckbMulti.Checked) { GlobalFunctions.Multi(computer); }
                    if (ckbDameware.Checked) { GlobalFunctions.ConnectWithDW(computer); }
                    if (ckbCMD.Checked) { GlobalFunctions.v_LocalCMD(computer); }
                }

                if (ckbActivate.Checked)
                {
                    GlobalFunctions.ExecuteCommand("WINRS", String.Format("-r:{0} SLMGR.VBS /IPK FJ82H-XT6CR-J8D7P-XQJJ2-GPDD4 && SLMGR /ATO", computer), true, false);
                }

                if (ckbInstallEndpoint.Checked)
                {
                    
					GlobalFunctions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatEndpoint);
                    GlobalFunctions.v_InstallSemantic(computer);
                }

                if (ckbDisableStartupRepair.Checked)
                {
                    int retCode = GlobalFunctions.ExecuteCommand("WINRS", String.Format("-r:{0} ", computer) + "bcdedit /set {default} recoveryenabled no && bcdedit /set {default} bootstatuspolicy ignoreallfailures", true, true);
                }

                if (ckbFastPrinter.Checked)
                {
                    string args = string.Format("-r:{0} TASKKILL /F /IM POSW.EXE", computer);
                    GlobalFunctions.ExecuteCommand("WINRS", args, false, false);
                    args = string.Format("\\\\{0} -s -d -i \"\\Program Files\\EPSON\\BA-T500II Software\\BA500IIUTL\\BA500IIUTL.EXE\"", computer);
                    GlobalFunctions.v_LocalCMD(computer);
                    GlobalFunctions.ExecuteCommand(Shared.Settings.Default._TempPath + "PSEXEC", args, true, false);
                    args = string.Format("\\\\{0} -s -d -i \"\\Program Files\\OPOS\\Epson2\\SetupPOS.exe\"", computer);
                    GlobalFunctions.ExecuteCommand(Shared.Settings.Default._TempPath + "PSEXEC", args, true, false);
                }

				if (ckbRIMulti.Checked)
				{
					string multi;
					if (!GlobalFunctions.CopyTempLog(getLatestMulti(string.Format(@"\\{0}\c$\MerchantConnectMulti\log\", computer), "multi_*.log"))) { multi = "Unable to read multi log"; }
					else { multi = GlobalFunctions.FindInLog(Properties.Settings.Default.multiVersion).ToString(); }

					string ri;
					if (!GlobalFunctions.CopyTempLog(string.Format(@"\\{0}\c$\Program Files\RedIron Technologies\RedIron Broker\2Authorize.log", computer))) { ri = "Unable to read ri log"; }
					else { ri = GlobalFunctions.FindInLog(Properties.Settings.Default.redIronVersion).ToString(); }

					string vf;
					//if (GlobalFunctions.CopyTempLog(string.Format(@"\\{0}\c$\Program Files\VeriFone\MX915\UpdateFiles\logfiles\vfquerylog.xml", computer))) { vf = "Unable to read vf log"; }
					//else { vf = GlobalFunctions.FindInLog(Properties.Settings.Default.vfVersion).ToString(); }
					vf = vfLog(computer);

					MessageBox.Show(string.Format(computer + "\nMulti up to date: {0} \nRedIron up to date: {1} \nVerifone up to date: {2}", multi, ri, vf),
						"RedIron/Multi Version Check: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				if(ckbTrickle.Checked)
				{
					if (computer.ToUpper().Contains("SAP1"))
					{
						if (GlobalFunctions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices))
						{
							string args = string.Format("-r:{0} {1} {2}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, "restart transnet");
							Console.WriteLine("WINRS {0}", args);
							GlobalFunctions.ExecuteCommand("WINRS", args, true, false);
							args = string.Format("-r:{0} {1} {2}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatServices, "restart sql");
							Console.WriteLine("WINRS {0}", args);
							GlobalFunctions.ExecuteCommand("WINRS", args, true, false);
							GlobalFunctions.BrowseComputer(computer, "trickle");
						}
					}
				}

				if(ckbZip.Checked)
				{
					//string dest = string.Format(@"C:\temp\{0}\", computer);
					//if (!System.IO.Directory.Exists(dest)) { System.IO.Directory.CreateDirectory(dest); }
					//string multiPath = string.Format(@"\\{0}\c$\MerchantConnectMulti\",computer);
					//foreach(string find in new string[] { "multi_*.log","*_.dg"})
					//{
					//	System.IO.FileInfo file = getLatestFile(multiPath + @"log\", find);
					//	GlobalFunctions.CopyTempLog(file.FullName, dest + file.Name);
					//}

					if (GlobalFunctions.CopyFileRemote(computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatZip)&&(GlobalFunctions.CopyFileRemote(computer,Shared.Settings.Default._TempPath+Shared.Settings.Default._PSZip)))
					{
						GlobalFunctions.ExecuteCommand("WINRS", string.Format("-r:{0} {1}", computer, Shared.Settings.Default._TempPath + Shared.Settings.Default._BatZip), true, false);
						GlobalFunctions.BrowseComputer(computer, @"\temp");
					}
				}

                if (reboot)
                {
                    string args = string.Format("-r:{0} SHUTDOWN /f /r /t 0", computer);
                    GlobalFunctions.ExecuteCommand("WINRS", args, true, false);

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

		public static string vfLog(string computer)
		{
			try
			{
				if (!System.IO.File.ReadAllText(string.Format(@"\\{0}\c$\Program Files\VeriFone\MX915\UpdateFiles\logfiles\vfquerylog.xml", computer)).Contains(Properties.Settings.Default.vfVersion))
				{
					if (System.IO.File.ReadAllText(string.Format(@"\\{0}\c$\Program Files\VeriFone\MX915\UpdateFiles\logfiles\vfquerylog.xml", computer)).Contains("Error Opening Comm Port") ||
						System.IO.File.ReadAllText(string.Format(@"\\{0}\c$\Program Files\VeriFone\MX915\UpdateFiles\logfiles\vfquerylog.xml", computer)).Contains("Error Getting Version"))
					{
						return "True";
					}
					else { return "False"; }
				}
				else return "True";
			}
			catch (Exception ex) { return "False"; }
		}
		public static System.IO.FileInfo getLatestFile(string path, string find)
		{
			try
			{
				System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
				System.IO.FileInfo[] files = dir.GetFiles(find).OrderByDescending(p => p.CreationTime).ToArray();
				Console.WriteLine(files[0].FullName);
				return files[0];
			}
			catch (Exception ex) { return null; }
		}
		public static string getLatestMulti(string path, string find)
		{
			try
			{
				System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
				System.IO.FileInfo[] files = dir.GetFiles(find).OrderByDescending(p => p.CreationTime).ToArray();
				Console.WriteLine(files[0].FullName);
				return files[0].FullName;
            }
			catch(Exception ex) { return ""; }
        }

	}
}
