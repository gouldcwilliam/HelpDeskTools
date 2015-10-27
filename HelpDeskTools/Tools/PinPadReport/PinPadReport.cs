using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PinPadReport.Properties;
namespace PinPadReport
{
	class PinPadReport
	{
		static void Main(string[] args)
		{
			string body = Settings.Default.header;
			body += "Calls for VeriFone reboots and/or power cycles from: ";
			body += System.DateTime.Today.AddDays(-1.0).ToShortDateString();
			body += "<br /><br />TOTAL CALLS: " + Shared.SQL.Select(Settings.Default.query_count).Rows[0][0].ToString();
			body += Settings.Default.tableHead;

			DataTable dt = Shared.SQL.Select(Settings.Default.query_calls);

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				body += string.Format(Settings.Default.row, dt.Rows[i][0], dt.Rows[i][1]);
			}
			
			body += Settings.Default.footer;
			

			Shared.Functions.b_SendEmail(Settings.Default.to, body, Settings.Default.subject);
		}
	}
}
