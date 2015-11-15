using System;
using System.Windows.Forms;

namespace Retail_HD.Forms
{
	public partial class AddQuickWrap : Form
    {
        public AddQuickWrap(ComboBox.ObjectCollection items)
        {
            InitializeComponent();
            foreach (string item in items)
            {
                cmbCategories.Items.Add(item);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Shared.SQL.AddQuickWrap_Insert(cmbCategories.Text, txtWrapUp.Text, ckbMandatory.Checked))
			{
                MessageBox.Show("Something happened to the insert");
				return;
            }
            try
            {
                string from = Environment.UserName.ToString() + "@wwwinc.com";
                string to1 = "chad.gould@wwwinc.com";
                string to2 = "jason.bergman@wwwinc.com";
                string body = string.Format("Category: {0}       WrapUp: {1}", cmbCategories.Text, txtWrapUp.Text);
                System.Net.Mail.MailMessage message1 = new System.Net.Mail.MailMessage(from, to1, "New Wrap Up Added", body);
                System.Net.Mail.MailMessage message2 = new System.Net.Mail.MailMessage(from, to2, "New Wrap Up Added", body);
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("wwwsmtp.wwwint.corp", 25);
                client.UseDefaultCredentials = true;
                client.Send(message1);
                client.Send(message2);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
		}
    }
}
