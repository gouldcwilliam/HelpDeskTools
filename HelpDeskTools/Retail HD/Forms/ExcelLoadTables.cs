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
	public partial class ExcelLoadTables : Form
	{
		/// <summary> Loads and allows user to select tables from the excel file's schema
		/// </summary>
		/// <param name="filename"></param>
		public ExcelLoadTables(string filename)
		{
			InitializeComponent();
			Text = filename;
			_filename = filename;
		}

		/// <summary> name of the exel file
		/// </summary>
		private string _filename;
		/// <summary> select query built from the user's selections
		/// </summary>
		public string _Query;

		/// <summary> Loads the file's tables into the table checklistbox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExcelSchemaInfo_Load(object sender, EventArgs e)
		{
			foreach (DataRow r in Shared.Functions.Excel_GetTables(_filename).Rows)
			{
				ckbTablesE.Items.Add(r["TABLE_NAME"].ToString());
			}
		}

		/// <summary> Uses the selected table to verify column names and load them into the column checklistbox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLoadE_Click(object sender, EventArgs e)
		{
			ckbColumnsE.Items.Clear();
			if (ckbTablesE.CheckedItems.Count == 0) { return; }
			foreach (DataRow r in Shared.Functions.Excel_GetColumns(_filename, ckbTablesE.CheckedItems[0].ToString()).Rows)
			{
				ckbColumnsE.Items.Add(r["COLUMN_NAME"].ToString());
			}
		}

		/// <summary> handles the cancel button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();
		}

		/// <summary> verify user selections
		/// constructs the select statement
		/// runs the select statement on the excel file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (ckbTablesE.CheckedItems.Count == 0 || ckbTablesE.CheckedItems.Count > 1)
			{
				MessageBox.Show("Incorrect number of tables/sheets selected", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (ckbColumnsE.Items.Count == 0)
			{
				MessageBox.Show("No Column names found in the selected table", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			_Query = string.Format(
				"select [Store Number], [Store Manager], [District Manager], [Regional Manager] from [{0}]",
				ckbTablesE.CheckedItems[0]
				);
			Forms.ExcelCompareData xtest = new ExcelCompareData(Shared.Functions.Excel_QuerySheet(_filename, _Query));
			xtest.Show();
			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

	}
}
