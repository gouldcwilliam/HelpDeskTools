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
	public partial class ExcelCompareData : Form
	{
		/// <summary> Form showing data from an excel file query
		/// </summary>
		/// <param name="file">File name to query</param>
		public ExcelCompareData(string file)
		{
			InitializeComponent();
			_File = file;
			this.Text = _File;
			_Query = _query;
		}
		/// <summary> Form showing data from an excel file query
		/// </summary>
		/// <param name="file">File name to query</param>
		/// <param name="query">Select statement used in the query</param>
		public ExcelCompareData(string file, string query)
		{
			InitializeComponent();
			_File = file;
			this.Text = file;
			_Query = query;
		}


		/// <summary> private select statment used as default
		/// </summary>
		private string _query = "select [Store Number], [Store Manager], [District Manager], [Regional Manager] from [owssvr.dll-1$]";
		/// <summary> public select statement used
		/// </summary>
		public string _Query;
		/// <summary> public name of the excel file
		/// </summary>
		public string _File;


		/// <summary> Shows option to modify the select query then executes and loads the datagridview
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XcelTest_Load(object sender, EventArgs e)
		{
			Forms.UserInput i = new UserInput("Enter query to execute", _Query);
			i.Size = new System.Drawing.Size(600,126);
			if (i.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				_Query = i._UserInput;
				dg_main.DataSource = HDSharedServices.Functions.Excel_QuerySheet(_File, _Query);
			}
		}
	}
}
