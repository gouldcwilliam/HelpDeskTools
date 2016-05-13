using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


using System.Data.SqlClient;

namespace Retail_HD.Forms
{

	/// <summary> Display form for choosing what information to compare 
	/// and update in the store information table
	/// </summary>
	public partial class ExcelCompareData : Form
	{
        private BindingList<combinedResults> blCombined = new BindingList<combinedResults>();

        /// <summary> Form showing data from an excel file query
		/// </summary>
		/// <param name="dtExcel">File name to query</param>
		public ExcelCompareData(DataTable dtExcel)
		{
			InitializeComponent();
            DataTable dtSQL = Shared.SQL.Select("select [store] as [Store Number], [manager] as [Store Manager], [dm] as [District Manager], [rm] as [Regional Manager] from [Stores]");
            foreach(DataRow drExcel in dtExcel.Rows)
            {
                dtResult resultExcel = new dtResult(drExcel);
                DataRow[] drS = dtSQL.Select("[Store Number] = " + resultExcel.Store);
                if (drS.Length == 0) { continue; }
                dtResult resultSQL = new dtResult(drS[0]);
                if(!resultExcel.Compare(resultSQL))
                {
                    blCombined.Add(new combinedResults(resultExcel, resultSQL));
                }
            }
            dataGridView1.DataSource = blCombined;
		}

        class dtResult
        {
            public dtResult(string store, string manager, string dm, string rm)
            {
                Store = store; Manager = manager; DM = dm; RM = rm;
            }
            public dtResult(DataRow dr)
            {
                Store = dr["Store Number"].ToString();
                Manager = dr["Store Manager"].ToString();
                DM = dr["District Manager"].ToString();
                RM = dr["Regional Manager"].ToString();
            }
            public string Store { get; set; }
            public string Manager { get; set; }
            public string DM { get; set; }
            public string RM { get; set; }
            public bool Compare(dtResult compare)
            {
                if (this.Store != compare.Store) { return false; }
                if (this.Manager != compare.Manager) { return false; }
                if (this.DM != compare.DM) { return false; }
                if (this.RM != compare.RM) { return false; }
                return true;
            }
        }
        class combinedResults
        {
            public combinedResults(dtResult eResult, dtResult sResult)
            {
                Update = false;
                _eResult = eResult;
                _sResult = sResult;
            }
            private dtResult _eResult;
            private dtResult _sResult;
            public bool Update { get; set; }
            public string Store { get { return _eResult.Store; } }
            public string Excel_Manager { get { return _eResult.Manager; } }
            public string SQL_Manager { get { return _sResult.Manager; } }
            public string Excel_DM { get { return _eResult.DM; } }
            public string SQL_DM { get { return _sResult.DM; } }
            public string Excel_RM { get { return _eResult.RM; } }
            public string SQL_RM { get { return _sResult.RM; } }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["Update"].Value = true;
            }
            
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["Update"].Value = false;
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewCellStyle gray = dataGridView1.DefaultCellStyle.Clone();
            gray.BackColor = Color.Gray;
            dataGridView1.Columns["SQL_Manager"].DefaultCellStyle = gray;
            dataGridView1.Columns["Store"].DefaultCellStyle = gray;
            dataGridView1.Columns["SQL_DM"].DefaultCellStyle = gray;
            dataGridView1.Columns["SQL_RM"].DefaultCellStyle = gray;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if((bool)row.Cells["Update"].Value)
                {
                    string sql = "update [Stores] set [manager]=@manager, [dm]=@dm, [rm]=@rm where [store]=@store";
                    List<SqlParameter> paramList = new List<SqlParameter>();
                    paramList.Add(new SqlParameter("@manager", row.Cells["Excel_Manager"].Value.ToString()));
                    paramList.Add(new SqlParameter("@dm", row.Cells["Excel_DM"].Value.ToString()));
                    paramList.Add(new SqlParameter("@rm", row.Cells["Excel_RM"].Value.ToString()));
                    paramList.Add(new SqlParameter("@store", row.Cells["Store"].Value.ToString()));
                    
                    if (!Shared.SQL.Update(sql, paramList)) 
                    { 
                        MessageBox.Show("Error happened on update:\n" + sql, 
                            "SQL Update", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Exclamation);
                        return; 
                    }
                }
            }
            Close();
        }
	}
}
