using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Retail_HD.Forms
{
	
	public partial class UsefulInfo : Form
	{
		public UsefulInfo()
		{
			InitializeComponent();
		}


		private void frmInfo_Load(object sender, EventArgs e)
		{
			foreach (DataRow row in SQL.dt_UsefulInfo().Rows)
			{
				TabPage tabPage = new TabPage();

				tabPage.Text = row["tab"].ToString();

				RichTextBox richtxt = new RichTextBox();

				richtxt.Dock = DockStyle.Fill;
				richtxt.AcceptsTab = true;

				richtxt.Text = row["Text"].ToString();
				richtxt.ScrollBars = RichTextBoxScrollBars.Vertical;
				richtxt.TextChanged += btnSave_Enable;

				tabPage.Controls.Add(richtxt);
				tabControl.Controls.Add(tabPage);
			}

			
		}

		private void btnSave_Enable(object sender, EventArgs e)
		{
			btnSave.Enabled = true;
		}

		private void frmInfo_Save(object sender, EventArgs e)
		{
			foreach (TabControl tabControl in panel1.Controls)
			{
				foreach (TabPage tabPage in tabControl.Controls)
				{
					if (SQL.dt_UsefulInfo_Text(tabPage.Text).Rows[0]["Text"].ToString() != tabPage.Controls[0].Text)
					{
						SQL.b_UsefulInfo_Update(tabPage.Text, tabPage.Controls[0].Text);
					}
				}
			}
			btnSave.Enabled = false;
		}

		private void tab_DoubleClick(object sender, EventArgs e)
		{
			Forms.UserInput titleInput = new Forms.UserInput("Enter Tab Title", "New Tab");

			TabControl tab = (TabControl)sender;

			TabPage page = tab.SelectedTab;

			string oldName = page.Text;

			titleInput._UserInput = oldName;

			if (titleInput.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }

			string newName = titleInput._UserInput.Trim();

			if (newName == string.Empty) { return; }

			page.Text = newName;

			SQL.b_EditInfoTabTitle(oldName, newName);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (btnSave.Enabled)
			{
				DialogResult result = MessageBox.Show(
					"Would you like to save changes before exiting?", 
					"Unsaved Changes", 
					MessageBoxButtons.YesNoCancel, 
					MessageBoxIcon.Question, 
					MessageBoxDefaultButton.Button1);
				if (result == System.Windows.Forms.DialogResult.Cancel) { return; }
				if (result == System.Windows.Forms.DialogResult.Yes) { frmInfo_Save(sender, e); }
			}

			Close();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			TabPage tabPage = new TabPage();

			Forms.UserInput titleInput = new Forms.UserInput("Enter Tab Title", "New Tab");

			if (titleInput.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }

			if (titleInput._UserInput.Trim() == string.Empty) { return; }

			SQL.b_InsertInfoTab(titleInput._UserInput, tabControl.Controls.Count);

			tabPage.Text = titleInput._UserInput;

			RichTextBox richtxt = new RichTextBox();
			
			richtxt.Dock = DockStyle.Fill;
			richtxt.AcceptsTab = true;

			richtxt.TextChanged += btnSave_Enable;

			richtxt.Text = string.Empty;

			tabPage.Controls.Add(richtxt);
			tabControl.Controls.Add(tabPage);
			
			this.panel1.Controls.Add(tabControl);
		}

		
	}
}
