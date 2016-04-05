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
	public partial class StoreNotes : Form
	{
		public StoreNotes()
		{
			InitializeComponent();
			Text = Text + ": " + Info.store;
		}

		private EditStoreNote editStoreNote;

		private void StoreNotes_Load(object sender, EventArgs e)
		{
			dgvNotes.DataSource = Info.notes;
			if (dgvNotes.Rows.Count > 0)
			{
				dgvNotes.Columns["store"].Visible = false;
				dgvNotes.Columns["note"].FillWeight = 6;
				dgvNotes.Columns["resolved"].FillWeight = 1;
				dgvNotes.Columns["id"].Visible = false;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if(dgvNotes.SelectedRows.Count == 1)
			{
				editStoreNote = new EditStoreNote(
					true,
					(int)dgvNotes.SelectedRows[0].Cells["id"].Value,
					(int)dgvNotes.SelectedRows[0].Cells["store"].Value,
					dgvNotes.SelectedRows[0].Cells["note"].Value.ToString(),
					(bool)dgvNotes.SelectedRows[0].Cells["resolved"].Value);
				editStoreNote.ShowDialog();
				Info.FillNotes();
				dgvNotes.DataSource = Info.notes;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			editStoreNote = new EditStoreNote(false, 0, Info.store, "", false);
			editStoreNote.ShowDialog();
			Info.FillNotes();
			dgvNotes.DataSource = Info.notes;
		}
	}
}
