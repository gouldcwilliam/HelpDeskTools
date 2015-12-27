using System;
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
				i10.Text = getIP(v10.Text);
				v20.Text = dr["VLAN 20"].ToString();
				i20.Text = getIP(v20.Text);
				v30.Text = dr["VLAN 30"].ToString();
				i30.Text = getIP(v30.Text);
				v40.Text = dr["VLAN 40"].ToString();
				i40.Text = getIP(v40.Text);
				v50.Text = dr["VLAN 50"].ToString();
				i50.Text = getIP(v50.Text);
				v60.Text = dr["VLAN 60"].ToString();
				i60.Text = getIP(v60.Text);
			}
		}

		private void txt_Click(object sender, EventArgs e)
		{
			TextBox tb = (TextBox)sender;
			tb.SelectAll();
		}
		private string getIP(string vlan)
		{
			if (vlan == "") { return ""; }
			string[] va = vlan.Split('.');
			va[3] = va[3].Replace("/25", "");
			int i = 0;
            int.TryParse(va[3], out i);
			va[3] = (i + 1).ToString();
			return va[0] + "." + va[1] + "." + va[2] + "." + va[3];
		}
	}
}
