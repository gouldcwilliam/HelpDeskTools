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
	public partial class ReportIssue : Form
	{
		public ReportIssue()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
            //string from = Environment.UserName.ToString()+"@wwwinc.com";
            string to = "chad.gould@wwwinc.com";
            //System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(from, to, "What the Junk", this.txtIssueSuggestion.sText);
            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("wwwsmtp.wwwint.corp", 25);
            //client.UseDefaultCredentials = true;
            //client.Send(message);
            if (Shared.Functions.b_SendEmail(to, "<pre>" + txtIssueSuggestion.Text + "</pre>", "What the Junk"))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("An error occurred while attempting to report your issue. Please contact Chad directly.", "Error Sending Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
