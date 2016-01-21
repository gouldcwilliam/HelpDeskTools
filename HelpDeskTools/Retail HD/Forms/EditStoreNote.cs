using System.Windows.Forms;
using System.Collections.Generic;

namespace Retail_HD.Forms
{
	public partial class EditStoreNote : Form
	{
		public EditStoreNote()
		{
			InitializeComponent();
		}
		public EditStoreNote(bool Edit, int ID, int Store, string note, bool resolved)
		{
			InitializeComponent();
			edit = Edit;
			id = ID;
			store = Store;
			Text = Text + store.ToString();
			txtNote.Text = note;
			ckbResolved.Checked = resolved;
		}
		private int id;
		private bool edit;
		private int store;

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(txtNote.Text.Trim() == "")
			{
				Forms.Confirm confirm = new Confirm("Continue with empty note?");
				if(confirm.ShowDialog() != DialogResult.OK) { return; }
			}
			if(edit)
			{
				List<System.Data.SqlClient.SqlParameter> parameters = new List<System.Data.SqlClient.SqlParameter>();
				parameters.Add(new System.Data.SqlClient.SqlParameter("@id", id));
				parameters.Add(new System.Data.SqlClient.SqlParameter("@note", txtNote.Text));
				parameters.Add(new System.Data.SqlClient.SqlParameter("@resolved", ckbResolved.Checked));
				Shared.SQL.Update("update [Notes] set [note]=@note, [resolved]=@resolved where [id]=@id", parameters);
			}
			else
			{
				List<System.Data.SqlClient.SqlParameter> parameters = new List<System.Data.SqlClient.SqlParameter>();
				parameters.Add(new System.Data.SqlClient.SqlParameter("@store", store));
				parameters.Add(new System.Data.SqlClient.SqlParameter("@note", txtNote.Text));
				parameters.Add(new System.Data.SqlClient.SqlParameter("@resolved", ckbResolved.Checked));
				Shared.SQL.Insert("Insert into [Notes] ([store],[note],[resolved]) values (@store, @note, @resolved)", parameters);
			}
			DialogResult = DialogResult.OK;
		}
	}
}
