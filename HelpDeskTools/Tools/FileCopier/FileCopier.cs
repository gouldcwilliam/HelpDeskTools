using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Shared;

namespace FileCopier
{
    public partial class FileCopier : Form
    {
        List<string> _files = new List<string>();
        List<string> _computers = new List<string>();
        string body = Properties.Settings.Default._EmailHeader;
        public FileCopier()
        {
            InitializeComponent();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            _files.Clear();
            if (rbFiles.Checked)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = true;
                    if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }
                    ckbFileList.Items.Clear();
                    try
                    {
                        _files.AddRange(ofd.FileNames);
                    }
                    catch (Exception) { }
                }
            }
            else if (rbDirectory.Checked)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }
                    ckbFileList.Items.Clear();
                    try
                    {
                        _files.AddRange(System.IO.Directory.GetFiles(fbd.SelectedPath));
                    }
                    catch (Exception) { }
                }
            }
            foreach (string file in _files)
            {
                ckbFileList.Items.Add(file);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;

            if (checkBoxSchedule.Checked)
            {

                int d = 0; Functions.isNumeric(maskedTextBoxDays.Text, out d);
                int h = 0; Functions.isNumeric(maskedTextBoxHours.Text, out h);
                int m = 0; Functions.isNumeric(maskedTextBoxMins.Text, out m);
                startTime = startTime.AddDays(d);
                startTime = startTime.AddHours(h);
                startTime = startTime.AddMinutes(m);
            }

            if (ckbFileList.CheckedItems.Count > 0)
            {
                _files.Clear();
                foreach (string file in ckbFileList.CheckedItems)
                {
                    _files.Add(file);
                }
            }
            else
            {
                _files.Clear();
                foreach (string file in ckbFileList.Items)
                {
                    _files.Add(file);
                }
            }

            if (rbAll.Checked)
            {
                _computers = GetComputersFromAD();
            }
            else if (rbList.Checked)
            {
                _computers = GetComputersByList();
            }

            WaitingTask waitingTask = new WaitingTask(_computers,_files, startTime);
            waitingTask.ShowDialog();

        }

        List<string> GetComputersFromAD()
        {
            List<string> value = new List<string>();
            // Filter results by Object category of Computer and Name and exclude
            string ADSearchFilter =
                string.Format("(&(objectCategory={0})(&({1}=*SAP1*)(!({1}=*SAPQ*))))",
                LDAP.ObjectClasses.Computer,
                LDAP.ObjectAttribute.ComputerName);

            LDAP.OU ou = LDAP.RetailOUs.All;

            List<LDAP.Result> tempResults = AD.SearchAD(ou.ComputerOU, ADSearchFilter, LDAP.ObjectAttribute.ComputerName);

            if (tempResults != null)
            {
                if (tempResults.Count > 0)
                {
                    foreach (LDAP.Result item in tempResults)
                    {
                        value.Add(item.Value);
                    }

                }
            }
            return value;
        }



        List<string> GetComputersByList()
        {
            List<string> value = new List<string>();
            if (txtComputers.Text.Trim() == string.Empty) { MessageBox.Show("No Computers Entered", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return value; }
            foreach (string stringStore in txtComputers.Text.Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (stringStore.Length > 4) {  value.Add(stringStore); }
                else
                {
                    int store;
                    if (!int.TryParse(stringStore, out store)) { continue; }
                    foreach (DataRow dr in Shared.SQL.dt_SelectComputers(store).Rows)
                    {
                        value.Add(dr[0].ToString());
                    }
                }
            }
            return value;
        }





        private void btnSettings_Click(object sender, EventArgs e)
        {
            UserSettings userSettings = new UserSettings();
            userSettings.ShowDialog();
        }
    }
}
