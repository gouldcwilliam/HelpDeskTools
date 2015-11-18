using System;
using System.Windows.Forms;

namespace Retail_HD.Forms
{
    public partial class Confirm : Form
    {
		/*	INSTANTIATE	*/
		/// <summary>
		/// form for displaying messages and obtaining DialogResults
		/// </summary>
		/// <param name="Message">Text displayed in body</param>
        public Confirm(string Message)
        {
            InitializeComponent();
			this.txtMessage.Text = Message;
        }
		/// <summary>
		/// form for displaying messages and obtaining DialogResults
		/// </summary>
		/// <param name="ShowCancel">visibility of cancel button</param>
		public Confirm(string Message, bool ShowCancel)
		{
			InitializeComponent();
			this.txtMessage.Text = Message;
			this.btnCancel.Visible = ShowCancel;
		}
		/// <summary>
		/// form for displaying messages and obtaining DialogResults
		/// </summary>
		/// <param name="Title">window's title</param>
		public Confirm(string Message, string Title)
		{
			InitializeComponent();
			this.txtMessage.Text = Message;
			this.Text = Title;
		}
		/// <summary>
		/// form for displaying messages and obtaining DialogResults
		/// </summary>
		/// <param name="Message">Text displayed in body</param>
		/// <param name="Title">window's title</param>
		/// <param name="ShowCancel">visibility of cancel button</param>
		public Confirm(string Message, string Title, bool ShowCancel)
		{
			InitializeComponent();
			this.txtMessage.Text = Message;
			this.Text = Title;
			this.btnCancel.Visible = ShowCancel;
		}

		/*  BUTTONS	*/
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
