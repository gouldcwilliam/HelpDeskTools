using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Retail_HD.Forms
{
	public partial class StoreSearch : Form
	{
		private string _store = string.Empty;

		public StoreSearch()
		{
			InitializeComponent();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			List<SqlParameter> pList = new List<SqlParameter>();
			SqlParameter p;

			p = new SqlParameter("@TZ", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtTZ.Text.Trim()); pList.Add(p);
			p = new SqlParameter("@BAMS", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtBAMS.Text.Trim()); pList.Add(p);
			p = new SqlParameter("@MP", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtMP.Text.Trim()); pList.Add(p);
			p = new SqlParameter("@MANAGER", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtManager.Text.Trim()); pList.Add(p);
			p = new SqlParameter("@DM", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtDM.Text.Trim()); pList.Add(p);
			p = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtName.Text.Trim()); pList.Add(p);
			p = new SqlParameter("@TYPE", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtType.Text.Trim()); pList.Add(p);
			p = new SqlParameter("@ADDRESS", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtAddress.Text.Trim()); pList.Add(p);
			p = new SqlParameter("@CITY", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtCity.Text.Trim()); pList.Add(p);
			p = new SqlParameter("@STATE", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtState.Text.Trim()); pList.Add(p);
			p = new SqlParameter("@ZIP", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtZip.Text.Trim()); pList.Add(p);
			p = new SqlParameter("@PHONE", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtPhone.Text.Trim()); pList.Add(p);
			p = new SqlParameter("@IP", System.Data.SqlDbType.VarChar); p.Value = Shared.SQL.DBNullIfEmpty(txtIP.Text.Trim()); pList.Add(p);

			dgvStores.DataSource = Shared.SQL.Select(Shared.SQLSettings.Default._StoreSearch, pList);
		}



		private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (dgvStores.Rows.Count>0)
			{
				_store = dgvStores.SelectedRows[0].Cells[0].Value.ToString();
				int temp = 0;
				Shared.Functions.isNumeric(_store, out temp);
				if (temp != 0)
				{
					Info.store = temp;
				}
			}
		}

		private void StoreSearch_FormClosed(object sender, FormClosedEventArgs e)
		{
			int temp = 0;
			Shared.Functions.isNumeric(_store, out temp);
			if (temp != 0) { 
				Info.store = temp; 
			}
			
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			foreach (Control c in gbTop.Controls)
			{
				if(c is GroupBox)
				{
					foreach(Control ctrl in c.Controls)
					{
						if(ctrl is TextBox || ctrl is ComboBox) { ctrl.Text = ""; }
					}
				}
			}
			//dgvStores.DataSource = new System.Data.DataTable();
		}
	}
}
