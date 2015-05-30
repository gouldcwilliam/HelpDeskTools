using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retail_HD.Forms
{
    public partial class frmSendEmail : Form
    {
        List<Attachment> attachments = new List<Attachment>();
        List<string> to = new List<string>();
        //public frmSendEmail()
        //{
        //    InitializeComponent();
        //}

        public frmSendEmail(string[] toList, string teamname)
        {
            InitializeComponent();
            to.AddRange(toList);
            to.Add("ITRetailHelpdeskDL@wwwinc.com");
            lblTeam.Text = string.Format("Send to: {0}", teamname);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            List<System.IO.FileInfo> files = new List<System.IO.FileInfo>();
            foreach (Attachment _item in attachments)
            {
                files.Add(new System.IO.FileInfo(_item.fullpath));
            }

            GlobalFunctions.b_SendEmail(to, rtbBody.Text, txtSubject.Text, files);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in ofdMain.FileNames)
                {
                    attachments.Add(new Attachment(file));
                }

                //update the listbox
                UpdateListBox();
            }
        }

        private void UpdateListBox()
        {
            lbAttachedFiles.DataSource = null;

            for (int i = 0; i < lbAttachedFiles.Items.Count; i++)
            {
                lbAttachedFiles.Items.RemoveAt(i);
            }

            lbAttachedFiles.DataSource = attachments;
            lbAttachedFiles.DisplayMember = "filename";
            lbAttachedFiles.ValueMember = "fullpath";
        }

        private void txtSubject_Enter(object sender, EventArgs e)
        {
            if (txtSubject.Font.Italic && txtSubject.Text == "Subject")
            {
                txtSubject.Font = new Font(txtSubject.Font, FontStyle.Regular);
                txtSubject.ForeColor = Color.Black;
                txtSubject.Text = string.Empty;
            }
        }

        private void txtSubject_Leave(object sender, EventArgs e)
        {
            if (txtSubject.Text == string.Empty)
            {
                txtSubject.Font = new Font(txtSubject.Font, FontStyle.Italic);
                txtSubject.ForeColor = Color.Gray;
                txtSubject.Text = "Subject";
            }
        }

        private void rtbBody_Leave(object sender, EventArgs e)
        {
            if (rtbBody.Text == string.Empty)
            {
                rtbBody.Font = new Font(rtbBody.Font, FontStyle.Italic);
                rtbBody.ForeColor = Color.Gray;
                rtbBody.Text = "Body";
            }
        }

        private void rtbBody_Enter(object sender, EventArgs e)
        {
            if (rtbBody.Font.Italic && rtbBody.Text == "Body")
            {
                rtbBody.Font = new Font(rtbBody.Font, FontStyle.Regular);
                rtbBody.ForeColor = Color.Black;
                rtbBody.Text = string.Empty;
            }
        }

        private void removeItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection selection = lbAttachedFiles.SelectedIndices;

            foreach (int _index in selection)
            {
                attachments.Remove((Attachment)lbAttachedFiles.Items[_index]);
                UpdateListBox();
            }
        }

        private void frmSendEmail_Load(object sender, EventArgs e)
        {
            btnAttach.Focus();
        }
    }

    public class Attachment
    {
        public string filename 
        {
            get
            {
                return fullpath.Split('\\')[fullpath.Split('\\').Length - 1]; //should give us just the filename
            }
        }
        public string fullpath { get; set; }

        public Attachment(string path)
        {
            fullpath = path;
        }
    }
}
