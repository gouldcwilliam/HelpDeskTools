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
	
	/// <summary> Display form for choosing what information to compare 
	/// and update in the store information table
	/// </summary>
	public partial class ExcelCompareData : Form
	{
		// TODO  - Gather the information to be compared

        private DataTable _dtExcel { get; set; }
        private DataTable _dtSQL { get; set; }
		/// <summary> Form showing data from an excel file query
		/// </summary>
		/// <param name="file">File name to query</param>
		public ExcelCompareData(DataTable dataTable)
		{
			InitializeComponent();
            _dtExcel = dataTable;
            _dtSQL = Shared.SQL.Select("select [Stores].[store], [Stores].[manager], [Stores].[dm], [Stores].[rm] from [Stores]");
            dgvExcel.DataSource = _dtExcel;
            dgvSQL.DataSource = _dtSQL;
		}

	}
}
