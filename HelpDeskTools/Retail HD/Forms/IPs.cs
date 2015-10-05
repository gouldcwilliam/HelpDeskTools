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
	public partial class IPs : Form
	{
		public IPs()
		{
			InitializeComponent();
		}
		public IPs(string store)
		{
			InitializeComponent();
			_store = store;
			Text = Text + ": " + store;
		}
		string _store = string.Empty;

		private void IPs_Load(object sender, EventArgs e)
		{
			string sql = string.Format("SELECT [VLAN 10], [VLAN 20], [VLAN 30], [VLAN 40], [VLAN 50], [VLAN 60] FROM [ips] WHERE [Store #] = '{0}'", _store);
			System.Data.DataTable dt = Shared.SQL.Select(sql);
			foreach (System.Data.DataRow dr in dt.Rows)
			{
				v10.Text = dr["VLAN 10"].ToString();
				v20.Text = dr["VLAN 20"].ToString();
				v30.Text = dr["VLAN 30"].ToString();
				v40.Text = dr["VLAN 40"].ToString();
				v50.Text = dr["VLAN 50"].ToString();
				v60.Text = dr["VLAN 60"].ToString();
			}
		}
	}
}
