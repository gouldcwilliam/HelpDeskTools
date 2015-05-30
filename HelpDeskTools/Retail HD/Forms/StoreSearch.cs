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
	public partial class StoreSearch : Form
	{
		private string _store = string.Empty;

		public StoreSearch()
		{
			InitializeComponent();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource = SQL.dt_StoreSearch(txtTZ.Text, txtMP.Text, txtDM.Text, txtName.Text, 
				txtType.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text, txtPhone.Text);
		}

		private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (dataGridView1.Rows.Count>0)
			{
				_store = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
				int temp = 0;
				HDSharedServices.Functions.isNumeric(_store, out temp);
				if (temp != 0)
				{
					Info.store = temp;
				}
			}
		}

		private void StoreSearch_FormClosed(object sender, FormClosedEventArgs e)
		{
			int temp = 0;
			HDSharedServices.Functions.isNumeric(_store, out temp);
			if (temp != 0) { 
				Info.store = temp; 
			}
			
		}
	}
}
