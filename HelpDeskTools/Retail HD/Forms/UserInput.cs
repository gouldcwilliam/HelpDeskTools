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
    /// <summary>
    /// Generic user input form
    /// </summary>
	public partial class UserInput : Form
	{
		/// <summary> Gather user input
		/// </summary>
		/// <param name="Message">Message to display the user</param>
		public UserInput(string Message)
		{
			InitializeComponent();
			_Message = Message;
			_Title = "New Input";
		}
		/// <summary> Gather user input
		/// </summary>
		/// <param name="Message">Message to display the user</param>
		/// <param name="Input">Default text to show in the text box</param>
		public UserInput(string Message, string Input)
		{
			InitializeComponent();
			_Message = Message;
			_Title = "New Input";
			txtEntry.Text = Input;
			txtEntry.SelectAll();
		}

		private string _Message
		{
			get
			{
				return lblMessage.Text;
			}
			set
			{
				lblMessage.Text = value;
			}
		}
		private string _Title
		{
			get
			{
				return this.Text;
			}
			set
			{
				this.Text = value;
			}
		}
        /// <summary>
        /// input from user
        /// </summary>
		public string _UserInput
		{
			get
			{
				return txtEntry.Text;
			}
			set { txtEntry.Text = value; }
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();
		}


	}
}
