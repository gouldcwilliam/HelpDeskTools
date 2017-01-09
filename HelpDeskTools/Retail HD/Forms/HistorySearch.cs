using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Retail_HD.Classes;

namespace Retail_HD.Forms
{
    /// <summary>
    /// search call history
    /// </summary>
	public partial class HistorySearch : Form
	{
        /// <summary>
        /// <see cref="HistorySearch"/>
        /// </summary>
		public HistorySearch()
		{
			InitializeComponent();
			Text = _defaultText;
		}


		int _resultLimit = 10000;
		string _defaultText = "History";
		List<Topic> _topics = new List<Topic>();
		List<Technician> _technicians = new List<Technician>();
		BGWorkers.Exporting exp = new BGWorkers.Exporting();


		// On form load
		private void HistorySearch_Load(object sender, EventArgs e)
		{
			Info.GetCategories();
            cmbCategory.Items.Clear();
			foreach(Category c in Info.categories) { cmbCategory.Items.Add(c._category); }

			Info.FillTopics();
            cmbTopic.Items.Clear();
			foreach(Topic t in Info.topics) { cmbTopic.Items.Add(t._topic); }

			Info.FillTechnicians();
            cmbTech.Items.Clear();
			foreach (Technician t in Info.technicians) { cmbTech.Items.Add(t._initials); }

			dgvResults.DataSource = Shared.SQL.dt_HistorySearch();
			if (dgvResults.Rows.Count > 0)
			{
				dgvResults.Columns["ID"].Visible = false;
                dgvResults.Columns["Date"].Visible = false;
				dgvResults.Columns["DateOnly"].FillWeight = 2;
                dgvResults.Columns["Time"].FillWeight = 2;
                dgvResults.Columns["Store"].FillWeight = 2;
				dgvResults.Columns["Tech"].FillWeight = 2;
				dgvResults.Columns["Category"].FillWeight = 4;
				dgvResults.Columns["Topic"].FillWeight = 4;
				dgvResults.Columns["Details"].FillWeight = 10;
				dgvResults.Columns["In/Out"].FillWeight = 2;
				dgvResults.Columns["Trax"].Visible = false;
				dgvResults.Columns["URL"].FillWeight = 4;
			}

		}




		// Double click data view
		private void dgvResults_DoubleClick(object sender, EventArgs e)
		{
            
			if (dgvResults.Rows.Count > 0)
			{
				string id = dgvResults.SelectedRows[0].Cells["ID"].Value.ToString();
				string store = dgvResults.SelectedRows[0].Cells["Store"].Value.ToString();
				string date = dgvResults.SelectedRows[0].Cells["Date"].Value.ToString();
				string tech = dgvResults.SelectedRows[0].Cells["Tech"].Value.ToString();
				string category = dgvResults.SelectedRows[0].Cells["Category"].Value.ToString();
				string topic = dgvResults.SelectedRows[0].Cells["Topic"].Value.ToString();
				string details = dgvResults.SelectedRows[0].Cells["Details"].Value.ToString();
				string type = dgvResults.SelectedRows[0].Cells["In/Out"].Value.ToString();
				bool trax = (dgvResults.SelectedRows[0].Cells["Trax"].Value.ToString().Contains("True"));
				string url = dgvResults.SelectedRows[0].Cells["URL"].Value.ToString();
				Forms.EditCalls editCalls = new Forms.EditCalls(id, store, date, tech, category, topic, details, type, trax, url);
				editCalls.ShowDialog();
			}
			HistorySearch_Load(sender, e);
		}


		// Perform after data is loaded to form
		private void dgvResults_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			DataGridViewCellStyle red = dgvResults.DefaultCellStyle.Clone();
			red.BackColor = Color.Red;
			foreach (DataGridViewRow r in dgvResults.Rows)
			{
				if (r.Cells["Trax"].Value.ToString().Contains("True"))
				{
					r.DefaultCellStyle = red;
					r.DefaultCellStyle.SelectionForeColor = Color.Red;
				}
			}
            txtTotal.Text = dgvResults.Rows.Count.ToString();
		}



		// Perform query with the user input
		private void Search(object sender, EventArgs e)
		{
			int limit = 10000;
			if(txtResultLimit.Text != string.Empty &&  Shared.Functions.isTxtBoxNumeric(txtResultLimit, out limit))
			{
				_resultLimit = limit;
			}
			if (dtpDate1.Checked && dtpDate2.Checked)
			{
				dgvResults.DataSource = Shared.SQL.dt_HistorySearch(txtStore.Text, dtpDate1.Value, dtpDate2.Value, cmbType.Text, cmbCategory.Text, cmbTopic.Text, cmbTech.Text, txtDetails.Text, ckbTrax.Checked, txtURL.Text, _resultLimit);
			}
			else if(dtpDate2.Checked)
			{
				dgvResults.DataSource = Shared.SQL.dt_HistorySearch(txtStore.Text, dtpDate2.Checked, dtpDate1.Value, cmbType.Text, cmbCategory.Text, cmbTopic.Text, cmbTech.Text, txtDetails.Text, ckbTrax.Checked, txtURL.Text, _resultLimit);
			}
			else
			{
				dgvResults.DataSource = Shared.SQL.dt_HistorySearch(txtStore.Text, dtpDate1.Checked, dtpDate1.Value, cmbType.Text, cmbCategory.Text, cmbTopic.Text, cmbTech.Text.Trim(), txtDetails.Text, ckbTrax.Checked, txtURL.Text, _resultLimit);
			}
			if (dgvResults.Rows.Count > 0)
			{
				dgvResults.Columns["ID"].Visible = false;
                dgvResults.Columns["Date"].Visible = false;
                dgvResults.Columns["DateOnly"].FillWeight = 2;
                dgvResults.Columns["Time"].FillWeight = 2;
                dgvResults.Columns["Store"].FillWeight = 2;
				dgvResults.Columns["Tech"].FillWeight = 2;
				dgvResults.Columns["Category"].FillWeight = 4;
				dgvResults.Columns["Topic"].FillWeight = 4;
				dgvResults.Columns["Details"].FillWeight = 10;
				dgvResults.Columns["In/Out"].FillWeight = 2;
				dgvResults.Columns["Trax"].Visible = false;
				dgvResults.Columns["URL"].FillWeight = 4;
			}
			 
		}


		// Clears search data
		private void ClearForm(object sender, EventArgs e)
		{
			txtStore.Text = string.Empty;
			cmbType.Text = string.Empty;
			dtpDate1.Checked = false;
			dtpDate2.Checked = false;
			cmbCategory.Text = string.Empty;
			cmbTopic.Text = string.Empty;
			cmbTech.Text = string.Empty;
			txtDetails.Text = string.Empty;
			ckbTrax.Checked = false;
			txtURL.Text = string.Empty;
		}


		// exports datatable to excel workbook
		private void Export(object sender, EventArgs e)
		{
			if (exp.Visible) { return; }
			if (dgvResults.Rows.Count == 0) { MessageBox.Show("No data to Export!"); return; }

			System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
			sfd.DefaultExt = ".xls";
			sfd.Title = "Export data to location";
			sfd.FileName = "Export.xls";

			if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }
			if (sfd.FileName == string.Empty) { MessageBox.Show("No output file selected"); return; }

			exp = new BGWorkers.Exporting((DataTable)dgvResults.DataSource, sfd.FileName);
			exp.Show();
		}

	}


}


