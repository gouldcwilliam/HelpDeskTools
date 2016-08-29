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
            if (ckbFileList.CheckedItems.Count>0)
            {
                _files.Clear();
                foreach(string file in ckbFileList.CheckedItems)
                {
                    _files.Add(file);
                }
            }
            else
            {
                _files.Clear();
                foreach(string file in ckbFileList.Items)
                {
                    _files.Add(file);
                }
            }

            if (rbAll.Checked)
            {
                GetComputersFromAD();
            }
            else if (rbList.Checked)
            {
                GetComputersByList();
            }

            string start = DateTime.Now.ToString();
            body += start + "<br>";

            body += Properties.Settings.Default._EmailTableHead;

            if (_computers.Count() > 0)
            {
                FileCopyStatus fileCopyStatus = new FileCopyStatus();
                fileCopyStatus.progressBarComputer.Maximum = _computers.Count;
                fileCopyStatus.Show();
                fileCopyStatus.TopMost = true;
                for (int i = 0; i < _computers.Count(); i++)
                {
                    fileCopyStatus.progressBarComputer.Value = i+1;
                    if (Shared.Functions.CheckNetwork(_computers[i]))
                    {
                        if (_files.Count > 0)
                        {
                            fileCopyStatus.progressBarFile.Maximum = _files.Count;
                            for (int j = 0; j < _files.Count; j++)
                            {
                                string file = System.IO.Path.GetFileName(_files[j]);
                                fileCopyStatus.progressBarFile.Value = j;
                                try
                                {
                                    string dest = string.Format(@"\\{0}\c$\temp\{1}", _computers[i], file);
                                    System.IO.File.Copy(_files[j], dest, true);
                                    body += string.Format(Properties.Settings.Default._EmailTableRow, _computers[i], "Files Transfered", file);
                                }
                                catch (Exception)
                                {
                                    body += string.Format(Properties.Settings.Default._EmailTableRow, _computers[i], "Failed to transfer file", file);
                                }
                            }
                            fileCopyStatus.progressBarFile.Value = _files.Count;
                        }
                    }
                    else { body += string.Format(Properties.Settings.Default._EmailTableRow, _computers[i], "Unable to ping", ""); }
                }
                fileCopyStatus.progressBarComputer.Value = _computers.Count;
                fileCopyStatus.Close();
            }

            body += Properties.Settings.Default._EmailFooter;
            body += DateTime.Now.ToString();

            Shared.Functions.SendEmail(Properties.Settings.Default._To, body, Properties.Settings.Default._Subject);
        }

        void GetComputersFromAD()
        {
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
                        _computers.Add(item.Value);
                    }

                }
            }
        }
        void GetComputersByList()
        {
            if (txtComputers.Text.Trim() == string.Empty) { MessageBox.Show("No Computers Entered", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            foreach (string stringStore in txtComputers.Text.Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (stringStore.Length > 4)
                {
                    _computers.Add(stringStore);
                }
                else
                {
                    int store;
                    if (!int.TryParse(stringStore, out store)) { continue; }
                    // add each computer to list
                    foreach (DataRow dr in Shared.SQL.dt_SelectComputers(store).Rows) { _computers.Add(dr[0].ToString()); }
                }
            }
        }

        bool CopyFiles(string computer)
        {
            if (_files.Count > 0)
            {
                foreach (string file in _files)
                {
                    try
                    {
                        string dest = string.Format(@"\\{0}\c$\temp\{1}", computer, System.IO.Path.GetFileName(file));
                        System.IO.File.Copy(file, dest, true);
                        body += string.Format(Properties.Settings.Default._EmailTableRow, computer, "Files Transfered", file);
                    }
                    catch (Exception)
                    {
                        body += string.Format(Properties.Settings.Default._EmailTableRow, computer, "Failed to transfer files", file);
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
